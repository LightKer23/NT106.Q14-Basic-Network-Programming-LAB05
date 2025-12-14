namespace Bai05
{
    partial class EmailContributionForm
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
            panel1 = new Panel();
            lblTitle = new Label();
            groupBox1 = new GroupBox();
            lnkAppPasswordGuide = new LinkLabel();
            label2 = new Label();
            txtAppPassword = new TextBox();
            label1 = new Label();
            btnLoadFromEmail = new Button();
            groupBox2 = new GroupBox();
            lstResults = new ListBox();
            statusStrip1 = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            progressBar1 = new ToolStripProgressBar();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLightLight;
            panel1.Controls.Add(lblTitle);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(700, 70);
            panel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Tahoma", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(64, 64, 64);
            lblTitle.Location = new Point(12, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(501, 34);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "TẢI ĐÓNG GÓP MÓN ĂN TỪ EMAIL";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lnkAppPasswordGuide);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtAppPassword);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnLoadFromEmail);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Font = new Font("Tahoma", 9F);
            groupBox1.Location = new Point(0, 70);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(10);
            groupBox1.Size = new Size(700, 140);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Cấu hình Gmail";
            // 
            // lnkAppPasswordGuide
            // 
            lnkAppPasswordGuide.AutoSize = true;
            lnkAppPasswordGuide.Location = new Point(13, 105);
            lnkAppPasswordGuide.Name = "lnkAppPasswordGuide";
            lnkAppPasswordGuide.Size = new Size(328, 18);
            lnkAppPasswordGuide.TabIndex = 4;
            lnkAppPasswordGuide.TabStop = true;
            lnkAppPasswordGuide.Text = "🔗 Hướng dẫn tạo App Password (Click vào đây)";
            lnkAppPasswordGuide.LinkClicked += lnkAppPasswordGuide_LinkClicked;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Gray;
            label2.Location = new Point(13, 80);
            label2.Name = "label2";
            label2.Size = new Size(534, 18);
            label2.TabIndex = 3;
            label2.Text = "Lưu ý: Không dùng password thường, phải tạo App Password tại Google Account";
            // 
            // txtAppPassword
            // 
            txtAppPassword.Font = new Font("Consolas", 10.2F);
            txtAppPassword.Location = new Point(13, 50);
            txtAppPassword.Name = "txtAppPassword";
            txtAppPassword.PlaceholderText = "Nhập 16 ký tự App Password (không có khoảng trắng)";
            txtAppPassword.Size = new Size(450, 27);
            txtAppPassword.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 29);
            label1.Name = "label1";
            label1.Size = new Size(144, 18);
            label1.TabIndex = 1;
            label1.Text = "Gmail App Password:";
            // 
            // btnLoadFromEmail
            // 
            btnLoadFromEmail.BackColor = Color.Transparent;
            btnLoadFromEmail.FlatStyle = FlatStyle.Flat;
            btnLoadFromEmail.Font = new Font("Tahoma", 10.2F, FontStyle.Bold);
            btnLoadFromEmail.ForeColor = SystemColors.ControlText;
            btnLoadFromEmail.Location = new Point(480, 40);
            btnLoadFromEmail.Name = "btnLoadFromEmail";
            btnLoadFromEmail.Size = new Size(200, 45);
            btnLoadFromEmail.TabIndex = 0;
            btnLoadFromEmail.Text = "📧 Tải từ Email";
            btnLoadFromEmail.UseVisualStyleBackColor = false;
            btnLoadFromEmail.Click += btnLoadFromEmail_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lstResults);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Font = new Font("Tahoma", 9F);
            groupBox2.Location = new Point(0, 210);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(10);
            groupBox2.Size = new Size(700, 264);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Kết quả xử lý";
            // 
            // lstResults
            // 
            lstResults.Dock = DockStyle.Fill;
            lstResults.Font = new Font("Consolas", 9F);
            lstResults.FormattingEnabled = true;
            lstResults.ItemHeight = 18;
            lstResults.Location = new Point(10, 29);
            lstResults.Name = "lstResults";
            lstResults.Size = new Size(680, 225);
            lstResults.TabIndex = 0;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus, progressBar1 });
            statusStrip1.Location = new Point(0, 474);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(700, 26);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(68, 20);
            lblStatus.Text = "Sẵn sàng";
            // 
            // progressBar1
            // 
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(150, 18);
            // 
            // EmailContributionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 500);
            Controls.Add(groupBox2);
            Controls.Add(statusStrip1);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "EmailContributionForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tải đóng góp món ăn từ Email";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtAppPassword;
        private Button btnLoadFromEmail;
        private ListBox lstResults;
        private Panel panel1;
        private Label lblTitle;
        private GroupBox groupBox1;
        private LinkLabel lnkAppPasswordGuide;
        private Label label1;
        private Label label2;
        private GroupBox groupBox2;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatus;
        private ToolStripProgressBar progressBar1;
    }
}