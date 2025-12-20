using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai05
{
    public partial class AddDishForm : Form
    {
        private string? _imagePathOrUrl;

        public AddDishForm()
        {
            InitializeComponent();
        }

        private void AddDishForm_Load(object sender, EventArgs e)
        {
            ckbDish.Checked = false;
        }

        private void btnPickImg_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn hình món ăn";
                ofd.Filter = "Ảnh|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Tất cả|*.*";

                if (ofd.ShowDialog(this) == DialogResult.OK)
                {
                    _imagePathOrUrl = ofd.FileName;
                    ckbDish.Checked = true;
                }
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtNameDish.Text.Trim();
            string priceText = txtPrice.Text.Trim();
            string address = txtAddress.Text.Trim();
            string description = txtDescription.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Vui lòng nhập tên món ăn.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNameDish.Focus();
                return;
            }

            if (!int.TryParse(priceText, out int price) || price < 0)
            {
                MessageBox.Show("Giá phải là một số nguyên không âm.",
                    "Giá không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(address))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ món ăn.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Vui lòng nhập mô tả món ăn.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescription.Focus();
                return;
            }

            btnAdd.Enabled = false;
            btnCancel.Enabled = false;
            Cursor = Cursors.WaitCursor;

            try
            {
                var result = await Program.foodSer.AddFoodAsync(name, price, description, _imagePathOrUrl, address);

                if (!result.Success || result.Data == null)
                {
                    MessageBox.Show(result.ErrorMessage ?? "Thêm món ăn thất bại.",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Thêm món ăn thành công!",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnAdd.Enabled = true;
                btnCancel.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
