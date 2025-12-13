using Bai05.Models;
using Bai05.Services;
using Bai05.Utils;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bai05
{
    public partial class EmailContributionForm : Form
    {
        private readonly FoodService _foodService;
        private readonly EmailValidatorService _emailValidator;
        public EmailContributionForm()
        {
            InitializeComponent();
            _foodService = Program.foodSer;
            _emailValidator = new EmailValidatorService(Program.apiCli);
        }

        private async void btnLoadFromEmail_Click(object sender, EventArgs e)
        {
            string imapServer = "imap.gmail.com";
            int imapPort = 993;
            string email = CurrentUser.User?.email ?? "";
            string password = txtAppPassword.Text.Trim();

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Không tìm thấy email người dùng! Vui lòng đăng nhập lại.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập App Password của Gmail!",
                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAppPassword.Focus();
                return;
            }

            btnLoadFromEmail.Enabled = false;
            progressBar1.Style = ProgressBarStyle.Marquee;
            lblStatus.Text = "Đang kết nối Gmail...";

            try
            {
                var results = await LoadEmailContributionsAsync(imapServer, imapPort, email, password);

                progressBar1.Style = ProgressBarStyle.Blocks;

                if (results.Count == 0)
                {
                    lblStatus.Text = "Không có email đóng góp mới";
                    MessageBox.Show("Không tìm thấy email nào có tiêu đề 'Đóng góp món ăn'.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Hiển thị kết quả
                lstResults.Items.Clear();
                int totalSuccess = results.Count(r => r.Success);
                int totalFailed = results.Count(r => !r.Success);

                foreach (var result in results)
                {
                    string status = result.Success ? "✅" : "❌";
                    lstResults.Items.Add($"{status} [{result.SenderEmail}] - {result.Message}");
                }

                lblStatus.Text = $"Hoàn thành: {totalSuccess} thành công, {totalFailed} thất bại";

                MessageBox.Show(
                    $"Đã xử lý {results.Count} email\n" +
                    $"✅ Thành công: {totalSuccess}\n" +
                    $"❌ Thất bại: {totalFailed}",
                    "Kết quả",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                progressBar1.Style = ProgressBarStyle.Blocks;
                lblStatus.Text = "Lỗi: " + ex.Message;
                MessageBox.Show($"Lỗi kết nối Gmail:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLoadFromEmail.Enabled = true;
            }
        }

        private async Task<List<EmailProcessResult>> LoadEmailContributionsAsync(
            string server, int port, string email, string password)
        {
            var results = new List<EmailProcessResult>();

            using (var client = new ImapClient())
            {
                // Kết nối đến Gmail IMAP
                await client.ConnectAsync(server, port, true);
                await client.AuthenticateAsync(email, password);

                lblStatus.Text = "Đã kết nối. Đang đọc email...";

                var inbox = client.Inbox;
                await inbox.OpenAsync(FolderAccess.ReadWrite);

                // Tìm email chưa đọc
                var uids = await inbox.SearchAsync(SearchQuery.NotSeen);

                lblStatus.Text = $"Tìm thấy {uids.Count} email chưa đọc. Đang xử lý...";

                foreach (var uid in uids)
                {
                    try
                    {
                        var message = await inbox.GetMessageAsync(uid);

                        // Kiểm tra Title có chứa "Đóng góp món ăn"
                        if (!IsValidTitle(message.Subject))
                            continue;

                        // Xử lý email này
                        var result = await ProcessEmailAsync(message);
                        results.Add(result);

                        // Đánh dấu đã đọc
                        await inbox.AddFlagsAsync(uid, MessageFlags.Seen, true);
                    }
                    catch (Exception ex)
                    {
                        results.Add(new EmailProcessResult
                        {
                            Success = false,
                            Message = $"Lỗi xử lý email: {ex.Message}"
                        });
                    }
                }

                await client.DisconnectAsync(true);
            }

            return results;
        }

        private bool IsValidTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
                return false;

            // Chuẩn hóa: chữ thường, không dấu
            string normalized = RemoveDiacritics(title.ToLower());
            return normalized.Contains("dong gop mon an");
        }

        private async Task<EmailProcessResult> ProcessEmailAsync(MimeKit.MimeMessage message)
        {
            try
            {
                // Lấy email người gửi
                var senderAddress = message.From.Mailboxes.FirstOrDefault()?.Address ?? "";
                var senderName = message.From.Mailboxes.FirstOrDefault()?.Name ?? "Người ẩn danh";

                if (string.IsNullOrEmpty(senderAddress))
                {
                    return new EmailProcessResult
                    {
                        Success = false,
                        SenderEmail = "Unknown",
                        Message = "Không xác định được email người gửi"
                    };
                }

                // Kiểm tra email đã đăng ký chưa
                lblStatus.Text = $"Kiểm tra email {senderAddress}...";
                var checkResult = await _emailValidator.CheckEmailRegisteredAsync(senderAddress);

                if (!checkResult.IsRegistered || checkResult.HasError)
                {
                    return new EmailProcessResult
                    {
                        Success = false,
                        SenderEmail = senderAddress,
                        Message = "Email chưa đăng ký trong hệ thống"
                    };
                }

                // Parse body email
                string bodyText = message.TextBody ?? message.HtmlBody ?? "";
                var foods = ParseFoodsFromBody(bodyText);

                if (foods.Count == 0)
                {
                    return new EmailProcessResult
                    {
                        Success = false,
                        SenderEmail = senderAddress,
                        Message = "Không tìm thấy món ăn hợp lệ trong email"
                    };
                }

                // Thêm các món ăn vào database
                lblStatus.Text = $"Đang thêm {foods.Count} món ăn...";
                int successCount = 0;

                foreach (var food in foods)
                {
                    var addResult = await _foodService.AddFoodAsync(
                        food.Name,
                        food.Price,
                        food.Description,
                        food.ImageUrl,
                        food.Address
                    );

                    if (addResult.Success)
                        successCount++;
                }

                return new EmailProcessResult
                {
                    Success = true,
                    SenderEmail = senderAddress,
                    SenderName = senderName,
                    FoodCount = foods.Count,
                    SuccessCount = successCount,
                    Message = $"Đã thêm {successCount}/{foods.Count} món ăn"
                };
            }
            catch (Exception ex)
            {
                return new EmailProcessResult
                {
                    Success = false,
                    Message = $"Lỗi: {ex.Message}"
                };
            }
        }

        private List<FoodContribution> ParseFoodsFromBody(string body)
        {
            var foods = new List<FoodContribution>();
            var lines = body.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                var trimmed = line.Trim();
                if (string.IsNullOrEmpty(trimmed))
                    continue;

                // Format: <tên món>;<url hình>
                // Hoặc: <tên món>;<url hình>;<giá>;<địa chỉ>;<mô tả>
                var parts = trimmed.Split(';');

                if (parts.Length < 2)
                    continue;

                var food = new FoodContribution
                {
                    Name = parts[0].Trim(),
                    ImageUrl = parts[1].Trim()
                };

                if (parts.Length >= 3 && int.TryParse(parts[2].Trim(), out int price))
                    food.Price = price;

                if (parts.Length >= 4)
                    food.Address = parts[3].Trim();

                if (parts.Length >= 5)
                    food.Description = parts[4].Trim();

                foods.Add(food);
            }

            return foods;
        }

        private string RemoveDiacritics(string text)
        {
            string normalized = text.Normalize(System.Text.NormalizationForm.FormD);
            var chars = normalized.Where(c =>
                System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c)
                != System.Globalization.UnicodeCategory.NonSpacingMark);
            return new string(chars.ToArray()).Normalize(System.Text.NormalizationForm.FormC);
        }

        private void lnkAppPasswordGuide_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "https://myaccount.google.com/apppasswords",
                    UseShellExecute = true
                });
            }
            catch { }
        }
    }

    public class FoodContribution
    {
        public string Name { get; set; } = "";
        public string ImageUrl { get; set; } = "";
        public int Price { get; set; } = 0;
        public string Address { get; set; } = "";
        public string Description { get; set; } = "";
    }

    public class EmailProcessResult
    {
        public bool Success { get; set; }
        public string SenderEmail { get; set; } = "";
        public string SenderName { get; set; } = "";
        public int FoodCount { get; set; }
        public int SuccessCount { get; set; }
        public string Message { get; set; } = "";
    }
}
