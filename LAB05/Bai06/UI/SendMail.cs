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
    public partial class SendMail : Form
    {

        public SendMail()
        {
            InitializeComponent();

            // Tự điền email đăng nhập
            txtFrom.Text = MainForm.Email;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(txtFrom.Text, txtName.Text);
                mail.To.Add(txtTo.Text);
                mail.Subject = txtSubject.Text;
                mail.Body = rtbContent.Text;
                mail.IsBodyHtml = chkHTML.Checked;

                // Đính kèm file
                if (!string.IsNullOrEmpty(txtBrowse.Text))
                {
                    Attachment att = new Attachment(txtBrowse.Text);
                    mail.Attachments.Add(att);
                }

                SmtpClient smtp = new SmtpClient(
                    MainForm.SMTPHost,
                    MainForm.SMTPPort
                );
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential(
                    MainForm.Email,
                    MainForm.Password
                );

                smtp.Send(mail);
                MessageBox.Show("Gửi mail thành công!");
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
