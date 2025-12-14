namespace Bai05
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlTop = new Panel();
            btnRefresh = new Button();
            btnRandom = new Button();
            btnAdd = new Button();
            btnLoadFromEmail = new Button();
            lblTitle = new Label();
            pnlMain = new Panel();
            flpFoods = new FlowLayoutPanel();
            pnlBottom = new Panel();
            btnNextPage = new Button();
            btnPrevPage = new Button();
            cboPageSize = new ComboBox();
            lblPageSize = new Label();
            cboPage = new ComboBox();
            lblPage = new Label();
            statusStrip = new StatusStrip();
            toolStripProgressBar = new ToolStripProgressBar();
            tsslStatus = new ToolStripStatusLabel();
            tsslWelcome = new ToolStripStatusLabel();
            tsslLogout = new ToolStripStatusLabel();
            pnlTop.SuspendLayout();
            pnlMain.SuspendLayout();
            pnlBottom.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = SystemColors.ButtonFace;
            pnlTop.Controls.Add(btnRefresh);
            pnlTop.Controls.Add(btnRandom);
            pnlTop.Controls.Add(btnAdd);
            pnlTop.Controls.Add(btnLoadFromEmail);
            pnlTop.Controls.Add(lblTitle);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Font = new Font("Tahoma", 7.8F);
            pnlTop.Location = new Point(0, 0);
            pnlTop.Margin = new Padding(3, 4, 3, 4);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1143, 107);
            pnlTop.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = SystemColors.Control;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Popup;
            btnRefresh.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRefresh.ForeColor = SystemColors.ControlText;
            btnRefresh.Location = new Point(973, 27);
            btnRefresh.Margin = new Padding(3, 4, 3, 4);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(146, 53);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnRandom
            // 
            btnRandom.BackColor = SystemColors.Control;
            btnRandom.FlatAppearance.BorderSize = 0;
            btnRandom.FlatStyle = FlatStyle.Popup;
            btnRandom.Font = new Font("Tahoma", 10.2F);
            btnRandom.ForeColor = SystemColors.ControlText;
            btnRandom.Location = new Point(744, 27);
            btnRandom.Margin = new Padding(3, 4, 3, 4);
            btnRandom.Name = "btnRandom";
            btnRandom.Size = new Size(205, 53);
            btnRandom.TabIndex = 3;
            btnRandom.Text = "Chọn ngẫu nhiên";
            btnRandom.UseVisualStyleBackColor = false;
            btnRandom.Click += btnRandom_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = SystemColors.Control;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Popup;
            btnAdd.Font = new Font("Tahoma", 10.2F);
            btnAdd.ForeColor = SystemColors.ControlText;
            btnAdd.Location = new Point(574, 27);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(146, 53);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Thêm món";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnLoadFromEmail
            // 
            btnLoadFromEmail.BackColor = SystemColors.Control;
            btnLoadFromEmail.FlatAppearance.BorderSize = 0;
            btnLoadFromEmail.FlatStyle = FlatStyle.Popup;
            btnLoadFromEmail.Font = new Font("Tahoma", 10.2F);
            btnLoadFromEmail.ForeColor = SystemColors.ControlText;
            btnLoadFromEmail.Location = new Point(404, 27);
            btnLoadFromEmail.Margin = new Padding(3, 4, 3, 4);
            btnLoadFromEmail.Name = "btnLoadFromEmail";
            btnLoadFromEmail.Size = new Size(146, 53);
            btnLoadFromEmail.TabIndex = 1;
            btnLoadFromEmail.Text = "Tải từ Email";
            btnLoadFromEmail.UseVisualStyleBackColor = false;
            btnLoadFromEmail.Click += btnLoadFromEmail_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Tahoma", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = SystemColors.ControlText;
            lblTitle.Location = new Point(37, 33);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(293, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "HÔM NAY ĂN GÌ? ";
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(flpFoods);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Font = new Font("Tahoma", 7.8F);
            pnlMain.Location = new Point(0, 107);
            pnlMain.Margin = new Padding(3, 4, 3, 4);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(11, 13, 11, 13);
            pnlMain.Size = new Size(1143, 657);
            pnlMain.TabIndex = 1;
            // 
            // flpFoods
            // 
            flpFoods.AutoScroll = true;
            flpFoods.BackColor = Color.WhiteSmoke;
            flpFoods.BorderStyle = BorderStyle.Fixed3D;
            flpFoods.Dock = DockStyle.Fill;
            flpFoods.Font = new Font("Tahoma", 7.8F);
            flpFoods.Location = new Point(11, 13);
            flpFoods.Margin = new Padding(3, 4, 3, 4);
            flpFoods.Name = "flpFoods";
            flpFoods.Padding = new Padding(6, 7, 6, 7);
            flpFoods.Size = new Size(1121, 631);
            flpFoods.TabIndex = 0;
            // 
            // pnlBottom
            // 
            pnlBottom.BackColor = Color.White;
            pnlBottom.BorderStyle = BorderStyle.FixedSingle;
            pnlBottom.Controls.Add(btnNextPage);
            pnlBottom.Controls.Add(btnPrevPage);
            pnlBottom.Controls.Add(cboPageSize);
            pnlBottom.Controls.Add(lblPageSize);
            pnlBottom.Controls.Add(cboPage);
            pnlBottom.Controls.Add(lblPage);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Font = new Font("Tahoma", 10.2F);
            pnlBottom.Location = new Point(0, 764);
            pnlBottom.Margin = new Padding(3, 4, 3, 4);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Size = new Size(1143, 66);
            pnlBottom.TabIndex = 2;
            // 
            // btnNextPage
            // 
            btnNextPage.Anchor = AnchorStyles.None;
            btnNextPage.Font = new Font("Tahoma", 10.2F);
            btnNextPage.Location = new Point(709, 13);
            btnNextPage.Margin = new Padding(3, 4, 3, 4);
            btnNextPage.Name = "btnNextPage";
            btnNextPage.Size = new Size(91, 40);
            btnNextPage.TabIndex = 5;
            btnNextPage.Text = "Sau ▶";
            btnNextPage.UseVisualStyleBackColor = true;
            btnNextPage.Click += btnNextPage_Click;
            // 
            // btnPrevPage
            // 
            btnPrevPage.Anchor = AnchorStyles.None;
            btnPrevPage.Font = new Font("Tahoma", 10.2F);
            btnPrevPage.Location = new Point(343, 13);
            btnPrevPage.Margin = new Padding(3, 4, 3, 4);
            btnPrevPage.Name = "btnPrevPage";
            btnPrevPage.Size = new Size(91, 40);
            btnPrevPage.TabIndex = 4;
            btnPrevPage.Text = "◀ Trước";
            btnPrevPage.UseVisualStyleBackColor = true;
            btnPrevPage.Click += btnPrevPage_Click;
            // 
            // cboPageSize
            // 
            cboPageSize.Anchor = AnchorStyles.None;
            cboPageSize.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPageSize.Font = new Font("Tahoma", 7.8F);
            cboPageSize.FormattingEnabled = true;
            cboPageSize.Location = new Point(903, 16);
            cboPageSize.Margin = new Padding(3, 4, 3, 4);
            cboPageSize.Name = "cboPageSize";
            cboPageSize.Size = new Size(91, 24);
            cboPageSize.TabIndex = 3;
            cboPageSize.SelectedIndexChanged += cboPageSize_SelectedIndexChanged;
            // 
            // lblPageSize
            // 
            lblPageSize.Anchor = AnchorStyles.None;
            lblPageSize.AutoSize = true;
            lblPageSize.Font = new Font("Tahoma", 10.2F);
            lblPageSize.Location = new Point(823, 20);
            lblPageSize.Name = "lblPageSize";
            lblPageSize.Size = new Size(71, 21);
            lblPageSize.TabIndex = 2;
            lblPageSize.Text = "Số món:";
            // 
            // cboPage
            // 
            cboPage.Anchor = AnchorStyles.None;
            cboPage.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPage.Font = new Font("Tahoma", 7.8F);
            cboPage.FormattingEnabled = true;
            cboPage.Location = new Point(514, 16);
            cboPage.Margin = new Padding(3, 4, 3, 4);
            cboPage.Name = "cboPage";
            cboPage.Size = new Size(114, 24);
            cboPage.TabIndex = 1;
            cboPage.SelectedIndexChanged += cboPage_SelectedIndexChanged;
            // 
            // lblPage
            // 
            lblPage.Anchor = AnchorStyles.None;
            lblPage.AutoSize = true;
            lblPage.Font = new Font("Tahoma", 10.2F);
            lblPage.Location = new Point(451, 20);
            lblPage.Name = "lblPage";
            lblPage.Size = new Size(59, 21);
            lblPage.TabIndex = 0;
            lblPage.Text = "Trang:";
            // 
            // statusStrip
            // 
            statusStrip.Font = new Font("Tahoma", 7.8F);
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripProgressBar, tsslStatus, tsslWelcome, tsslLogout });
            statusStrip.Location = new Point(0, 830);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(1, 0, 16, 0);
            statusStrip.Size = new Size(1143, 29);
            statusStrip.TabIndex = 3;
            // 
            // toolStripProgressBar
            // 
            toolStripProgressBar.Font = new Font("Tahoma", 7.8F);
            toolStripProgressBar.Name = "toolStripProgressBar";
            toolStripProgressBar.Size = new Size(114, 21);
            // 
            // tsslStatus
            // 
            tsslStatus.Font = new Font("Tahoma", 7.8F);
            tsslStatus.Name = "tsslStatus";
            tsslStatus.Size = new Size(60, 23);
            tsslStatus.Text = "Sẵn sàng";
            // 
            // tsslWelcome
            // 
            tsslWelcome.Font = new Font("Tahoma", 7.8F);
            tsslWelcome.Name = "tsslWelcome";
            tsslWelcome.Size = new Size(885, 23);
            tsslWelcome.Spring = true;
            tsslWelcome.Text = "Xin chào!";
            tsslWelcome.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tsslLogout
            // 
            tsslLogout.ActiveLinkColor = SystemColors.ControlText;
            tsslLogout.Font = new Font("Tahoma", 7.8F);
            tsslLogout.ForeColor = SystemColors.ControlText;
            tsslLogout.IsLink = true;
            tsslLogout.LinkColor = SystemColors.ControlText;
            tsslLogout.Name = "tsslLogout";
            tsslLogout.Size = new Size(65, 23);
            tsslLogout.Text = "Đăng xuất";
            tsslLogout.VisitedLinkColor = SystemColors.ControlText;
            tsslLogout.Click += tsslLogout_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 859);
            Controls.Add(pnlMain);
            Controls.Add(pnlBottom);
            Controls.Add(pnlTop);
            Controls.Add(statusStrip);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1159, 895);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hôm nay ăn gì? - Phiên bản 5";
            Load += MainForm_Load;
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlMain.ResumeLayout(false);
            pnlBottom.ResumeLayout(false);
            pnlBottom.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnRandom;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnLoadFromEmail;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.FlowLayoutPanel flpFoods;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.ComboBox cboPageSize;
        private System.Windows.Forms.Label lblPageSize;
        private System.Windows.Forms.ComboBox cboPage;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel tsslStatus;
        private System.Windows.Forms.ToolStripStatusLabel tsslWelcome;
        private System.Windows.Forms.ToolStripStatusLabel tsslLogout;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnPrevPage;
        private System.Windows.Forms.Button btnRefresh;
    }
}