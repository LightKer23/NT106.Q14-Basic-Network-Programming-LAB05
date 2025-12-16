using MailKit;
using MailKit.Net.Imap;
using MailKit.Security;
using MimeKit;
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


namespace Bai06.UI
{
    public partial class MainForm : Form
    {
        public static string Email;
        public static string Password;
        public static string SMTPHost;
        public static int SMTPPort;
        public static string IMAPHost; 
        public static int IMAPPort = 993;
        public MainForm()
        {
            InitializeComponent();

            txtIMAP.Text = "imap.gmail.com";
            txtPortIMAP.Text = "993";

            txtSMTP.Text = "smtp.gmail.com";
            txtPortSMTP.Text = "465";


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

                IMailFolder inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadOnly);

                int count = inbox.Count;

                IList<IMessageSummary> summaries =
                    inbox.Fetch(0, count - 1, MessageSummaryItems.Envelope | MessageSummaryItems.InternalDate);

                int stt = 1;
                for (int k = summaries.Count - 1; k >= 0; k--)
                {
                    IMessageSummary s = summaries[k];

                    string subject = (s.Envelope != null && s.Envelope.Subject != null) ? s.Envelope.Subject : "";
                    string from = (s.Envelope != null && s.Envelope.From != null) ? s.Envelope.From.ToString() : "";
                    DateTime dt = (s.InternalDate.HasValue) ? s.InternalDate.Value.DateTime : DateTime.MinValue;

                    ListViewItem item = new ListViewItem(stt.ToString());
                    item.SubItems.Add(subject);
                    item.SubItems.Add(from);
                    item.SubItems.Add(dt.ToString("dd/MM/yyyy HH:mm"));

                    item.Tag = s.Index;

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
            IMAPHost = txtIMAP.Text.Trim();
            IMAPPort = int.Parse(txtPortIMAP.Text);


            try
            {
                LoadEmail();

                MessageBox.Show("Đăng nhập thành công!");

                btnSendMail.Visible = true;
                btnRefresh.Visible = true;
                btnLogout.Visible = true;
                btnLogin.Visible = false;

                txtUsername.Enabled = false;
                txtPassword.Enabled = false;

                groupBox2.Enabled = false;


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
        private void lstEmail_DoubleClick(object sender, EventArgs e)
        {
            if (lstEmail.SelectedItems.Count == 0) return;
            int index = (int)lstEmail.SelectedItems[0].Tag;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                this.UseWaitCursor = true;
                Application.DoEvents(); 
                ReadMailForm frm = new ReadMailForm(index);
                frm.Shown += (s, args) =>
                {
                    this.UseWaitCursor = false;
                    Cursor.Current = Cursors.Default;
                };

                frm.Show();
            }
            catch
            {
                this.UseWaitCursor = false;
                Cursor.Current = Cursors.Default;
                throw;
            }
        }

    }
}
