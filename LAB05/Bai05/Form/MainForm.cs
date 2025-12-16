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

        private int _pageAll = 1;
        private int _totalPagesAll = 1;

        private int _pageMy = 1;
        private int _totalPagesMy = 1;

        private bool _isUpdatingPageCombo = false;

        private List<FoodItem>? _cacheAllFoods = null;
        private List<FoodItem>? _cacheMyFoods = null;

        private readonly FoodService _foodService;

        private bool IsMineTab => tabMode != null && tabMode.SelectedTab == tabMine;

        public MainForm()
        {
            InitializeComponent();
            _foodService = Program.foodSer;
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            cboPageSize.Items.AddRange(new object[] { 6, 12, 18, 24 });
            cboPageSize.SelectedItem = 6;
            flpFoods.FlowDirection = FlowDirection.TopDown;
            flpFoods.WrapContents = false;

            await ReloadCurrentTabAsync();
        }

        private void ClearAndDispose(FlowLayoutPanel panel)
        {
            foreach (Control c in panel.Controls) c.Dispose();
            panel.Controls.Clear();
        }

        private Control MakeEmptyBlock(FlowLayoutPanel host, string text)
        {
            int w = host.ClientSize.Width
                    - host.Padding.Horizontal
                    - SystemInformation.VerticalScrollBarWidth
                    - 5;

            var box = new Panel
            {
                Width = Math.Max(200, w),
                Height = 180,
                Margin = new Padding(10),
                BackColor = Color.Transparent
            };

            var lbl = new Label
            {
                Text = text,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 14, FontStyle.Italic),
                ForeColor = Color.Gray
            };

            box.Controls.Add(lbl);

            host.SizeChanged += (_, __) =>
            {
                int nw = host.ClientSize.Width
                         - host.Padding.Horizontal
                         - SystemInformation.VerticalScrollBarWidth
                         - 5;
                box.Width = Math.Max(200, nw);
            };

            return box;
        }


        private async Task LoadCommunityAsync()
        {
            toolStripProgressBar.Style = ProgressBarStyle.Marquee;
            tsslStatus.Text = "Đang tải cộng đồng...";

            var result = await _foodService.GetAllFoodsAsync(_pageAll, _pageSize);

            toolStripProgressBar.Style = ProgressBarStyle.Blocks;

            if (!result.Success || result.Data == null)
            {
                MessageBox.Show(result.ErrorMessage ?? "Không tải được dữ liệu cộng đồng",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tsslStatus.Text = "Sẵn sàng";
                return;
            }

            var d = result.Data;
            var pg = d.pagination;

            _totalPagesAll = (pg != null && pg.pageSize > 0)
                ? (int)Math.Ceiling(pg.total / (double)pg.pageSize)
                : 1;

            UpdatePageCombo();

            ClearAndDispose(flpFoods);
            var items = d.data ?? new List<FoodItem>();
            if (items.Count == 0)
            {
                flpFoods.Controls.Add(MakeEmptyBlock(flpFoods, "Bạn chưa có món nào.\nHãy thêm món hoặc tải từ Email!"));
            }
            else
            {
                foreach (var food in items)
                {
                    var card = new FoodItemControl();
                    card.SetData(food);
                    card.ShowDeleteButton = false; 
                    flpFoods.Controls.Add(card);
                }
            }

            if (pg != null)
                tsslStatus.Text = $"Cộng đồng: {pg.total} món | Trang {_pageAll}/{_totalPagesAll}";
            else
                tsslStatus.Text = "Sẵn sàng";
        }

        private async Task LoadMineAsync()
        {
            if (string.IsNullOrWhiteSpace(CurrentUser.User?.token))
            {
                MessageBox.Show("Bạn cần đăng nhập lại (thiếu token).", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            toolStripProgressBar.Style = ProgressBarStyle.Marquee;
            tsslStatus.Text = "Đang tải cá nhân...";

            var result = await _foodService.GetMyFoodsAsync(_pageMy, _pageSize);

            toolStripProgressBar.Style = ProgressBarStyle.Blocks;

            if (!result.Success || result.Data == null)
            {
                MessageBox.Show(result.ErrorMessage ?? "Không tải được dữ liệu cá nhân",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tsslStatus.Text = "Sẵn sàng";
                return;
            }

            var d = result.Data;
            var pg = d.pagination;

            _totalPagesMy = (pg != null && pg.pageSize > 0)
                ? (int)Math.Ceiling(pg.total / (double)pg.pageSize)
                : 1;

            UpdatePageCombo();

            ClearAndDispose(flpFoods);
            var items = d.data ?? new List<FoodItem>();
            if (items.Count == 0)
            {
                flpFoods.Controls.Add(MakeEmptyBlock(flpFoods, "Bạn chưa có món nào.\nHãy thêm món hoặc tải từ Email!"));
            }
            else
            {
                foreach (var food in items)
                {
                    var card = new FoodItemControl();
                    card.SetData(food);

                    card.ShowDeleteButton = true;
                    card.OnDeleteClick += Card_OnDeleteClick;

                    flpFoods.Controls.Add(card);
                }
            }

            if (pg != null)
                tsslStatus.Text = $"Cá nhân: {pg.total} món | Trang {_pageMy}/{_totalPagesMy}";
            else
                tsslStatus.Text = "Sẵn sàng";
        }

        private void UpdatePageCombo()
        {
            _isUpdatingPageCombo = true;
            try
            {
                cboPage.Items.Clear();

                int totalPages = IsMineTab ? _totalPagesMy : _totalPagesAll;
                int currentPage = IsMineTab ? _pageMy : _pageAll;

                if (totalPages <= 0) totalPages = 1;

                for (int i = 1; i <= totalPages; i++)
                    cboPage.Items.Add(i);

                cboPage.SelectedItem = Math.Min(Math.Max(1, currentPage), totalPages);

                btnPrevPage.Enabled = currentPage > 1;
                btnNextPage.Enabled = currentPage < totalPages;
            }
            finally
            {
                _isUpdatingPageCombo = false;
            }
        }

        private async Task ReloadCurrentTabAsync()
        {
            if (IsMineTab) await LoadMineAsync();
            else await LoadCommunityAsync();
        }

        private async void tabMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            await ReloadCurrentTabAsync();
        }

        private async void cboPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isUpdatingPageCombo) return;
            if (cboPage.SelectedItem == null) return;

            int newPage = (int)cboPage.SelectedItem;

            if (IsMineTab) _pageMy = newPage;
            else _pageAll = newPage;

            await ReloadCurrentTabAsync();
        }

        private async void cboPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPageSize.SelectedItem == null) return;

            _pageSize = (int)cboPageSize.SelectedItem;
            _pageAll = 1;
            _pageMy = 1;

            await ReloadCurrentTabAsync();
        }

        private async void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (IsMineTab)
            {
                if (_pageMy > 1) _pageMy--;
            }
            else
            {
                if (_pageAll > 1) _pageAll--;
            }

            await ReloadCurrentTabAsync();
        }

        private async void btnNextPage_Click(object sender, EventArgs e)
        {
            if (IsMineTab)
            {
                if (_pageMy < _totalPagesMy) _pageMy++;
            }
            else
            {
                if (_pageAll < _totalPagesAll) _pageAll++;
            }

            await ReloadCurrentTabAsync();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            using (var frm = new AddDishForm())
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    _cacheAllFoods = null;
                    _cacheMyFoods = null;

                    _pageAll = 1;
                    _pageMy = 1;

                    await ReloadCurrentTabAsync();
                }
            }
        }

        private async void btnLoadFromEmail_Click(object sender, EventArgs e)
        {
            using (var frm = new EmailContributionForm())
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    _cacheAllFoods = null;
                    _cacheMyFoods = null;

                    _pageAll = 1;
                    _pageMy = 1;

                    await ReloadCurrentTabAsync();
                }
            }
        }

        private async void btnRandom_Click(object sender, EventArgs e)
        {
            List<FoodItem> list;

            if (!IsMineTab)
            {
                if (_cacheAllFoods == null)
                {
                    var res = await _foodService.GetAllFoodsNoPagingAsync();
                    if (!res.Success || res.Data == null || res.Data.Count == 0)
                    {
                        MessageBox.Show("Không có món nào để chọn!");
                        return;
                    }
                    _cacheAllFoods = res.Data;
                }
                list = _cacheAllFoods;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(CurrentUser.User?.token))
                {
                    MessageBox.Show("Bạn cần đăng nhập lại (thiếu token).");
                    return;
                }

                if (_cacheMyFoods == null)
                {
                    var res = await _foodService.GetMyFoodsNoPagingAsync();
                    if (!res.Success || res.Data == null || res.Data.Count == 0)
                    {
                        MessageBox.Show("Bạn chưa có món nào để chọn!");
                        return;
                    }
                    _cacheMyFoods = res.Data;
                }
                list = _cacheMyFoods;
            }

            var rnd = new Random();
            var chosen = list[rnd.Next(list.Count)];

            using (var frm = new RandomFoodForm(chosen))
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog(this);
            }
        }

        private async void Card_OnDeleteClick(object sender, int foodId)
        {
            var confirm = MessageBox.Show("Bạn có chắc muốn xóa món này?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            toolStripProgressBar.Style = ProgressBarStyle.Marquee;
            tsslStatus.Text = "Đang xóa...";

            var result = await _foodService.DeleteFoodAsync(foodId);

            toolStripProgressBar.Style = ProgressBarStyle.Blocks;

            if (!result.Success)
            {
                MessageBox.Show($"Xóa thất bại: {result.ErrorMessage}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tsslStatus.Text = "Sẵn sàng";
                return;
            }

            _cacheAllFoods = null;
            _cacheMyFoods = null;

            await ReloadCurrentTabAsync();
            MessageBox.Show("Đã xóa món thành công!", "Thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            _cacheAllFoods = null;
            _cacheMyFoods = null;

            await ReloadCurrentTabAsync();
        }

        private void tsslLogout_Click(object sender, EventArgs e)
        {
            CurrentUser.ClearUser();
            this.Hide();
            new LoginForm().Show();
            this.Close();
        }
    }
}
