using Bai05.Models;
using Bai05.Services;
using Bai05.Utils;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                    $"Thành công: {totalSuccess}\n" +
                    $"Thất bại: {totalFailed}",
                    "Kết quả",
                    MessageBoxButtons.OK);

                // Đặt DialogResult để MainForm biết cần refresh
                this.DialogResult = DialogResult.OK;
            }
            catch (MailKit.Security.AuthenticationException)
            {
                progressBar1.Style = ProgressBarStyle.Blocks;
                lblStatus.Text = "Lỗi xác thực Gmail";

                MessageBox.Show(
                    "Lỗi xác thực Gmail!\n\n" +
                    "Vui lòng kiểm tra:\n\n" +
                    "1️.Đã BẬT IMAP trong Gmail:\n" +
                    "   • Vào Gmail->Settings->See all settings\n" +
                    "   • Tab: Forwarding and POP/IMAP\n" +
                    "   • IMAP access: Enable IMAP\n" +
                    "   • IMAP settings: Tắt tự động xóa\n\n" +
                    "2️. Đang dùng App Password (16 ký tự):\n" +
                    "   • KHÔNG dùng mật khẩu Gmail thường\n" +
                    "   • Tạo tại: https://myaccount.google.com/apppasswords\n\n" +
                    "3️. Email đúng format: example@gmail.com",
                    "Lỗi xác thực",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
                await client.ConnectAsync(server, port, true);
                await client.AuthenticateAsync(email, password);

                lblStatus.Text = "Đã kết nối. Đang đọc email...";
                Application.DoEvents();

                var inbox = client.Inbox;
                await inbox.OpenAsync(FolderAccess.ReadWrite);

                var query = SearchQuery.SubjectContains("Đóng góp món ăn")
                    .And(SearchQuery.DeliveredAfter(DateTime.Now.AddDays(-7)));
                var uids = await inbox.SearchAsync(query);

                lblStatus.Text = $"Tìm thấy {uids.Count} email đóng góp. Đang xử lý...";
                Application.DoEvents();

                int currentIndex = 0;
                foreach (var uid in uids)
                {
                    currentIndex++;
                    lblStatus.Text = $"Đang xử lý email {currentIndex}/{uids.Count}...";
                    Application.DoEvents();

                    try
                    {
                        var message = await inbox.GetMessageAsync(uid);

                        var result = await ProcessEmailAsync(message);
                        results.Add(result);

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
                var senderAddress = message.From.Mailboxes.FirstOrDefault()?.Address ?? "";
                var senderName = message.From.Mailboxes.FirstOrDefault()?.Name ?? "Người ẩn danh";

                if (string.IsNullOrEmpty(senderAddress))
                {
                    return new EmailProcessResult
                    {
                        Success = false,
                        SenderEmail = "Unknown",
                        Message = "❌ Không xác định được email người gửi"
                    };
                }

                // Kiểm tra email đã đăng ký chưa
                lblStatus.Text = $"Kiểm tra email {senderAddress}...";
                Application.DoEvents();

                var checkResult = await _emailValidator.CheckEmailRegisteredAsync(senderAddress);

                if (!checkResult.IsRegistered || checkResult.HasError)
                {
                    return new EmailProcessResult
                    {
                        Success = false,
                        SenderEmail = senderAddress,
                        Message = "❌ Email chưa đăng ký trong hệ thống"
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
                        Message = "❌ Không tìm thấy món ăn hợp lệ trong email"
                    };
                }

                // Thêm các món ăn vào database (KHÔNG KIỂM TRA TRÙNG)
                lblStatus.Text = $"Đang thêm {foods.Count} món ăn...";
                Application.DoEvents();

                int successCount = 0;
                var errors = new List<string>(); // Lưu các lỗi

                foreach (var food in foods)
                {
                    // VALIDATE trước khi gọi API
                    if (string.IsNullOrWhiteSpace(food.Name))
                    {
                        System.Diagnostics.Debug.WriteLine("❌ Bỏ qua: Tên món rỗng");
                        continue;
                    }

                    if (string.IsNullOrWhiteSpace(food.ImageUrl) || food.ImageUrl.Length > 500)
                    {
                        System.Diagnostics.Debug.WriteLine($"❌ Bỏ qua [{food.Name}]: URL không hợp lệ hoặc quá dài");
                        continue;
                    }

                    // ĐẢM BẢO KHÔNG CÓ NULL
                    var addResult = await _foodService.AddFoodAsync(
                        food.Name,
                        food.Price,
                        food.Description ?? "Món ăn ngon",  // ← Không null
                        food.ImageUrl,
                        food.Address ?? "TP.HCM"             // ← Không null
                    );

                    if (addResult.Success)
                    {
                        successCount++;
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine($"❌ Lỗi [{food.Name}]: {addResult.ErrorMessage}");
                    }
                }

                // Tạo message kết quả
                string resultMsg = $"Đã thêm {successCount}/{foods.Count} món";

                if (errors.Count > 0)
                {
                    resultMsg += $"\n\nLỗi ({errors.Count} món):\n" + string.Join("\n", errors);
                }

                return new EmailProcessResult
                {
                    Success = successCount > 0,
                    SenderEmail = senderAddress,
                    SenderName = senderName,
                    FoodCount = foods.Count,
                    SuccessCount = successCount,
                    Message = resultMsg
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

                var parts = trimmed.Split(';');

                if (parts.Length < 2)
                    continue;

                var food = new FoodContribution
                {
                    Name = parts[0].Trim(),
                    ImageUrl = parts[1].Trim(),
                    // THÊM GIÁ TRỊ MẶC ĐỊNH
                    Description = "Món ăn ngon", // MẶC ĐỊNH
                    Address = "TP. Hồ Chí Minh",  // MẶC ĐỊNH
                    Price = 0
                };

                // Parse giá (nếu có)
                if (parts.Length >= 3 && int.TryParse(parts[2].Trim(), out int price))
                    food.Price = price;

                // Parse địa chỉ (nếu có) - GHI ĐÈ giá trị mặc định
                if (parts.Length >= 4 && !string.IsNullOrWhiteSpace(parts[3]))
                    food.Address = parts[3].Trim();

                // Parse mô tả (nếu có) - GHI ĐÈ giá trị mặc định
                if (parts.Length >= 5 && !string.IsNullOrWhiteSpace(parts[4]))
                    food.Description = parts[4].Trim();

                // QUAN TRỌNG: Kiểm tra URL hợp lệ
                if (string.IsNullOrWhiteSpace(food.ImageUrl) ||
                    (!food.ImageUrl.StartsWith("http://") && !food.ImageUrl.StartsWith("https://")))
                {
                    // URL không hợp lệ → bỏ qua món này
                    System.Diagnostics.Debug.WriteLine($"❌ Bỏ qua món [{food.Name}]: URL không hợp lệ");
                    continue;
                }

                foods.Add(food);
            }

            return foods;
        }

        private string RemoveDiacritics(string text)
        {
            string normalized = text.Normalize(NormalizationForm.FormD);
            var chars = normalized.Where(c =>
                System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c)
                != System.Globalization.UnicodeCategory.NonSpacingMark);
            return new string(chars.ToArray()).Normalize(NormalizationForm.FormC);
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