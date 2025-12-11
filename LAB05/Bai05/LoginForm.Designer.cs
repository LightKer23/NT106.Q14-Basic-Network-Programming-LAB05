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
            btndangnhap = new Button();
            txtusername = new TextBox();
            txtpassword = new TextBox();
            pictureBox1 = new PictureBox();
            lblusername = new Label();
            lblpassword = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btndangnhap
            // 
            btndangnhap.Location = new Point(469, 116);
            btndangnhap.Name = "btndangnhap";
            btndangnhap.Size = new Size(94, 29);
            btndangnhap.TabIndex = 1;
            btndangnhap.Text = "Đăng nhập";
            btndangnhap.UseVisualStyleBackColor = true;
            btndangnhap.Click += button1_Click;
            // 
            // txtusername
            // 
            txtusername.Location = new Point(281, 116);
            txtusername.Name = "txtusername";
            txtusername.Size = new Size(125, 27);
            txtusername.TabIndex = 2;
            // 
            // txtpassword
            // 
            txtpassword.Location = new Point(281, 172);
            txtpassword.Name = "txtpassword";
            txtpassword.Size = new Size(125, 27);
            txtpassword.TabIndex = 3;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Logo_UIT_In;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(147, 125);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // lblusername
            // 
            lblusername.AutoSize = true;
            lblusername.Location = new Point(183, 119);
            lblusername.Name = "lblusername";
            lblusername.Size = new Size(32, 20);
            lblusername.TabIndex = 5;
            lblusername.Text = "Tên";
            // 
            // lblpassword
            // 
            lblpassword.AutoSize = true;
            lblpassword.Location = new Point(188, 175);
            lblpassword.Name = "lblpassword";
            lblpassword.Size = new Size(70, 20);
            lblpassword.TabIndex = 6;
            lblpassword.Text = "Password";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblpassword);
            Controls.Add(lblusername);
            Controls.Add(pictureBox1);
            Controls.Add(txtpassword);
            Controls.Add(txtusername);
            Controls.Add(btndangnhap);
            Name = "LoginForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txturl;
        private Button btndangnhap;
        private TextBox txtusername;
        private TextBox txtpassword;
        private PictureBox pictureBox1;
        private Label lblusername;
        private Label lblpassword;
    }
}
