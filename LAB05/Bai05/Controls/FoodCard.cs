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

namespace Bai05.Controls
{
    public partial class FoodCard : Form
    {
        private const string BaseUrl = "https://nt106.uitiot.vn";
        private static readonly HttpClient _httpClient = new HttpClient();
        public FoodCard()
        {
            InitializeComponent();
        }

        public void SetData(FoodItem food)
        {
            if (food == null) return;

            lblName.Text = food.ten_mon_an ?? "Chưa có tên";
            lblPrice.Text = $"Giá: {food.gia:N0} VNĐ";
            lblAddress.Text = $"Địa chỉ: {food.dia_chi ?? "Chưa có"}";
            lblContributor.Text = $"Đóng góp: {food.nguoi_dong_gop ?? "Ẩn danh"}";

            SetImageFromUrl(food.hinh_anh);
        }

        private async void SetImageFromUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                pbImage.Image = null;
                return;
            }

            try
            {
                // Nếu là file local
                if (Path.IsPathRooted(url) && !url.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                {
                    pbImage.Image = Image.FromFile(url);
                    return;
                }

                // Nếu là URL nhưng không có http
                if (!url.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                {
                    if (!url.StartsWith("/"))
                        url = "/" + url;
                    url = BaseUrl + url;
                }

                var bytes = await _httpClient.GetByteArrayAsync(url);
                using (var ms = new MemoryStream(bytes))
                {
                    pbImage.Image = Image.FromStream(ms);
                }
            }
            catch
            {
                pbImage.Image = null;
            }
        }
    }
}
