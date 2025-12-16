using System;
using System.Linq;
using System.Windows.Forms;
using MailKit;
using MailKit.Net.Imap;
using MimeKit;

namespace Bai06.UI
{
    public partial class ReadMailForm : Form
    {
        private readonly int _messageIndex;
        private MimeMessage _message;

        public ReadMailForm(int messageIndex)
        {
            InitializeComponent();
            _messageIndex = messageIndex;

            this.Load += ReadMailForm_Load;

        }
        private void AutoFitWidth(TextBox tb)
        {
            int w = TextRenderer.MeasureText(tb.Text, tb.Font).Width + 20;
            int maxW = this.ClientSize.Width - tb.Left - 20;
            tb.Width = Math.Min(w, maxW);
        }
        private void ReadMailForm_Load(object sender, EventArgs e)
        {
            ImapClient client = new ImapClient();
            try
            {
                client.Connect(MainForm.IMAPHost, MainForm.IMAPPort, true);
                client.Authenticate(MainForm.Email, MainForm.Password);

                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadOnly);

                _message = inbox.GetMessage(_messageIndex);

                txtFrom.Text = _message.From?.ToString() ?? "";
                AutoFitWidth(txtFrom);

                txtTo.Text = _message.To?.ToString() ?? "";
                AutoFitWidth(txtTo);
                txtSubject.Text = _message.Subject ?? "";
                txtDate.Text = _message.Date.DateTime.ToString("dd/MM/yyyy HH:mm");

                var body = _message.TextBody;
                if (string.IsNullOrWhiteSpace(body)) body = _message.HtmlBody;
                rtbBody.Text = body ?? "(No body)";

                lstAttachments.Items.Clear();
                foreach (var att in _message.Attachments)
                {
                    if (att is MimePart part) lstAttachments.Items.Add(part.FileName ?? "attachment");
                    else lstAttachments.Items.Add("attachment");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đọc email!\n" + ex.Message);
                Close();
            }
            finally
            {
                try { if (client.IsConnected) client.Disconnect(true); } catch { }
                client.Dispose();
            }
        
        }

        private void btnReply_Click(object sender, EventArgs e)
        {
            if (_message == null) return;

            string to = _message.From.Mailboxes.FirstOrDefault()?.Address ?? "";
            string subject = "Re: " + (_message.Subject ?? "");
            string quote = _message.TextBody ?? _message.HtmlBody ?? "";
            string body = "\r\n\r\n---- Original ----\r\n" + quote;

            new SendMail(to, subject, body).Show();
        }

        private void btnSaveAtt_Click(object sender, EventArgs e)
        {
            if (_message == null) return;
            if (lstAttachments.SelectedIndex < 0) return;

            var attEntity = _message.Attachments.ElementAt(lstAttachments.SelectedIndex);
            if (attEntity is not MimePart part) return;

            using SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = part.FileName ?? "attachment";
            if (dlg.ShowDialog() != DialogResult.OK) return;

            using var stream = System.IO.File.Create(dlg.FileName);
            part.Content.DecodeTo(stream);

            MessageBox.Show("Đã lưu: " + dlg.FileName);
        }
    }
}

