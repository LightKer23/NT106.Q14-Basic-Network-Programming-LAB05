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
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace Bai06.UI
{
    public partial class SendMail : Form
    {

        public SendMail()
        {
            InitializeComponent();

            txtFrom.Text = MainForm.Email;
        }
        public SendMail(string to, string subject, string body) : this()
        {
            txtTo.Text = to;
            txtSubject.Text = subject;
            rtbContent.Text = body;
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                MimeMessage mail = new MimeMessage();
                mail.From.Add(new MailboxAddress(txtName.Text, txtFrom.Text));
                mail.To.Add(MailboxAddress.Parse(txtTo.Text));
                mail.Subject = txtSubject.Text;

                BodyBuilder builder = new BodyBuilder();

                if (chkHTML.Checked)
                    builder.HtmlBody = rtbContent.Text;
                else
                    builder.TextBody = rtbContent.Text;

                if (!string.IsNullOrEmpty(txtBrowse.Text))
                {
                    builder.Attachments.Add(txtBrowse.Text);
                }

                mail.Body = builder.ToMessageBody();

                MailKit.Net.Smtp.SmtpClient smtp = new MailKit.Net.Smtp.SmtpClient();
                try
                {
                    smtp.Connect(MainForm.SMTPHost, MainForm.SMTPPort, SecureSocketOptions.SslOnConnect);
                    smtp.AuthenticationMechanisms.Remove("XOAUTH2");
                    smtp.Authenticate(MainForm.Email, MainForm.Password);

                    smtp.Send(mail);
                    smtp.Disconnect(true);
                }
                finally
                {
                    smtp.Dispose();
                }

                MessageBox.Show("Gửi mail thành công!");

                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi mail!\n" + ex.Message);
            }
        }


        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtBrowse.Text = dlg.FileName;
            }
        }
    }
}
