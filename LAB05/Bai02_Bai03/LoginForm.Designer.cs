namespace Bai02_Bai03
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtEmail = new TextBox();
            txt = new TextBox();
            rdSMTP = new RadioButton();
            rdPop3 = new RadioButton();
            btnOK = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(255, 128, 0);
            label1.Location = new Point(143, 20);
            label1.Name = "label1";
            label1.Size = new Size(131, 28);
            label1.TabIndex = 0;
            label1.Text = "ĐỌC MAIL";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(25, 65);
            label2.Name = "label2";
            label2.Size = new Size(46, 18);
            label2.TabIndex = 1;
            label2.Text = "Email:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(25, 100);
            label3.Name = "label3";
            label3.Size = new Size(74, 18);
            label3.TabIndex = 2;
            label3.Text = "Mật khẩu:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(25, 135);
            label4.Name = "label4";
            label4.Size = new Size(75, 18);
            label4.TabIndex = 3;
            label4.Text = "Giao thức:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(120, 65);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(250, 27);
            txtEmail.TabIndex = 4;
            // 
            // txt
            // 
            txt.Location = new Point(120, 100);
            txt.Name = "txt";
            txt.Size = new Size(250, 27);
            txt.TabIndex = 5;
            txt.UseSystemPasswordChar = true;
            // 
            // rdSMTP
            // 
            rdSMTP.AutoSize = true;
            rdSMTP.Location = new Point(155, 135);
            rdSMTP.Name = "rdSMTP";
            rdSMTP.Size = new Size(67, 24);
            rdSMTP.TabIndex = 6;
            rdSMTP.TabStop = true;
            rdSMTP.Text = "SMTP";
            rdSMTP.UseVisualStyleBackColor = true;
            // 
            // rdPop3
            // 
            rdPop3.AutoSize = true;
            rdPop3.Location = new Point(263, 135);
            rdPop3.Name = "rdPop3";
            rdPop3.Size = new Size(65, 24);
            rdPop3.TabIndex = 7;
            rdPop3.TabStop = true;
            rdPop3.Text = "POP3";
            rdPop3.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            btnOK.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnOK.Location = new Point(155, 181);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(100, 30);
            btnOK.TabIndex = 8;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(270, 181);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 30);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Hủy bỏ";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(392, 223);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(rdPop3);
            Controls.Add(rdSMTP);
            Controls.Add(txt);
            Controls.Add(txtEmail);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "LoginForm";
            ShowIcon = false;
            Text = "Đăng nhập";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtEmail;
        private TextBox txt;
        private RadioButton rdSMTP;
        private RadioButton rdPop3;
        private Button btnOK;
        private Button btnCancel;
    }
}
