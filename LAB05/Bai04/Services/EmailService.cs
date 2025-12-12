using System;
using System.Net;
using System.Net.Mail;
using System.Net.Http;
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
            senderEmail = email?.Trim() ?? "";
            senderPassword = (password ?? "").Replace(" ", "").Trim();
        }

        public async Task<bool> SendBookingConfirmationAsync(
            string customerEmail,
            string customerName,
            string movieName,
            string seats,
            int totalAmount,
            string posterUrl,
            string slogan)
        {
            try
            {
                using (var smtp = new SmtpClient(smtpServer, smtpPort))
                {
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential(senderEmail, senderPassword);

                    using (var message = new MailMessage(senderEmail, customerEmail))
                    {
                        message.Subject = $"Xác nhận đặt vé - {movieName}";
                        message.IsBodyHtml = false;

                        message.Body =
        $@"Xin chào {customerName},

Bạn đã đặt vé thành công!

Phim: {movieName}
Ghế: {seats}
Tổng tiền: {totalAmount:N0} VND

{slogan}";

                        await smtp.SendMailAsync(message);
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        private async Task<string> DownloadImageAsBase64(string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(10);
                    var imageBytes = await client.GetByteArrayAsync(url);
                    return Convert.ToBase64String(imageBytes);
                }
            }
            catch
            {
                return null;
            }
        }

        private string CreateEmailBody(
            string customerName,
            string movieName,
            string seats,
            int totalAmount,
            string slogan,
            string posterBase64)
        {
            var posterHtml = string.Empty;
            if (!string.IsNullOrEmpty(posterBase64))
            {
                posterHtml = $@"
                    <div style='text-align: center; margin: 20px 0;'>
                        <img src='data:image/jpeg;base64,{posterBase64}' 
                             alt='Movie Poster' 
                             style='max-width: 300px; height: auto; border-radius: 8px; box-shadow: 0 4px 8px rgba(0,0,0,0.2);'/>
                    </div>";
            }

            return $@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='UTF-8'>
</head>
<body style='font-family: Segoe UI, Arial, sans-serif; background:#f5f5f5; padding:20px;'>
  <div style='max-width:640px;margin:0 auto;background:#fff;border-radius:10px;overflow:hidden;box-shadow:0 4px 12px rgba(0,0,0,0.15)'>
    <div style='background:#4f46e5;color:#fff;padding:24px;text-align:center'>
      <div style='font-size:22px;font-weight:700'>🎬 XÁC NHẬN ĐẶT VÉ</div>
      <div style='opacity:.9;margin-top:6px'>Beta Cinemas</div>
    </div>
    <div style='padding:24px;color:#111'>
      <p>Xin chào <b>{WebUtility.HtmlEncode(customerName)}</b>,</p>
      <p>Cảm ơn bạn đã đặt vé! Thông tin vé của bạn:</p>

      {posterHtml}

      <div style='background:#f8f9fa;border-left:4px solid #4f46e5;border-radius:8px;padding:16px;margin:16px 0'>
        <div style='margin:8px 0'><b>Tên phim:</b> {WebUtility.HtmlEncode(movieName)}</div>
        <div style='margin:8px 0'><b>Ghế:</b> {WebUtility.HtmlEncode(seats)}</div>
        <div style='margin:8px 0'><b>Tổng tiền:</b> <span style='color:#16a34a;font-weight:700'>{totalAmount:N0} VNĐ</span></div>
      </div>

      <div style='text-align:center;font-style:italic;font-weight:700;color:#4f46e5;margin:18px 0'>
        {WebUtility.HtmlEncode(slogan)}
      </div>

      <div style='background:#fff3cd;border-left:4px solid #f59e0b;border-radius:8px;padding:14px;margin-top:18px'>
        <b>⚠️ Lưu ý:</b>
        <ul style='margin:8px 0 0 18px'>
          <li>Đến rạp trước giờ chiếu <b>15 phút</b></li>
          <li>Xuất trình email này khi nhận vé</li>
        </ul>
      </div>

      <div style='text-align:center;color:#666;margin-top:18px;font-size:12px'>
        Email tự động, vui lòng không trả lời.
      </div>
    </div>
  </div>
</body>
</html>";
        }
    }
}
