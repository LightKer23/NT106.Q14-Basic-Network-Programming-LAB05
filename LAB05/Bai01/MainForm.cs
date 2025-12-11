using System.Net.Mail;
using System.Security.Authentication;
using System.Text.RegularExpressions;
using MimeKit;

namespace Bai01
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase);
            }
            catch
            {
                return false;
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            btnSend.Enabled = false;

            string from = txtFrom.Text.Trim();
            string to = txtTo.Text.Trim();
            string subject = txtSubject.Text.Trim();
            string body = rtbBody.Text.Trim();
            string password = txtPsswrd.Text.Trim();

            if (string.IsNullOrEmpty(from) || string.IsNullOrEmpty(to) || string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(body) || string.IsNullOrEmpty(password))
            {
                btnSend.Enabled = true;
                MessageBox.Show("Không được bỏ trống các trường", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidEmail(from) || !IsValidEmail(to))
            {
                btnSend.Enabled = true;
                MessageBox.Show("Địa chỉ email không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Tester", from));
            message.To.Add(new MailboxAddress("", to));
            message.Subject = subject;

            message.Body = new TextPart("plain")
            {
                Text = body
            };

            using var client = new MailKit.Net.Smtp.SmtpClient(); // Biến tự giải phóng khi không sử dụng nữa với từ khóa 'using'
            await client.ConnectAsync("smtp.gmail.com", 465, true);

            try
            {

                await client.AuthenticateAsync(from, password);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
                MessageBox.Show("Gửi email thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MailKit.Security.AuthenticationException)
            {
                MessageBox.Show("Email hoặc mật khẩu không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception)
            {
                MessageBox.Show("Gửi email thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                btnSend.Enabled = true;
            }
        }
    }
}
