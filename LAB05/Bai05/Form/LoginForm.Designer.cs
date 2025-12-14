namespace Bai05
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnLogin = new Button();
            txtusername = new TextBox();
            txtpassword = new TextBox();
            lblusername = new Label();
            lblpassword = new Label();
            btnRegister = new Button();
            btnCancel = new Button();
            lblsubtitle = new Label();
            lbltitle = new Label();
            splitContainer1 = new SplitContainer();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.FlatStyle = FlatStyle.Popup;
            btnLogin.Font = new Font("Tahoma", 10.2F);
            btnLogin.Location = new Point(16, 213);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(117, 29);
            btnLogin.TabIndex = 1;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += button1_Click;
            // 
            // txtusername
            // 
            txtusername.Font = new Font("Tahoma", 10.2F);
            txtusername.Location = new Point(171, 123);
            txtusername.Name = "txtusername";
            txtusername.Size = new Size(189, 28);
            txtusername.TabIndex = 2;
            // 
            // txtpassword
            // 
            txtpassword.Font = new Font("Tahoma", 10.2F);
            txtpassword.Location = new Point(171, 157);
            txtpassword.Name = "txtpassword";
            txtpassword.Size = new Size(189, 28);
            txtpassword.TabIndex = 3;
            // 
            // lblusername
            // 
            lblusername.AutoSize = true;
            lblusername.Font = new Font("Tahoma", 10.2F);
            lblusername.Location = new Point(39, 126);
            lblusername.Name = "lblusername";
            lblusername.Size = new Size(44, 21);
            lblusername.TabIndex = 5;
            lblusername.Text = "Tên:";
            // 
            // lblpassword
            // 
            lblpassword.AutoSize = true;
            lblpassword.Font = new Font("Tahoma", 10.2F);
            lblpassword.Location = new Point(39, 160);
            lblpassword.Name = "lblpassword";
            lblpassword.Size = new Size(84, 21);
            lblpassword.TabIndex = 6;
            lblpassword.Text = "Mật khẩu:";
            // 
            // btnRegister
            // 
            btnRegister.FlatStyle = FlatStyle.Popup;
            btnRegister.Font = new Font("Tahoma", 10.2F);
            btnRegister.Location = new Point(141, 213);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(117, 29);
            btnRegister.TabIndex = 7;
            btnRegister.Text = "Đăng ký";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btndangky_Click;
            // 
            // btnCancel
            // 
            btnCancel.FlatStyle = FlatStyle.Popup;
            btnCancel.Font = new Font("Tahoma", 10.2F);
            btnCancel.Location = new Point(266, 213);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(117, 29);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Thoát";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnthoat_Click;
            // 
            // lblsubtitle
            // 
            lblsubtitle.AutoSize = true;
            lblsubtitle.Font = new Font("Tahoma", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblsubtitle.Location = new Point(195, 71);
            lblsubtitle.Name = "lblsubtitle";
            lblsubtitle.Size = new Size(128, 22);
            lblsubtitle.TabIndex = 17;
            lblsubtitle.Text = "Phiên bản số 5";
            // 
            // lbltitle
            // 
            lbltitle.AutoSize = true;
            lbltitle.Font = new Font("Tahoma", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbltitle.Location = new Point(70, 37);
            lbltitle.Name = "lbltitle";
            lbltitle.Size = new Size(259, 34);
            lbltitle.TabIndex = 16;
            lbltitle.Text = "HÔM NAY ĂN GÌ?";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(lblsubtitle);
            splitContainer1.Panel2.Controls.Add(lblpassword);
            splitContainer1.Panel2.Controls.Add(lbltitle);
            splitContainer1.Panel2.Controls.Add(txtpassword);
            splitContainer1.Panel2.Controls.Add(lblusername);
            splitContainer1.Panel2.Controls.Add(btnRegister);
            splitContainer1.Panel2.Controls.Add(txtusername);
            splitContainer1.Panel2.Controls.Add(btnCancel);
            splitContainer1.Panel2.Controls.Add(btnLogin);
            splitContainer1.Size = new Size(398, 379);
            splitContainer1.SplitterDistance = 104;
            splitContainer1.TabIndex = 18;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.uit_logo;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(398, 104);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(398, 379);
            Controls.Add(splitContainer1);
            Name = "LoginForm";
            Text = "Đăng nhập";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnLogin;
        private TextBox txtusername;
        private TextBox txtpassword;
        private Label lblusername;
        private Label lblpassword;
        private Button btnRegister;
        private Button btnCancel;
        private Label lblsubtitle;
        private Label lbltitle;
        private SplitContainer splitContainer1;
        private PictureBox pictureBox1;
    }
}
