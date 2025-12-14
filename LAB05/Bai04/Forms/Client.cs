using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bai04.Data;
using Bai04.Services;

namespace Bai04
{
    public partial class Client : Form
    {
        private Movie? currentMovie;
        private int currentBasePrice = 0;
        private int currentRoom = 0;

        private readonly List<Button> seatButtons = new List<Button>();
        private readonly HashSet<string> selectedSeats = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        private readonly Dictionary<(string movieTitle, int room), HashSet<string>> soldSeatsByShow
            = new Dictionary<(string, int), HashSet<string>>();

        private EmailService? emailService;

        public Client()
        {
            InitializeComponent();

            chooseFilm.Click += ChooseFilm_Click;

            seatButtons.Add(A1); seatButtons.Add(A2); seatButtons.Add(A3); seatButtons.Add(A4); seatButtons.Add(A5);
            seatButtons.Add(B1); seatButtons.Add(B2); seatButtons.Add(B3); seatButtons.Add(B4); seatButtons.Add(B5);
            seatButtons.Add(C1); seatButtons.Add(C2); seatButtons.Add(C3); seatButtons.Add(C4); seatButtons.Add(C5);

            foreach (var btn in seatButtons)
                btn.Tag = btn.BackColor;

            DisableSeatsAndBooking();
            InitializeEmailService();
        }

        private void InitializeEmailService()
        {
            emailService = new EmailService(
                server: "smtp.gmail.com",
                port: 587,
                email: "testchill26@gmail.com",
                password: "agpa qasd qbcv cple"
            );
        }

        private void DisableSeatsAndBooking()
        {
            RoomComboBox.Enabled = false;
            BookButton.Enabled = false;

            selectedSeats.Clear();
            Total.Text = "0";

            foreach (var btn in seatButtons)
            {
                btn.Enabled = false;
                btn.BackColor = (Color)btn.Tag;
            }
        }

        private async void ChooseFilm_Click(object? sender, EventArgs e)
        {
            using var f = new Bai04.Forms.loadMovie();
            if (f.ShowDialog(this) == DialogResult.OK && f.SelectedMovie != null)
            {
                await ApplySelectedMovieAsync(f.SelectedMovie);
            }
        }

        private async Task ApplySelectedMovieAsync(Movie mv)
        {
            currentMovie = mv;

            label8.Text = mv.Title ?? "";
            label8.Visible = true;
            await LoadPosterIntoPictureBoxAsync(mv.PosterUrl);

            currentBasePrice = GetBasePriceForMovie(mv.Title);

            RoomComboBox.Items.Clear();
            RoomComboBox.Items.Add(1);
            RoomComboBox.Items.Add(2);
            RoomComboBox.Items.Add(3);
            RoomComboBox.Enabled = true;

            if (RoomComboBox.Items.Count > 0)
                RoomComboBox.SelectedIndex = 0;

            BookButton.Enabled = true;
        }

        private static int GetBasePriceForMovie(string? title)
        {
            int basePrice = 100_000;

            if (string.IsNullOrWhiteSpace(title))
                return basePrice;

            string t = title.Trim().ToLowerInvariant();
            if (t.Contains("imax")) return 140_000;
            if (t.Contains("3d")) return 120_000;

            return basePrice;
        }

        private static async Task<Image?> DownloadImageAsync(string? url)
        {
            if (string.IsNullOrWhiteSpace(url)) return null;

            try
            {
                using var http = new HttpClient();
                http.Timeout = TimeSpan.FromSeconds(10);

                var bytes = await http.GetByteArrayAsync(url);
                using var ms = new MemoryStream(bytes);
                return Image.FromStream(ms);
            }
            catch
            {
                return null;
            }
        }

        private async Task LoadPosterIntoPictureBoxAsync(string? posterUrl)
        {
            poster.Image = null;

            var img = await DownloadImageAsync(posterUrl);
            if (img != null)
                poster.Image = img;
        }

        private async void RoomComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentMovie == null || RoomComboBox.SelectedItem == null)
            {
                DisableSeatsAndBooking();
                return;
            }

