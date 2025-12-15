using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailKit.Net.Imap;
using MailKit;
using MimeKit;


namespace Bai06.UI
{
    public partial class MainForm : Form
    {
        public static string Email;
        public static string Password;
        public static string SMTPHost;
        public static int SMTPPort;

        public MainForm()
        {
            InitializeComponent();

            // Gợi ý sẵn cho Gmail
            txtIMAP.Text = "imap.gmail.com";
            txtPortIMAP.Text = "993";

            txtSMTP.Text = "smtp.gmail.com";
            txtPortSMTP.Text = "587";


            btnSendMail.Visible = false;
            btnRefresh.Visible = false;
            btnLogout.Visible = false;

        }



        private void LoadEmail()
        {
            lstEmail.Items.Clear();


            using (ImapClient client = new ImapClient())
            {
                client.Connect(txtIMAP.Text, int.Parse(txtPortIMAP.Text), true);
                client.Authenticate(txtUsername.Text, txtPassword.Text);

                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadOnly);

                int count = inbox.Count;
                int stt = 1;

                // Lấy 10 mail mới nhất
                for (int i = count - 1; i >= Math.Max(0, count - 10); i--)
                {
                    MimeMessage message = inbox.GetMessage(i);

                    ListViewItem item = new ListViewItem(stt.ToString());
                    item.SubItems.Add(message.Subject);
                    item.SubItems.Add(message.From.ToString());
                    item.SubItems.Add(message.Date.DateTime.ToString("dd/MM/yyyy HH:mm"));

                    // Lưu message index để đọc chi tiết sau này
                    item.Tag = i;

                    lstEmail.Items.Add(item);
                    stt++;
                }

                client.Disconnect(true);
            }
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            Email = txtUsername.Text.Trim();
            Password = txtPassword.Text.Trim();
            SMTPHost = txtSMTP.Text.Trim();
            SMTPPort = int.Parse(txtPortSMTP.Text);

            try
            {
                SmtpClient smtp = new SmtpClient(SMTPHost, SMTPPort);
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential(Email, Password);

                smtp.Send(Email, Email, "Test Login", "Login Success");

                MessageBox.Show("Đăng nhập thành công!");

                btnSendMail.Visible = true;
                btnRefresh.Visible = true;
                btnLogout.Visible = true;
                btnLogin.Visible = false;

                txtUsername.Enabled = false;
                txtPassword.Enabled = false;

                groupBox2.Enabled = false;

                LoadEmail();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Đăng nhập thất bại!\n" + ex.Message);
            }
        }

        private void btnSendMail_Click(object sender, EventArgs e)
        {
            SendMail A = new SendMail();
            A.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadEmail();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            btnSendMail.Visible = false;
            btnRefresh.Visible = false;
            btnLogout.Visible = false;
            btnLogin.Visible = true;

            groupBox2.Enabled=true;

            txtUsername.Enabled = true;
            txtPassword.Enabled = true;
            txtPassword.Clear();

            lstEmail.Items.Clear();

            MessageBox.Show("Đã đăng xuất");

        }
    }
}
