using Bai05.Services;
using Bai05.Utils;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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
            string email = txtGmail.Text.Trim();
            string password = txtAppPassword.Text.Trim().Replace(" ", "");

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

                lstResults.Items.Clear();
                int totalSuccess = results.Count(r => r.Success);
                int totalFailed = results.Count(r => !r.Success);

                foreach (var result in results)
                {
                    string status = result.Success ? "V" : "X";
                    lstResults.Items.Add($"{status} [{result.SenderEmail}] - {result.Message}");
                }

                lblStatus.Text = $"Hoàn thành: {totalSuccess} thành công, {totalFailed} thất bại";

                MessageBox.Show(
                    $"Đã xử lý {results.Count} email\n" +
                    $"Thành công: {totalSuccess}\n" +
                    $"Thất bại: {totalFailed}",
                    "Kết quả",
                    MessageBoxButtons.OK);

                this.DialogResult = DialogResult.OK;
            }
            catch (AuthenticationException ex)
            {
                progressBar1.Style = ProgressBarStyle.Blocks;
                lblStatus.Text = "Lỗi xác thực Gmail";

                MessageBox.Show(
                    "Gmail từ chối đăng nhập.\n\n" +
                    "Chi tiết server trả về:\n" + ex.Message,
                    "Lỗi xác thực",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (MailKit.CommandException ex)
            {
                progressBar1.Style = ProgressBarStyle.Blocks;
                lblStatus.Text = "Lỗi IMAP";

                MessageBox.Show(
                    "IMAP command bị từ chối.\n\n" +
                    "Chi tiết:\n" + ex.Message,
                    "Lỗi IMAP",
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

            using (var client = new ImapClient(new ProtocolLogger("imap.log")))
            {
                await client.ConnectAsync(server, port, SecureSocketOptions.SslOnConnect);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                await client.AuthenticateAsync(email, password);

                lblStatus.Text = "Đã kết nối. Đang đọc email...";
                Application.DoEvents();

                var inbox = client.Inbox;
                await inbox.OpenAsync(FolderAccess.ReadWrite);

                var query = SearchQuery.DeliveredAfter(DateTime.Now.AddDays(-7))
                    .And(SearchQuery.SubjectContains("Đóng góp"))
                    .Or(SearchQuery.DeliveredAfter(DateTime.Now.AddDays(-7))
                        .And(SearchQuery.SubjectContains("Dong gop")));

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

                        var subject = message.Subject ?? "";
                        if (!IsValidTitle(subject))
                            continue;

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
            if (string.IsNullOrWhiteSpace(title)) return false;
            string normalized = NormalizeVN(title);
            return normalized.Contains("dong gop mon an");
        }

        private string NormalizeVN(string text)
        {
            if (string.IsNullOrEmpty(text)) return "";
            text = text.Replace('đ', 'd').Replace('Đ', 'D');
            text = RemoveDiacritics(text);
            return text.ToLowerInvariant();
        }

        private string GetBodyAsPlainText(MimeKit.MimeMessage message)
        {
            var text = message.TextBody;
            if (!string.IsNullOrWhiteSpace(text))
                return text;

            var html = message.HtmlBody ?? "";
            if (string.IsNullOrWhiteSpace(html))
                return "";

            html = Regex.Replace(html, @"<\s*br\s*/?\s*>", "\n", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"</\s*div\s*>", "\n", RegexOptions.IgnoreCase);
            html = Regex.Replace(html, @"</\s*p\s*>", "\n", RegexOptions.IgnoreCase);

            var stripped = Regex.Replace(html, "<.*?>", "");
            return WebUtility.HtmlDecode(stripped);
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
                        Message = "Không xác định được email người gửi"
                    };
                }

                string bodyText = GetBodyAsPlainText(message);
                var foods = ParseFoodsFromBody(bodyText);

                if (foods.Count == 0)
                {
                    return new EmailProcessResult
                    {
                        Success = false,
                        SenderEmail = senderAddress,
                        SenderName = senderName,
                        Message = "Không tìm thấy món ăn hợp lệ trong email"
                    };
                }

                lblStatus.Text = $"Đang thêm {foods.Count} món ăn...";
                Application.DoEvents();

                int successCount = 0;
                var errors = new List<string>();

                foreach (var food in foods)
                {
                    if (string.IsNullOrWhiteSpace(food.Name))
                        continue;

                    if (string.IsNullOrWhiteSpace(food.ImageUrl) || food.ImageUrl.Length > 2000)
                        continue;

                    var addResult = await _foodService.AddFoodAsync(
                        food.Name,
                        food.Price,
                        "Món ăn ngon",  
                        food.ImageUrl,
                        food.Address
                    );

                    if (addResult.Success)
                        successCount++;
                    else
                        errors.Add($"[{food.Name}] {addResult.ErrorMessage}");
                }

                string resultMsg = $"Đã thêm {successCount}/{foods.Count} món";
                if (errors.Count > 0)
                    resultMsg += $"\n\nLỗi ({errors.Count} món):\n" + string.Join("\n", errors);

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

            var lines = body.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(x => x.Replace('\u00A0', ' ').Trim())
                            .Where(x => !string.IsNullOrWhiteSpace(x))
                            .ToList();

            // 1) Gom lines thành các record (mỗi record bắt đầu bằng "Tên;...")
            var records = new List<string>();
            var cur = "";

            bool LooksLikeNewRecord(string s)
            {
                int semi = s.IndexOf(';');
                if (semi <= 0) return false;

                var first = s.Substring(0, semi).Trim();

                // tên món thường không phải URL
                if (first.StartsWith("http", StringComparison.OrdinalIgnoreCase)) return false;
                if (first.Contains("://")) return false;
                if (first.StartsWith("www.", StringComparison.OrdinalIgnoreCase)) return false;

                return true;
            }

            foreach (var line in lines)
            {
                if (LooksLikeNewRecord(line))
                {
                    if (!string.IsNullOrWhiteSpace(cur))
                        records.Add(cur);

                    cur = line;
                }
                else
                {
                    // line là phần tiếp của URL / phần tiếp record => nối thẳng (không thêm newline)
                    cur += line;
                }
            }
            if (!string.IsNullOrWhiteSpace(cur))
                records.Add(cur);

            // 2) Parse từng record: Ten;Url;Gia;DiaChi
            foreach (var rec in records)
            {
                var parts = rec.Split(';');

                if (parts.Length < 2) continue;

                string name = parts[0].Trim();
                string url = (parts.Length >= 2) ? parts[1].Trim() : "";
                int price = 0;
                string address = "TP. Hồ Chí Minh";

                if (parts.Length >= 3) price = ParsePrice(parts[2]);
                if (parts.Length >= 4 && !string.IsNullOrWhiteSpace(parts[3])) address = parts[3].Trim();

                url = NormalizeImageUrl(url);

                if (string.IsNullOrWhiteSpace(name)) continue;
                if (string.IsNullOrWhiteSpace(url)) continue;
                if (!url.StartsWith("http://") && !url.StartsWith("https://")) continue;

                foods.Add(new FoodContribution
                {
                    Name = name,
                    ImageUrl = url,
                    Price = price,
                    Address = address
                });
            }

            return foods;
        }

        private int ParsePrice(string raw)
        {
            if (string.IsNullOrWhiteSpace(raw)) return 0;

            var s = raw.Trim().ToLowerInvariant();
            s = s.Replace("vnd", "").Replace("đ", "").Replace("d", "");
            s = s.Replace(",", "").Replace(".", "");
            s = Regex.Replace(s, @"\s+", "");

            return int.TryParse(s, out int p) ? p : 0;
        }


        private string NormalizeImageUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url)) return "";

            url = url.Trim().Trim('<', '>', '"');

            if (url.Contains("/_next/image", StringComparison.OrdinalIgnoreCase))
            {
                var m = Regex.Match(url, @"[?&]url=([^&]+)", RegexOptions.IgnoreCase);
                if (m.Success)
                    url = WebUtility.UrlDecode(m.Groups[1].Value);
            }

            if (url.Contains("bing.com/images/search", StringComparison.OrdinalIgnoreCase))
            {
                var m = Regex.Match(url, @"[?&]mediaurl=([^&]+)", RegexOptions.IgnoreCase);
                if (m.Success)
                    url = WebUtility.UrlDecode(m.Groups[1].Value);
            }

            return url.Trim();
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
