using Bai05.Models;
using Bai05.Services;
using Bai05.Utils;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bai05
{
    public partial class MainForm : Form
    {
        private FoodService _foodService;
        private List<FoodItem> _allFoods;
        private FoodItem? _currentDish;

        public MainForm()
        {
            InitializeComponent();
            _foodService = Program.foodSer;
            _allFoods = new List<FoodItem>();
            UpdateUserInfo();
            LoadAllFoods();
        }

        private void UpdateUserInfo()
        {
            if (CurrentUser.IsLoggedIn && CurrentUser.User != null)
            {
                lblWelcome.Text = $"Xin chào, {CurrentUser.User.first_name} {CurrentUser.User.last_name}!";
            }
            else
            {
                lblWelcome.Text = "Xin chào!";
            }
        }

        private async void LoadAllFoods()
        {
            try
            {
                lblStatus.Text = "Đang tải danh sách món ăn...";
                progressBar1.Style = ProgressBarStyle.Marquee;
                btnRandomDish.Enabled = false;
                btnManageEmail.Enabled = false;
                btnViewAllDishes.Enabled = false;
                btnRefresh.Enabled = false;

                // Tải tất cả món ăn từ API (không phân trang)
                var result = await _foodService.GetAllFoodsNoPagingAsync(50);

                if (result.Success && result.Data != null)
                {
                    _allFoods = result.Data;
                    lblStatus.Text = $"Đã tải {_allFoods.Count} món ăn từ cộng đồng";

                    if (_allFoods.Count > 0)
                    {
                        LoadRandomDish();
                    }
                    else
                    {
                        ShowNoDishMessage();
                    }
                }
                else
                {
                    lblStatus.Text = "Lỗi tải dữ liệu";
                    MessageBox.Show("Không thể tải danh sách món ăn từ server!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ShowNoDishMessage();
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Lỗi: " + ex.Message;
                MessageBox.Show($"Lỗi kết nối server:\n{ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ShowNoDishMessage();
            }
            finally
            {
                progressBar1.Style = ProgressBarStyle.Blocks;
                btnRandomDish.Enabled = true;
                btnManageEmail.Enabled = true;
                btnViewAllDishes.Enabled = true;
                btnRefresh.Enabled = true;
            }
        }

        private void ShowNoDishMessage()
        {
            lblDishName.Text = "Chưa có món ăn nào";
            lblContributor.Text = "Vui lòng tải đóng góp từ email hoặc thêm món ăn mới";
            lblPrice.Text = "";
            lblAddress.Text = "";
            pictureBoxDish.Image = null;
            pictureBoxDish.BackColor = Color.LightGray;
        }

        private void LoadRandomDish()
        {
            if (_allFoods == null || _allFoods.Count == 0)
            {
                ShowNoDishMessage();
                return;
            }

            // Chọn ngẫu nhiên
            var random = new Random();
            int index = random.Next(_allFoods.Count);
            _currentDish = _allFoods[index];

            // Hiển thị thông tin
            lblDishName.Text = _currentDish.ten_mon_an ?? "N/A";
            lblContributor.Text = $"👤 Người đóng góp: {_currentDish.nguoi_dong_gop ?? "Ẩn danh"}";
            lblPrice.Text = _currentDish.gia > 0 ? $"💰 Giá: {_currentDish.gia:N0}đ" : "";
            lblAddress.Text = !string.IsNullOrEmpty(_currentDish.dia_chi) ? $"📍 Địa chỉ: {_currentDish.dia_chi}" : "";

            // Load hình ảnh
            LoadDishImage(_currentDish.hinh_anh);

            lblStatus.Text = $"Hiển thị món: {_currentDish.ten_mon_an}";
        }

        private async void LoadDishImage(string? imageUrl)
        {
            if (string.IsNullOrEmpty(imageUrl))
            {
                pictureBoxDish.Image = null;
                pictureBoxDish.BackColor = Color.LightGray;
                return;
            }

            try
            {
                // Nếu là URL
                if (imageUrl.StartsWith("http://") || imageUrl.StartsWith("https://"))
                {
                    using var httpClient = new HttpClient();
                    httpClient.Timeout = TimeSpan.FromSeconds(10);

                    var imageBytes = await httpClient.GetByteArrayAsync(imageUrl);

                    using var ms = new MemoryStream(imageBytes);
                    pictureBoxDish.Image = Image.FromStream(ms);
                    pictureBoxDish.BackColor = Color.White;
                }
                // Nếu là đường dẫn local
                else if (File.Exists(imageUrl))
                {
                    pictureBoxDish.Image = Image.FromFile(imageUrl);
                    pictureBoxDish.BackColor = Color.White;
                }
                else
                {
                    pictureBoxDish.Image = null;
                    pictureBoxDish.BackColor = Color.LightGray;
                }
            }
            catch
            {
                pictureBoxDish.Image = null;
                pictureBoxDish.BackColor = Color.LightGray;
            }
        }

        private void btnRandomDish_Click(object sender, EventArgs e)
        {
            if (_allFoods != null && _allFoods.Count > 0)
            {
                LoadRandomDish();
            }
            else
            {
                MessageBox.Show("Không có món ăn nào để chọn!\nVui lòng tải đóng góp từ email hoặc làm mới danh sách.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnManageEmail_Click(object sender, EventArgs e)
        {
            if (!CurrentUser.IsLoggedIn)
            {
                MessageBox.Show("Bạn cần đăng nhập để sử dụng tính năng này!",
                    "Yêu cầu đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var emailForm = new EmailContributionForm();
            emailForm.ShowDialog();

            // Reload danh sách sau khi đóng form email
            lblStatus.Text = "Đang làm mới danh sách...";
            LoadAllFoods();
        }

        private async void btnViewAllDishes_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Đang tải danh sách...";
                progressBar1.Style = ProgressBarStyle.Marquee;

                var result = await _foodService.GetAllFoodsAsync(1, 50);

                progressBar1.Style = ProgressBarStyle.Blocks;

                if (!result.Success || result.Data == null || result.Data.data.Count == 0)
                {
                    MessageBox.Show("Không có món ăn nào trong hệ thống!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblStatus.Text = "Không có món ăn";
                    return;
                }

                // Hiển thị danh sách trong form mới hoặc MessageBox
                var message = new System.Text.StringBuilder();
                message.AppendLine($"╔══════════════════════════════════════════╗");
                message.AppendLine($"║  DANH SÁCH MÓN ĂN ({result.Data.pagination?.total ?? 0} món)");
                message.AppendLine($"╚══════════════════════════════════════════╝");
                message.AppendLine();

                int count = 1;
                foreach (var dish in result.Data.data.Take(20)) // Chỉ hiển thị 20 món đầu
                {
                    message.AppendLine($"{count}. {dish.ten_mon_an}");
                    message.AppendLine($"   💰 Giá: {dish.gia:N0}đ");
                    if (!string.IsNullOrEmpty(dish.dia_chi))
                        message.AppendLine($"   📍 {dish.dia_chi}");
                    message.AppendLine($"   👤 {dish.nguoi_dong_gop ?? "Ẩn danh"}");
                    message.AppendLine();
                    count++;
                }

                if (result.Data.data.Count > 20)
                {
                    message.AppendLine($"... và {result.Data.data.Count - 20} món khác");
                }

                lblStatus.Text = "Sẵn sàng";

                MessageBox.Show(message.ToString(), "Danh sách món ăn",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                progressBar1.Style = ProgressBarStyle.Blocks;
                lblStatus.Text = "Lỗi tải danh sách";
                MessageBox.Show($"Lỗi: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Đang làm mới...";
            LoadAllFoods();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc muốn đăng xuất?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Clear user data
                CurrentUser.ClearUser();

                // Show LoginForm
                var loginForm = new LoginForm();
                loginForm.Show();

                // Close MainForm
                this.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc muốn thoát ứng dụng?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Nếu đóng bằng X
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var result = MessageBox.Show("Bạn có muốn đăng xuất không?",
                    "Xác nhận",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Đăng xuất và về LoginForm
                    CurrentUser.ClearUser();
                    var loginForm = new LoginForm();
                    loginForm.Show();
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true; // Hủy đóng form
                }
                // DialogResult.No -> Chỉ đóng form, không logout
            }
        }
    }
}