            currentRoom = (int)RoomComboBox.SelectedItem;
            await RefreshSeatsLocalAsync();
        }

        private Task RefreshSeatsLocalAsync()
        {
            selectedSeats.Clear();
            Total.Text = "0";

            foreach (var btn in seatButtons)
            {
                btn.Enabled = true;
                btn.BackColor = (Color)btn.Tag;
            }

            if (currentMovie == null || currentRoom == 0)
            {
                foreach (var btn in seatButtons)
                {
                    btn.Enabled = false;
                    btn.BackColor = (Color)btn.Tag;
                }
                return Task.CompletedTask;
            }

            var key = (NormalizeMovieKey(currentMovie.Title), currentRoom);
            if (!soldSeatsByShow.TryGetValue(key, out var sold))
            {
                sold = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                soldSeatsByShow[key] = sold;
            }

            foreach (var btn in seatButtons)
            {
                string seatName = btn.Text.Trim().ToUpperInvariant();
                if (sold.Contains(seatName))
                {
                    btn.Enabled = false;
                    btn.BackColor = Color.LightGray;
                }
            }

            return Task.CompletedTask;
        }

        private void SeatButton_Click(object sender, EventArgs e)
        {
            if (currentMovie == null || currentRoom == 0)
            {
                MessageBox.Show("Vui lòng chọn phim và phòng trước khi chọn ghế.");
                return;
            }

            if (sender is not Button btn) return;
            if (!btn.Enabled) return;

            string seatName = btn.Text.Trim().ToUpperInvariant();

            if (selectedSeats.Contains(seatName))
            {
                selectedSeats.Remove(seatName);
                btn.BackColor = (Color)btn.Tag;
            }
            else
            {
                selectedSeats.Add(seatName);
                btn.BackColor = Color.LightGreen;
            }

            Total.Text = selectedSeats.Sum(CalculateSeatPrice).ToString();
        }

        private async void BookButton_Click(object sender, EventArgs e)
        {
            if (currentMovie == null || currentRoom == 0)
            {
                MessageBox.Show("Vui lòng chọn phim và phòng.");
                return;
            }

            if (selectedSeats.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một ghế.");
                return;
            }

            string customerName = CustomerNameBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(customerName))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng.");
                return;
            }

            string customerEmail = emailBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(customerEmail))
            {
                MessageBox.Show("Vui lòng nhập email để nhận xác nhận vé.");
                return;
            }

            if (!IsValidEmail(customerEmail))
            {
                MessageBox.Show("Email không hợp lệ! Vui lòng nhập lại.");
                return;
            }

            var seatsJustBooked = selectedSeats.ToList();
            string seatsCsv = string.Join(", ", seatsJustBooked.OrderBy(s => s));
            int totalAmount = seatsJustBooked.Sum(CalculateSeatPrice);

            var showKey = (NormalizeMovieKey(currentMovie.Title), currentRoom);
            if (!soldSeatsByShow.TryGetValue(showKey, out var sold))
            {
                sold = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                soldSeatsByShow[showKey] = sold;
            }

            foreach (var s in seatsJustBooked)
            {
                if (sold.Contains(s))
                {
                    MessageBox.Show($"Ghế {s} đã được đặt trước đó. Vui lòng chọn ghế khác.");
                    await RefreshSeatsLocalAsync();
                    return;
                }
            }

            foreach (var s in seatsJustBooked)
                sold.Add(s);

            BookButton.Enabled = false;
            var oldText = BookButton.Text;
            BookButton.Text = "Đang gửi email...";

            bool emailSent = await SendConfirmationEmail(
                customerEmail: customerEmail,
                customerName: customerName,
                movieName: currentMovie.Title ?? "",
                room: currentRoom,
                seats: seatsCsv,
                totalAmount: totalAmount,
                posterUrl: currentMovie.PosterUrl ?? ""
            );

            BookButton.Text = oldText;
            BookButton.Enabled = true;

            selectedSeats.Clear();
            Total.Text = "0";
            await RefreshSeatsLocalAsync();

            string msg =
                "Đặt vé thành công!\n\n" +
                $"Khách hàng: {customerName}\n" +
                $"Email: {customerEmail}\n" +
                $"Phim: {currentMovie.Title}\n" +
                $"Phòng số: {currentRoom}\n" +
                $"Ghế: {seatsCsv}\n" +
                $"Tổng tiền: {totalAmount:N0} VNĐ\n\n" +
                (emailSent
                    ? "Email xác nhận đã được gửi!"
                    : "Không thể gửi email xác nhận (kiểm tra cấu hình email).");

            if (!emailSent && emailService != null && !string.IsNullOrWhiteSpace(emailService.LastError))
            {
                msg += "\n\nLỗi SMTP: " + emailService.LastError;
            }

            MessageBox.Show(
                msg,
                "Thông báo",
                MessageBoxButtons.OK,
                emailSent ? MessageBoxIcon.Information : MessageBoxIcon.Warning
            );

            if (!emailSent)
            {
                MessageBox.Show(emailService?.LastError ?? "LastError is null", "SMTP ERROR");
            }

        }

        private static string NormalizeMovieKey(string? title)
            => (title ?? "").Trim().ToUpperInvariant();

        private int CalculateSeatPrice(string seat)
        {
            seat = (seat ?? "").Trim().ToUpperInvariant();
            double factor;

            if (seat == "A1" || seat == "A5" || seat == "C1" || seat == "C5")
            {
                factor = 0.25;
            }
            else if (seat == "B2" || seat == "B3" || seat == "B4")
            {
                factor = 2.0;
            }
            else
            {
                factor = 1.0;
            }

            return (int)(currentBasePrice * factor);
        }

        private static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                const string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                return Regex.IsMatch(email, pattern);
            }
            catch
            {
                return false;
            }
        }

        private byte[]? GetPosterBytes()
        {
            try
            {
                if (poster.Image == null) return null;
                using (var ms = new MemoryStream())
                {
                    poster.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    return ms.ToArray();
                }
            }
            catch
            {
                return null;
            }
        }

        private static async Task<byte[]?> DownloadBytesAsync(string? url)
        {
            if (string.IsNullOrWhiteSpace(url)) return null;
            try
            {
                using var http = new HttpClient();
                http.Timeout = TimeSpan.FromSeconds(10);
                return await http.GetByteArrayAsync(url);
            }
            catch
            {
                return null;
            }
        }

        private async Task<bool> SendConfirmationEmail(
            string customerEmail,
            string customerName,
            string movieName,
            int room,
            string seats,
            int totalAmount,
            string posterUrl)
        {
            try
            {
                if (emailService == null) return false;

                byte[]? posterBytes = GetPosterBytes();

                if ((posterBytes == null || posterBytes.Length == 0) && !string.IsNullOrWhiteSpace(posterUrl))
                {
                    posterBytes = await DownloadBytesAsync(posterUrl);
                }

                return await emailService.SendBookingConfirmationAsync(
                    customerEmail: customerEmail,
                    customerName: customerName,
                    movieName: movieName,
                    room: room,
                    seats: seats,
                    totalAmount: totalAmount,
                    posterBytes: posterBytes,
                    slogan: "Chúc bạn xem phim vui vẻ!"
                );
            }
            catch
            {
                return false;
            }
        }
    }
}
