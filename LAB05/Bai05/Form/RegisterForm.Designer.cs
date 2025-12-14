namespace Bai05
{
    partial class RegisterForm
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
            txtUsername = new TextBox();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            txtEmail = new TextBox();
            txtPhone = new TextBox();
            txtPsswrd = new TextBox();
            lblUsername = new Label();
            lblFirstName = new Label();
            lblLastName = new Label();
            lblEmail = new Label();
            lblPhone = new Label();
            lblPsswrd = new Label();
            btnLogin = new Button();
            btnRegister = new Button();
            btnCancel = new Button();
            splitContainer1 = new SplitContainer();
            pictureBox1 = new PictureBox();
            comboBox1 = new ComboBox();
            lblLanguage = new Label();
            dateTimePicker1 = new DateTimePicker();
            lblDoB = new Label();
            lblSex = new Label();
            rdBtnFemale = new RadioButton();
            rdBtnMale = new RadioButton();
            lblsubtitle = new Label();
            lbltitle = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Tahoma", 9F);
            txtUsername.Location = new Point(171, 123);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(189, 26);
            txtUsername.TabIndex = 0;
            // 
            // txtFirstName
            // 
            txtFirstName.Font = new Font("Tahoma", 9F);
            txtFirstName.Location = new Point(171, 157);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(189, 26);
            txtFirstName.TabIndex = 1;
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Tahoma", 9F);
            txtLastName.Location = new Point(171, 191);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(189, 26);
            txtLastName.TabIndex = 2;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Tahoma", 9F);
            txtEmail.Location = new Point(171, 225);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(189, 26);
            txtEmail.TabIndex = 3;
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Tahoma", 9F);
            txtPhone.Location = new Point(171, 259);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(189, 26);
            txtPhone.TabIndex = 4;
            // 
            // txtPsswrd
            // 
            txtPsswrd.Font = new Font("Tahoma", 9F);
            txtPsswrd.Location = new Point(171, 388);
            txtPsswrd.Name = "txtPsswrd";
            txtPsswrd.Size = new Size(189, 26);
            txtPsswrd.TabIndex = 5;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.BackColor = Color.Transparent;
            lblUsername.FlatStyle = FlatStyle.Popup;
            lblUsername.Font = new Font("Tahoma", 10.2F);
            lblUsername.Location = new Point(39, 126);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(131, 21);
            lblUsername.TabIndex = 6;
            lblUsername.Text = "Tên người dùng:";
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.BackColor = Color.Transparent;
            lblFirstName.FlatStyle = FlatStyle.Popup;
            lblFirstName.Font = new Font("Tahoma", 10.2F);
            lblFirstName.Location = new Point(39, 160);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(36, 21);
            lblFirstName.TabIndex = 7;
            lblFirstName.Text = "Họ:";
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.BackColor = Color.Transparent;
            lblLastName.FlatStyle = FlatStyle.Popup;
            lblLastName.Font = new Font("Tahoma", 10.2F);
            lblLastName.Location = new Point(39, 194);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(44, 21);
            lblLastName.TabIndex = 8;
            lblLastName.Text = "Tên:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.BackColor = Color.Transparent;
            lblEmail.FlatStyle = FlatStyle.Popup;
            lblEmail.Font = new Font("Tahoma", 10.2F);
            lblEmail.Location = new Point(39, 228);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(57, 21);
            lblEmail.TabIndex = 9;
            lblEmail.Text = "Email:";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.BackColor = Color.Transparent;
            lblPhone.FlatStyle = FlatStyle.Popup;
            lblPhone.Font = new Font("Tahoma", 10.2F);
            lblPhone.Location = new Point(39, 262);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(113, 21);
            lblPhone.TabIndex = 10;
            lblPhone.Text = "Số điện thoại:";
            // 
            // lblPsswrd
            // 
            lblPsswrd.AutoSize = true;
            lblPsswrd.BackColor = Color.Transparent;
            lblPsswrd.FlatStyle = FlatStyle.Popup;
            lblPsswrd.Font = new Font("Tahoma", 10.2F);
            lblPsswrd.Location = new Point(39, 391);
            lblPsswrd.Name = "lblPsswrd";
            lblPsswrd.Size = new Size(84, 21);
            lblPsswrd.TabIndex = 11;
            lblPsswrd.Text = "Mật khẩu:";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.Transparent;
            btnLogin.FlatStyle = FlatStyle.Popup;
            btnLogin.Font = new Font("Tahoma", 10.2F);
            btnLogin.Location = new Point(141, 445);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(117, 29);
            btnLogin.TabIndex = 12;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.Transparent;
            btnRegister.FlatStyle = FlatStyle.Popup;
            btnRegister.Font = new Font("Tahoma", 10.2F);
            btnRegister.Location = new Point(16, 445);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(117, 29);
            btnRegister.TabIndex = 13;
            btnRegister.Text = "Đăng ký";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Transparent;
            btnCancel.FlatStyle = FlatStyle.Popup;
            btnCancel.Font = new Font("Tahoma", 10.2F);
            btnCancel.Location = new Point(266, 445);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(117, 29);
            btnCancel.TabIndex = 14;
            btnCancel.Text = "Thoát";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
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
            splitContainer1.Panel2.Controls.Add(comboBox1);
            splitContainer1.Panel2.Controls.Add(lblLanguage);
            splitContainer1.Panel2.Controls.Add(dateTimePicker1);
            splitContainer1.Panel2.Controls.Add(lblDoB);
            splitContainer1.Panel2.Controls.Add(lblSex);
            splitContainer1.Panel2.Controls.Add(rdBtnFemale);
            splitContainer1.Panel2.Controls.Add(rdBtnMale);
            splitContainer1.Panel2.Controls.Add(lblsubtitle);
            splitContainer1.Panel2.Controls.Add(lbltitle);
            splitContainer1.Panel2.Controls.Add(btnCancel);
            splitContainer1.Panel2.Controls.Add(txtFirstName);
            splitContainer1.Panel2.Controls.Add(txtLastName);
            splitContainer1.Panel2.Controls.Add(lblLastName);
            splitContainer1.Panel2.Controls.Add(lblPhone);
            splitContainer1.Panel2.Controls.Add(btnLogin);
            splitContainer1.Panel2.Controls.Add(txtUsername);
            splitContainer1.Panel2.Controls.Add(txtPsswrd);
            splitContainer1.Panel2.Controls.Add(txtPhone);
            splitContainer1.Panel2.Controls.Add(lblUsername);
            splitContainer1.Panel2.Controls.Add(btnRegister);
            splitContainer1.Panel2.Controls.Add(lblPsswrd);
            splitContainer1.Panel2.Controls.Add(txtEmail);
            splitContainer1.Panel2.Controls.Add(lblEmail);
            splitContainer1.Panel2.Controls.Add(lblFirstName);
            splitContainer1.Size = new Size(398, 622);
            splitContainer1.SplitterDistance = 104;
            splitContainer1.TabIndex = 15;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.uit_logo;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(398, 104);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "vi", "en" });
            comboBox1.Location = new Point(171, 354);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(189, 28);
            comboBox1.TabIndex = 22;
            // 
            // lblLanguage
            // 
            lblLanguage.AutoSize = true;
            lblLanguage.Font = new Font("Tahoma", 10.2F);
            lblLanguage.Location = new Point(39, 357);
            lblLanguage.Name = "lblLanguage";
            lblLanguage.Size = new Size(87, 21);
            lblLanguage.TabIndex = 21;
            lblLanguage.Text = "Ngôn ngữ:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(171, 321);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(189, 27);
            dateTimePicker1.TabIndex = 20;
            // 
            // lblDoB
            // 
            lblDoB.AutoSize = true;
            lblDoB.Font = new Font("Tahoma", 10.2F);
            lblDoB.Location = new Point(39, 326);
            lblDoB.Name = "lblDoB";
            lblDoB.Size = new Size(88, 21);
            lblDoB.TabIndex = 19;
            lblDoB.Text = "Ngày sinh:";
            // 
            // lblSex
            // 
            lblSex.AutoSize = true;
            lblSex.Font = new Font("Tahoma", 10.2F);
            lblSex.Location = new Point(39, 293);
            lblSex.Name = "lblSex";
            lblSex.Size = new Size(77, 21);
            lblSex.TabIndex = 18;
            lblSex.Text = "Giới tính:";
            // 
            // rdBtnFemale
            // 
            rdBtnFemale.AutoSize = true;
            rdBtnFemale.Location = new Point(278, 291);
            rdBtnFemale.Name = "rdBtnFemale";
            rdBtnFemale.Size = new Size(50, 24);
            rdBtnFemale.TabIndex = 17;
            rdBtnFemale.TabStop = true;
            rdBtnFemale.Text = "Nữ";
            rdBtnFemale.UseVisualStyleBackColor = true;
            // 
            // rdBtnMale
            // 
            rdBtnMale.AutoSize = true;
            rdBtnMale.Location = new Point(194, 291);
            rdBtnMale.Name = "rdBtnMale";
            rdBtnMale.Size = new Size(62, 24);
            rdBtnMale.TabIndex = 16;
            rdBtnMale.TabStop = true;
            rdBtnMale.Text = "Nam";
            rdBtnMale.UseVisualStyleBackColor = true;
            // 
            // lblsubtitle
            // 
            lblsubtitle.AutoSize = true;
            lblsubtitle.Font = new Font("Tahoma", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblsubtitle.Location = new Point(195, 71);
            lblsubtitle.Name = "lblsubtitle";
            lblsubtitle.Size = new Size(128, 22);
            lblsubtitle.TabIndex = 15;
            lblsubtitle.Text = "Phiên bản số 5";
            // 
            // lbltitle
            // 
            lbltitle.AutoSize = true;
            lbltitle.Font = new Font("Tahoma", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbltitle.Location = new Point(70, 37);
            lbltitle.Name = "lbltitle";
            lbltitle.Size = new Size(259, 34);
            lbltitle.TabIndex = 0;
            lbltitle.Text = "HÔM NAY ĂN GÌ?";
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(398, 622);
            Controls.Add(splitContainer1);
            Name = "RegisterForm";
            Text = "Đăng ký";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtUsername;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private TextBox txtPsswrd;
        private Label lblUsername;
        private Label lblFirstName;
        private Label lblLastName;
        private Label lblEmail;
        private Label lblPhone;
        private Label lblPsswrd;
        private Button btnLogin;
        private Button btnRegister;
        private Button btnCancel;
        private SplitContainer splitContainer1;
        private Label lbltitle;
        private PictureBox pictureBox1;
        private Label lblsubtitle;
        private RadioButton rdBtnMale;
        private Label lblSex;
        private RadioButton rdBtnFemale;
        private DateTimePicker dateTimePicker1;
        private Label lblDoB;
        private ComboBox comboBox1;
        private Label lblLanguage;
    }
}