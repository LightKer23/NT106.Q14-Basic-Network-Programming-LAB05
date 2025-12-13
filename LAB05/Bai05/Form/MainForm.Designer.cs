namespace Bai05
{
    partial class MainForm
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
            this.panelTop = new Panel();
            this.lblTitle = new Label();
            this.lblWelcome = new Label();
            this.panelCenter = new Panel();
            this.lblAddress = new Label();
            this.lblPrice = new Label();
            this.lblContributor = new Label();
            this.lblDishName = new Label();
            this.pictureBoxDish = new PictureBox();
            this.panelBottom = new Panel();
            this.btnExit = new Button();
            this.btnLogout = new Button();
            this.btnRefresh = new Button();
            this.btnViewAllDishes = new Button();
            this.btnManageEmail = new Button();
            this.btnRandomDish = new Button();
            this.statusStrip1 = new StatusStrip();
            this.lblStatus = new ToolStripStatusLabel();
            this.progressBar1 = new ToolStripProgressBar();
            this.panelTop.SuspendLayout();
            this.panelCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.pictureBoxDish).BeginInit();
            this.panelBottom.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();

            // panelTop
            this.panelTop.BackColor = Color.FromArgb(0, 120, 215);
            this.panelTop.Controls.Add(this.lblWelcome);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = DockStyle.Top;
            this.panelTop.Location = new Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new Size(900, 100);
            this.panelTop.TabIndex = 0;

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Tahoma", 20F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(300, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(300, 33);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "HÔM NAY ĂN GÌ?";

            // lblWelcome
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new Font("Tahoma", 11F);
            this.lblWelcome.ForeColor = Color.White;
            this.lblWelcome.Location = new Point(20, 65);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new Size(150, 18);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Xin chào!";

            // panelCenter
            this.panelCenter.BackColor = Color.White;
            this.panelCenter.Controls.Add(this.lblAddress);
            this.panelCenter.Controls.Add(this.lblPrice);
            this.panelCenter.Controls.Add(this.lblContributor);
            this.panelCenter.Controls.Add(this.lblDishName);
            this.panelCenter.Controls.Add(this.pictureBoxDish);
            this.panelCenter.Dock = DockStyle.Fill;
            this.panelCenter.Location = new Point(0, 100);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Padding = new Padding(30);
            this.panelCenter.Size = new Size(900, 450);
            this.panelCenter.TabIndex = 1;

            // pictureBoxDish
            this.pictureBoxDish.BackColor = Color.LightGray;
            this.pictureBoxDish.BorderStyle = BorderStyle.FixedSingle;
            this.pictureBoxDish.Location = new Point(250, 40);
            this.pictureBoxDish.Name = "pictureBoxDish";
            this.pictureBoxDish.Size = new Size(400, 250);
            this.pictureBoxDish.SizeMode = PictureBoxSizeMode.Zoom;
            this.pictureBoxDish.TabIndex = 0;
            this.pictureBoxDish.TabStop = false;

            // lblDishName
            this.lblDishName.Font = new Font("Tahoma", 18F, FontStyle.Bold);
            this.lblDishName.ForeColor = Color.FromArgb(0, 120, 215);
            this.lblDishName.Location = new Point(50, 310);
            this.lblDishName.Name = "lblDishName";
            this.lblDishName.Size = new Size(800, 35);
            this.lblDishName.TabIndex = 1;
            this.lblDishName.Text = "Chưa có món ăn nào";
            this.lblDishName.TextAlign = ContentAlignment.MiddleCenter;

            // lblPrice
            this.lblPrice.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            this.lblPrice.ForeColor = Color.FromArgb(255, 87, 34);
            this.lblPrice.Location = new Point(50, 350);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new Size(800, 25);
            this.lblPrice.TabIndex = 2;
            this.lblPrice.Text = "";
            this.lblPrice.TextAlign = ContentAlignment.MiddleCenter;

            // lblAddress
            this.lblAddress.Font = new Font("Tahoma", 10F);
            this.lblAddress.ForeColor = Color.Gray;
            this.lblAddress.Location = new Point(50, 380);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new Size(800, 25);
            this.lblAddress.TabIndex = 3;
            this.lblAddress.Text = "";
            this.lblAddress.TextAlign = ContentAlignment.MiddleCenter;

            // lblContributor
            this.lblContributor.Font = new Font("Tahoma", 10F, FontStyle.Italic);
            this.lblContributor.ForeColor = Color.Gray;
            this.lblContributor.Location = new Point(50, 410);
            this.lblContributor.Name = "lblContributor";
            this.lblContributor.Size = new Size(800, 25);
            this.lblContributor.TabIndex = 4;
            this.lblContributor.Text = "Người đóng góp: N/A";
            this.lblContributor.TextAlign = ContentAlignment.MiddleCenter;

            // panelBottom
            this.panelBottom.BackColor = Color.FromArgb(240, 240, 240);
            this.panelBottom.Controls.Add(this.btnExit);
            this.panelBottom.Controls.Add(this.btnLogout);
            this.panelBottom.Controls.Add(this.btnRefresh);
            this.panelBottom.Controls.Add(this.btnViewAllDishes);
            this.panelBottom.Controls.Add(this.btnManageEmail);
            this.panelBottom.Controls.Add(this.btnRandomDish);
            this.panelBottom.Dock = DockStyle.Bottom;
            this.panelBottom.Location = new Point(0, 550);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new Size(900, 70);
            this.panelBottom.TabIndex = 2;

            // btnRandomDish
            this.btnRandomDish.BackColor = Color.FromArgb(0, 120, 215);
            this.btnRandomDish.FlatAppearance.BorderSize = 0;
            this.btnRandomDish.FlatStyle = FlatStyle.Flat;
            this.btnRandomDish.Font = new Font("Tahoma", 10F, FontStyle.Bold);
            this.btnRandomDish.ForeColor = Color.White;
            this.btnRandomDish.Location = new Point(30, 15);
            this.btnRandomDish.Name = "btnRandomDish";
            this.btnRandomDish.Size = new Size(130, 40);
            this.btnRandomDish.TabIndex = 0;
            this.btnRandomDish.Text = "🎲 Chọn ngẫu nhiên";
            this.btnRandomDish.UseVisualStyleBackColor = false;
            this.btnRandomDish.Click += new EventHandler(this.btnRandomDish_Click);

            // btnManageEmail
            this.btnManageEmail.BackColor = Color.FromArgb(46, 125, 50);
            this.btnManageEmail.FlatAppearance.BorderSize = 0;
            this.btnManageEmail.FlatStyle = FlatStyle.Flat;
            this.btnManageEmail.Font = new Font("Tahoma", 10F);
            this.btnManageEmail.ForeColor = Color.White;
            this.btnManageEmail.Location = new Point(180, 15);
            this.btnManageEmail.Name = "btnManageEmail";
            this.btnManageEmail.Size = new Size(130, 40);
            this.btnManageEmail.TabIndex = 1;
            this.btnManageEmail.Text = "📧 Tải từ Email";
            this.btnManageEmail.UseVisualStyleBackColor = false;
            this.btnManageEmail.Click += new EventHandler(this.btnManageEmail_Click);

            // btnViewAllDishes
            this.btnViewAllDishes.BackColor = Color.FromArgb(255, 152, 0);
            this.btnViewAllDishes.FlatAppearance.BorderSize = 0;
            this.btnViewAllDishes.FlatStyle = FlatStyle.Flat;
            this.btnViewAllDishes.Font = new Font("Tahoma", 10F);
            this.btnViewAllDishes.ForeColor = Color.White;
            this.btnViewAllDishes.Location = new Point(330, 15);
            this.btnViewAllDishes.Name = "btnViewAllDishes";
            this.btnViewAllDishes.Size = new Size(130, 40);
            this.btnViewAllDishes.TabIndex = 2;
            this.btnViewAllDishes.Text = "📋 Xem tất cả";
            this.btnViewAllDishes.UseVisualStyleBackColor = false;
            this.btnViewAllDishes.Click += new EventHandler(this.btnViewAllDishes_Click);

            // btnRefresh
            this.btnRefresh.BackColor = Color.FromArgb(103, 58, 183);
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = FlatStyle.Flat;
            this.btnRefresh.Font = new Font("Tahoma", 10F);
            this.btnRefresh.ForeColor = Color.White;
            this.btnRefresh.Location = new Point(480, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(130, 40);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "🔄 Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);

            // btnLogout
            this.btnLogout.BackColor = Color.FromArgb(158, 158, 158);
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = FlatStyle.Flat;
            this.btnLogout.Font = new Font("Tahoma", 10F);
            this.btnLogout.ForeColor = Color.White;
            this.btnLogout.Location = new Point(640, 15);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new Size(110, 40);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "🚪 Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new EventHandler(this.btnLogout_Click);

            // btnExit
            this.btnExit.BackColor = Color.FromArgb(211, 47, 47);
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = FlatStyle.Flat;
            this.btnExit.Font = new Font("Tahoma", 10F);
            this.btnExit.ForeColor = Color.White;
            this.btnExit.Location = new Point(760, 15);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new Size(110, 40);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "❌ Thoát";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new EventHandler(this.btnExit_Click);

            // statusStrip1
            this.statusStrip1.ImageScalingSize = new Size(20, 20);
            this.statusStrip1.Items.AddRange(new ToolStripItem[] {
                this.lblStatus,
                this.progressBar1
            });
            this.statusStrip1.Location = new Point(0, 620);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new Size(900, 26);
            this.statusStrip1.TabIndex = 3;

            // lblStatus
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new Size(68, 20);
            this.lblStatus.Text = "Sẵn sàng";

            // progressBar1
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new Size(200, 18);
            this.progressBar1.Style = ProgressBarStyle.Blocks;

            // MainForm
            this.AutoScaleDimensions = new SizeF(8F, 17F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(900, 646);
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Font = new Font("Tahoma", 10F);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Hôm nay ăn gì? - Phiên bản 5";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.pictureBoxDish).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private Panel panelTop;
        private Panel panelCenter;
        private Panel panelBottom;
        private Label lblTitle;
        private Label lblWelcome;
        private PictureBox pictureBoxDish;
        private Label lblDishName;
        private Label lblContributor;
        private Label lblPrice;
        private Label lblAddress;
        private Button btnRandomDish;
        private Button btnManageEmail;
        private Button btnViewAllDishes;
        private Button btnRefresh;
        private Button btnLogout;
        private Button btnExit;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatus;
        private ToolStripProgressBar progressBar1;
    }
}