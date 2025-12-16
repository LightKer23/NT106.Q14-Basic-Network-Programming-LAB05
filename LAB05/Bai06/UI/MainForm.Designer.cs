namespace Bai06.UI
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
            groupBox1 = new GroupBox();
            btnLogout = new Button();
            btnRefresh = new Button();
            btnSendMail = new Button();
            btnLogin = new Button();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            txtPortSMTP = new TextBox();
            txtSMTP = new TextBox();
            label6 = new Label();
            label5 = new Label();
            txtPortIMAP = new TextBox();
            label4 = new Label();
            label3 = new Label();
            txtIMAP = new TextBox();
            lstEmail = new ListView();
            STT = new ColumnHeader();
            clmTieuDe = new ColumnHeader();
            clmDen = new ColumnHeader();
            clmThoiGian = new ColumnHeader();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnLogout);
            groupBox1.Controls.Add(btnRefresh);
            groupBox1.Controls.Add(btnSendMail);
            groupBox1.Controls.Add(btnLogin);
            groupBox1.Controls.Add(txtPassword);
            groupBox1.Controls.Add(txtUsername);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(272, 135);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Đăng nhập";
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(175, 100);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(91, 29);
            btnLogout.TabIndex = 7;
            btnLogout.Text = "Đăng xuất";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(85, 100);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(81, 29);
            btnRefresh.TabIndex = 6;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnSendMail
            // 
            btnSendMail.Location = new Point(6, 100);
            btnSendMail.Name = "btnSendMail";
            btnSendMail.Size = new Size(73, 29);
            btnSendMail.TabIndex = 5;
            btnSendMail.Text = "Gửi Mail";
            btnSendMail.UseVisualStyleBackColor = true;
            btnSendMail.Click += btnSendMail_Click;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(175, 100);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(91, 29);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(88, 64);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(178, 27);
            txtPassword.TabIndex = 3;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(88, 29);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(178, 27);
            txtUsername.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 67);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 1;
            label2.Text = "Mật khẩu:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 32);
            label1.Name = "label1";
            label1.Size = new Size(76, 20);
            label1.TabIndex = 0;
            label1.Text = "Tài Khoản:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtPortSMTP);
            groupBox2.Controls.Add(txtSMTP);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(txtPortIMAP);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(txtIMAP);
            groupBox2.Location = new Point(290, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(498, 135);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Cài đặt";
            // 
            // txtPortSMTP
            // 
            txtPortSMTP.Location = new Point(316, 82);
            txtPortSMTP.Name = "txtPortSMTP";
            txtPortSMTP.Size = new Size(176, 27);
            txtPortSMTP.TabIndex = 9;
            // 
            // txtSMTP
            // 
            txtSMTP.Location = new Point(316, 32);
            txtSMTP.Name = "txtSMTP";
            txtSMTP.Size = new Size(176, 27);
            txtSMTP.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(268, 85);
            label6.Name = "label6";
            label6.Size = new Size(47, 20);
            label6.TabIndex = 7;
            label6.Text = "Cổng:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(14, 85);
            label5.Name = "label5";
            label5.Size = new Size(47, 20);
            label5.TabIndex = 5;
            label5.Text = "Cổng:";
            // 
            // txtPortIMAP
            // 
            txtPortIMAP.Location = new Point(60, 82);
            txtPortIMAP.Name = "txtPortIMAP";
            txtPortIMAP.Size = new Size(176, 27);
            txtPortIMAP.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(268, 36);
            label4.Name = "label4";
            label4.Size = new Size(49, 20);
            label4.TabIndex = 3;
            label4.Text = "SMTP:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 36);
            label3.Name = "label3";
            label3.Size = new Size(47, 20);
            label3.TabIndex = 1;
            label3.Text = "IMAP:";
            // 
            // txtIMAP
            // 
            txtIMAP.Location = new Point(60, 32);
            txtIMAP.Name = "txtIMAP";
            txtIMAP.Size = new Size(176, 27);
            txtIMAP.TabIndex = 0;
            // 
            // lstEmail
            // 
            lstEmail.Columns.AddRange(new ColumnHeader[] { STT, clmTieuDe, clmDen, clmThoiGian });
            lstEmail.FullRowSelect = true;
            lstEmail.Location = new Point(12, 153);
            lstEmail.MultiSelect = false;
            lstEmail.Name = "lstEmail";
            lstEmail.Size = new Size(776, 318);
            lstEmail.TabIndex = 2;
            lstEmail.UseCompatibleStateImageBehavior = false;
            lstEmail.View = View.Details;
            lstEmail.DoubleClick += lstEmail_DoubleClick;
            // 
            // STT
            // 
            STT.Text = "STT";
            STT.Width = 40;
            // 
            // clmTieuDe
            // 
            clmTieuDe.Text = "Tiêu đề";
            clmTieuDe.Width = 200;
            // 
            // clmDen
            // 
            clmDen.Text = "Từ";
            clmDen.Width = 380;
            // 
            // clmThoiGian
            // 
            clmThoiGian.Text = "Thời Gian";
            clmThoiGian.Width = 150;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 482);
            Controls.Add(lstEmail);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "MainForm";
            Text = "Bài_6";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label2;
        private Label label1;
        private GroupBox groupBox2;
        private Button btnLogin;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private Label label6;
        private Label label5;
        private TextBox txtPortIMAP;
        private Label label4;
        private Label label3;
        private TextBox txtIMAP;
        private ListView lstEmail;
        private ColumnHeader STT;
        private ColumnHeader clmTieuDe;
        private ColumnHeader clmDen;
        private ColumnHeader clmThoiGian;
        private TextBox txtPortSMTP;
        private TextBox txtSMTP;
        private Button btnLogout;
        private Button btnRefresh;
        private Button btnSendMail;
    }
}