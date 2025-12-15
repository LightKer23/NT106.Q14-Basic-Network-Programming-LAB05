using MailKit;

namespace Bai02_Bai03
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            txtEmail.Clear();
            txtPsswrd.Clear();
            rdIMAP.Checked = true;
            rdPop3.Checked = false;
            txtEmail.Focus();
        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPsswrd.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng không bỏ trống email và mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!rdIMAP.Checked && !rdPop3.Checked)
            {
                MessageBox.Show("Vui lòng chọn giao thức đọc mail.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnOK.Enabled = false;
            btnCancel.Enabled = false;
            Cursor = Cursors.WaitCursor;

            try
            {
                if (rdIMAP.Checked)
                {
                    using var imap = new MailKit.Net.Imap.ImapClient();
                    await imap.ConnectAsync("imap.gmail.com", 993, true);
                    await imap.AuthenticateAsync(email, password);
                    await imap.DisconnectAsync(true);
                }
                else
                {
                    using var pop3 = new MailKit.Net.Pop3.Pop3Client();
                    await pop3.ConnectAsync("pop.gmail.com", 995, true);
                    await pop3.AuthenticateAsync(email, password);
                    await pop3.DisconnectAsync(true);
                }

                MessageBox.Show("Đăng nhập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                UserInfo user = new UserInfo(email, password);
                MainForm mainForm = new MainForm(rdIMAP.Checked ? MailType.IMAP : MailType.POP3, user);
                mainForm.Show();
                this.Hide();
            }
            catch (MailKit.Security.AuthenticationException)
            {
                MessageBox.Show($"Email hoặc mật khẩu không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnOK.Enabled = true;
                btnCancel.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
