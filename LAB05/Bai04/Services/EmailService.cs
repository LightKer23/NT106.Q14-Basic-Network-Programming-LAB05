using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Bai04.Services
{
    public class EmailService
    {
        private readonly string smtpServer;
        private readonly int smtpPort;
        private readonly string senderEmail;
        private readonly string senderPassword;

        public string LastError { get; private set; } = "";

        public EmailService(string server, int port, string email, string password)
        {
            smtpServer = server;
            smtpPort = port;
            senderEmail = email;
            senderPassword = (password ?? "").Replace(" ", ""); 
        }

        public async Task<bool> SendBookingConfirmationAsync(
            string customerEmail,
            string customerName,
            string movieName,
            int room,
            string seats,
            int totalAmount,
            byte[]? posterBytes,
            string slogan)
        {
            try
            {
                LastError = "";

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                using (var smtp = new SmtpClient(smtpServer, smtpPort))
                {
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(senderEmail, senderPassword);
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Timeout = 15000;

                    using (var message = new MailMessage())
                    {
                        message.From = new MailAddress(senderEmail, "Chill Cinemas");
                        message.To.Add(customerEmail);

                        message.SubjectEncoding = Encoding.UTF8;
                        message.BodyEncoding = Encoding.UTF8;

                        message.Subject = $"Xác nhận đặt vé - {movieName}";

                        string html =
$@"
<div style='font-family:Arial; font-size:14px; line-height:1.4;'>
  <b>XÁC NHẬN ĐẶT VÉ</b><br/><br/>

  {(posterBytes != null && posterBytes.Length > 0
    ? "<img src='cid:poster' style='max-width:420px; width:100%;' /><br/><br/>"
    : "")}

  Xin chào <b>{WebUtility.HtmlEncode(customerName)}</b>,<br/>
  Đây là thông tin vé của bạn:<br/><br/>

  <b>Tên phim:</b> {WebUtility.HtmlEncode(movieName)}<br/>
  <b>Phòng:</b> {room}<br/>
  <b>Ghế:</b> {WebUtility.HtmlEncode(seats)}<br/>
  <b>Tổng tiền:</b> {totalAmount:N0} VND<br/><br/>

  <i>{WebUtility.HtmlEncode(slogan)}</i><br/><br/>
  <small>Email tự động, vui lòng không trả lời.</small>
</div>";

                        var htmlView = AlternateView.CreateAlternateViewFromString(
                            html, Encoding.UTF8, MediaTypeNames.Text.Html
                        );

                        if (posterBytes != null && posterBytes.Length > 0)
                        {
                            var ms = new MemoryStream(posterBytes);
                            var poster = new LinkedResource(ms, MediaTypeNames.Image.Jpeg);
                            poster.ContentId = "poster";
                            poster.TransferEncoding = TransferEncoding.Base64;
                            htmlView.LinkedResources.Add(poster);
                        }

                        message.AlternateViews.Add(htmlView);
                        message.IsBodyHtml = true;

                        await smtp.SendMailAsync(message);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                return false;
            }
        }
    }
}
