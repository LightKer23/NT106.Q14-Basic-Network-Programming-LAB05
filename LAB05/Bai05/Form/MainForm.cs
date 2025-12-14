using Bai05.Models;
using Bai05.Services;
using Bai05.Utils;
using Bai05.User_Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai05
{
    public partial class MainForm : Form
    {
        private int _pageSize = 6;
        private int _currentPage = 1;
        private int _totalPages = 1;
        private bool _isUpdatingPageCombo = false;
        private List<FoodItem>? _cacheAllFoods = null;

        private readonly FoodService _foodService;

        public MainForm()
        {
            InitializeComponent();
            _foodService = Program.foodSer;
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            cboPageSize.Items.AddRange(new object[] { 6, 12, 18, 24 });
            cboPageSize.SelectedItem = 6;

            await LoadAllFoodsAsync();
        }

        private async Task LoadAllFoodsAsync()
        {
            toolStripProgressBar.Style = ProgressBarStyle.Marquee;
            tsslStatus.Text = "Đang tải món ăn...";

            var result = await _foodService.GetAllFoodsAsync(_currentPage, _pageSize);

            toolStripProgressBar.Style = ProgressBarStyle.Blocks;

            if (!result.Success || result.Data == null)
            {
                MessageBox.Show(
                    result.ErrorMessage ?? "Không tải được dữ liệu món ăn",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                tsslStatus.Text = "Sẵn sàng";
                return;
            }

            var data = result.Data;
            var pagination = data.pagination;

            if (pagination != null)
            {
                var size = pagination.pageSize > 0 ? pagination.pageSize : _pageSize;
                _totalPages = size > 0 ? (int)Math.Ceiling(pagination.total / (double)size) : 1;
                tsslStatus.Text = $"Tổng: {pagination.total} món | Trang {_currentPage}/{_totalPages}";
            }
            else
            {
                _totalPages = 1;
                tsslStatus.Text = "Sẵn sàng";
            }

            UpdatePageCombo();
            RenderFoodCards(data.data ?? new List<FoodItem>());
        }

        private void RenderFoodCards(List<FoodItem> items)
        {
            foreach (Control c in flpFoods.Controls)
                c.Dispose();

            flpFoods.Controls.Clear();

            if (items.Count == 0)
            {
                var lblEmpty = new Label
                {
                    Text = "Chưa có món ăn nào.\nHãy thêm món mới hoặc tải từ email!",
                    TextAlign = ContentAlignment.MiddleCenter,
                    AutoSize = false,
                    Width = flpFoods.Width - 20,
                    Height = 200,
                    Font = new Font("Segoe UI", 14, FontStyle.Italic),
                    ForeColor = Color.Gray
                };
                flpFoods.Controls.Add(lblEmpty);
                return;
            }

            foreach (var food in items)
            {
                var card = new FoodItemControl();
                card.SetData(food);

                if (food.nguoi_dong_gop == CurrentUser.User?.email)
                {
                    card.ShowDeleteButton = true;
                    card.OnDeleteClick += Card_OnDeleteClick;
                }

                flpFoods.Controls.Add(card);
            }
        }

        private void UpdatePageCombo()
        {
            _isUpdatingPageCombo = true;
            try
            {
                cboPage.Items.Clear();

                if (_totalPages <= 0)
                {
                    cboPage.Enabled = false;
                    cboPage.Text = "0";
                    btnPrevPage.Enabled = false;
                    btnNextPage.Enabled = false;
                    return;
                }

                cboPage.Enabled = true;

                for (int i = 1; i <= _totalPages; i++)
                    cboPage.Items.Add(i);

                if (_currentPage >= 1 && _currentPage <= _totalPages)
                    cboPage.SelectedItem = _currentPage;
                else
                    cboPage.SelectedIndex = 0;

                btnPrevPage.Enabled = _currentPage > 1;
                btnNextPage.Enabled = _currentPage < _totalPages;
            }
            finally
            {
                _isUpdatingPageCombo = false;
            }
        }

        private async void cboPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isUpdatingPageCombo) return;
            if (cboPage.SelectedItem == null) return;

            _currentPage = (int)cboPage.SelectedItem;
            await LoadAllFoodsAsync();
        }

        private async void cboPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPageSize.SelectedItem == null) return;

            _pageSize = (int)cboPageSize.SelectedItem;
            _currentPage = 1;
            await LoadAllFoodsAsync();
        }

        private async void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                await LoadAllFoodsAsync();
            }
        }

        private async void btnNextPage_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                await LoadAllFoodsAsync();
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            using (var frm = new AddDishForm())
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    _currentPage = 1;
                    _cacheAllFoods = null;
                    await LoadAllFoodsAsync();                }
            }
        }

        private async void btnLoadFromEmail_Click(object sender, EventArgs e)
        {
            using (var frm = new EmailContributionForm())
            {
                var result = frm.ShowDialog(this);

                if (result == DialogResult.OK)
                {
                    _currentPage = 1;
                    _cacheAllFoods = null;
                    await LoadAllFoodsAsync();
                }
            }
        }

        private async void btnRandom_Click(object sender, EventArgs e)
        {
            if (_cacheAllFoods == null)
            {
                tsslStatus.Text = "Đang tải tất cả món ăn...";
                toolStripProgressBar.Style = ProgressBarStyle.Marquee;

                var res = await _foodService.GetAllFoodsAsync(1, 200);

                toolStripProgressBar.Style = ProgressBarStyle.Blocks;

                if (!res.Success || res.Data == null || res.Data.data.Count == 0)
                {
                    MessageBox.Show(
                        "Không có món ăn nào để chọn!\nHãy thêm món mới hoặc tải từ email.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    tsslStatus.Text = "Sẵn sàng";
                    return;
                }

                _cacheAllFoods = res.Data.data;
            }

            if (_cacheAllFoods.Count == 0)
            {
                MessageBox.Show(
                    "Không có món ăn nào để chọn!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            var rnd = new Random();
            var chosen = _cacheAllFoods[rnd.Next(_cacheAllFoods.Count)];

            using (var frm = new RandomFoodForm(chosen))
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog(this);
            }
        }

        private async void Card_OnDeleteClick(object sender, int foodId)
        {
            var confirm = MessageBox.Show(
                "Bạn có chắc muốn xóa món này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            tsslStatus.Text = "Đang xóa...";
            toolStripProgressBar.Style = ProgressBarStyle.Marquee;

            var result = await _foodService.DeleteFoodAsync(foodId);

            toolStripProgressBar.Style = ProgressBarStyle.Blocks;

            if (!result.Success)
            {
                MessageBox.Show(
                    $"Xóa thất bại: {result.ErrorMessage}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                tsslStatus.Text = "Sẵn sàng";
                return;
            }

            _cacheAllFoods = null;
            await LoadAllFoodsAsync();

            MessageBox.Show("Đã xóa món thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tsslLogout_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Bạn có chắc muốn đăng xuất?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            CurrentUser.ClearUser();
            this.Hide();
            new LoginForm().Show();
            this.Close();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            _cacheAllFoods = null;
            await LoadAllFoodsAsync();
        }
    }
}