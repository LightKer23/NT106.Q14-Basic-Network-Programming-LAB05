using Bai05.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai05.User_Controls
{
    public partial class FoodItemControl : Form
    {
        private const string BaseUrl = "https://nt106.uitiot.vn";
        private static readonly HttpClient httpClient = new HttpClient();
        public int FoodId { get; private set; }
        public event EventHandler<int>? OnDeleteClick;

        public FoodItemControl()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            OnDeleteClick?.Invoke(this, FoodId);
        }

        public bool ShowDeleteButton
        {
            get => btnDelete.Visible;
            set => btnDelete.Visible = value;
        }

        public void SetData(FoodItem food)
        {
            if (food == null) return;
            FoodId = food.id;
            lblNameFood.Text = food.ten_mon_an ?? "Chưa có tên";
            lblPrice.Text = $"{food.gia:N0} VNĐ";
            lblAddress.Text = (food.dia_chi ?? "Chưa có địa chỉ");
            lblContributor.Text = (food.nguoi_dong_gop ?? "Ẩn danh");

            SetImageFromUrl(food.hinh_anh);
        }

        private async void SetImageFromUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                DisposeCurrentImage();
                return;
            }

            if (Path.IsPathRooted(url) && !url.StartsWith("http", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    DisposeCurrentImage();
                    pbImage.Image = Image.FromFile(url);
                }
                catch (Exception ex)
                {
                    DisposeCurrentImage();
                    System.Diagnostics.Debug.WriteLine("Lỗi load ảnh local: " + ex.Message);
                }
                return;
            }

            if (!url.StartsWith("http", StringComparison.OrdinalIgnoreCase))
            {
                if (!url.StartsWith("/")) url = "/" + url;
                url = BaseUrl + url;
            }

            try
            {
                var bytes = await httpClient.GetByteArrayAsync(url);
                using (var ms = new MemoryStream(bytes))
                {
                    var img = Image.FromStream(ms);

                    DisposeCurrentImage();
                    pbImage.Image = img;
                }
            }
            catch (Exception ex)
            {
                DisposeCurrentImage();
                System.Diagnostics.Debug.WriteLine("Lỗi load ảnh http: " + ex.Message);
            }
        }

        private void DisposeCurrentImage()
        {
            if (pbImage.Image != null)
            {
                pbImage.Image.Dispose();
                pbImage.Image = null;
            }
        }
    }
}
