namespace Bai05
{
    partial class AddDishForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            ckbDish = new CheckBox();
            txtDescription = new TextBox();
            btnPickImg = new Button();
            txtAddress = new TextBox();
            txtPrice = new TextBox();
            txtNameDish = new TextBox();
            lblDescription = new Label();
            lblPrice = new Label();
            lblAddress = new Label();
            lblImg = new Label();
            lblNameFood = new Label();
            btnAdd = new Button();
            btnCancel = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(ckbDish);
            groupBox1.Controls.Add(txtDescription);
            groupBox1.Controls.Add(btnPickImg);
            groupBox1.Controls.Add(txtAddress);
            groupBox1.Controls.Add(txtPrice);
            groupBox1.Controls.Add(txtNameDish);
            groupBox1.Controls.Add(lblDescription);
            groupBox1.Controls.Add(lblPrice);
            groupBox1.Controls.Add(lblAddress);
            groupBox1.Controls.Add(lblImg);
            groupBox1.Controls.Add(lblNameFood);
            groupBox1.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(508, 342);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Nhập";
            // 
            // ckbDish
            // 
            ckbDish.AutoSize = true;
            ckbDish.Enabled = false;
            ckbDish.Location = new Point(391, 134);
            ckbDish.Name = "ckbDish";
            ckbDish.Size = new Size(84, 22);
            ckbDish.TabIndex = 10;
            ckbDish.Text = "Đã chọn";
            ckbDish.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(122, 165);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(250, 161);
            txtDescription.TabIndex = 9;
            // 
            // btnPickImg
            // 
            btnPickImg.BackColor = SystemColors.ControlLight;
            btnPickImg.FlatStyle = FlatStyle.Flat;
            btnPickImg.Font = new Font("Tahoma", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPickImg.Location = new Point(202, 127);
            btnPickImg.Name = "btnPickImg";
            btnPickImg.Size = new Size(72, 29);
            btnPickImg.TabIndex = 8;
            btnPickImg.Text = "Chọn ảnh";
            btnPickImg.UseVisualStyleBackColor = false;
            btnPickImg.Click += btnPickImg_Click;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(122, 95);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(250, 26);
            txtAddress.TabIndex = 7;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(122, 60);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(250, 26);
            txtPrice.TabIndex = 6;
            // 
            // txtNameDish
            // 
            txtNameDish.Location = new Point(122, 22);
            txtNameDish.Name = "txtNameDish";
            txtNameDish.Size = new Size(250, 26);
            txtNameDish.TabIndex = 5;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescription.Location = new Point(22, 165);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(51, 18);
            lblDescription.TabIndex = 4;
            lblDescription.Text = "Mô tả:";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPrice.Location = new Point(22, 60);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(33, 18);
            lblPrice.TabIndex = 3;
            lblPrice.Text = "Giá:";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAddress.Location = new Point(22, 95);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(55, 18);
            lblAddress.TabIndex = 2;
            lblAddress.Text = "Địa chỉ:";
            // 
            // lblImg
            // 
            lblImg.AutoSize = true;
            lblImg.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblImg.Location = new Point(22, 130);
            lblImg.Name = "lblImg";
            lblImg.Size = new Size(70, 18);
            lblImg.TabIndex = 1;
            lblImg.Text = "Hình ảnh:";
            // 
            // lblNameFood
            // 
            lblNameFood.AutoSize = true;
            lblNameFood.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNameFood.Location = new Point(22, 25);
            lblNameFood.Name = "lblNameFood";
            lblNameFood.Size = new Size(94, 18);
            lblNameFood.TabIndex = 0;
            lblNameFood.Text = "Tên món ăn:";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(326, 360);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(426, 360);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // AddDishForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(532, 403);
            Controls.Add(btnCancel);
            Controls.Add(btnAdd);
            Controls.Add(groupBox1);
            Name = "AddDishForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thêm món ăn";
            Load += AddDishForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label lblNameFood;
        private Button btnPickImg;
        private TextBox txtAddress;
        private TextBox txtPrice;
        private TextBox txtNameDish;
        private Label lblDescription;
        private Label lblPrice;
        private Label lblAddress;
        private Label lblImg;
        private TextBox txtDescription;
        private CheckBox ckbDish;
        private Button btnAdd;
        private Button btnCancel;
    }
}