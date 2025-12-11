namespace Bai01
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
            btnSend = new Button();
            grpSMTPServer = new GroupBox();
            txtPsswrd = new TextBox();
            label5 = new Label();
            txtFrom = new TextBox();
            label1 = new Label();
            grpContent = new GroupBox();
            rtbBody = new RichTextBox();
            txtSubject = new TextBox();
            txtTo = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            grpSMTPServer.SuspendLayout();
            grpContent.SuspendLayout();
            SuspendLayout();
            // 
            // btnSend
            // 
            btnSend.Location = new Point(456, 495);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(100, 30);
            btnSend.TabIndex = 26;
            btnSend.Text = "Gửi";
            btnSend.UseVisualStyleBackColor = true;
            // 
            // grpSMTPServer
            // 
            grpSMTPServer.Controls.Add(txtPsswrd);
            grpSMTPServer.Controls.Add(label5);
            grpSMTPServer.Controls.Add(txtFrom);
            grpSMTPServer.Controls.Add(label1);
            grpSMTPServer.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grpSMTPServer.Location = new Point(26, 21);
            grpSMTPServer.Name = "grpSMTPServer";
            grpSMTPServer.Size = new Size(530, 100);
            grpSMTPServer.TabIndex = 27;
            grpSMTPServer.TabStop = false;
            grpSMTPServer.Text = "Khởi tạo SMTP Server";
            // 
            // txtPsswrd
            // 
            txtPsswrd.Location = new Point(110, 60);
            txtPsswrd.Name = "txtPsswrd";
            txtPsswrd.Size = new Size(400, 26);
            txtPsswrd.TabIndex = 26;
            txtPsswrd.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(15, 60);
            label5.Name = "label5";
            label5.Size = new Size(74, 18);
            label5.TabIndex = 25;
            label5.Text = "Mật khẩu:";
            // 
            // txtFrom
            // 
            txtFrom.Location = new Point(110, 25);
            txtFrom.Name = "txtFrom";
            txtFrom.Size = new Size(400, 26);
            txtFrom.TabIndex = 24;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(15, 25);
            label1.Name = "label1";
            label1.Size = new Size(32, 18);
            label1.TabIndex = 23;
            label1.Text = "Từ:";
            // 
            // grpContent
            // 
            grpContent.Controls.Add(rtbBody);
            grpContent.Controls.Add(txtSubject);
            grpContent.Controls.Add(txtTo);
            grpContent.Controls.Add(label4);
            grpContent.Controls.Add(label3);
            grpContent.Controls.Add(label2);
            grpContent.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grpContent.Location = new Point(26, 129);
            grpContent.Name = "grpContent";
            grpContent.Size = new Size(530, 360);
            grpContent.TabIndex = 28;
            grpContent.TabStop = false;
            grpContent.Text = "Gửi gmail";
            // 
            // rtbBody
            // 
            rtbBody.Location = new Point(110, 95);
            rtbBody.Name = "rtbBody";
            rtbBody.Size = new Size(400, 250);
            rtbBody.TabIndex = 31;
            rtbBody.Text = "";
            // 
            // txtSubject
            // 
            txtSubject.Location = new Point(110, 60);
            txtSubject.Name = "txtSubject";
            txtSubject.Size = new Size(400, 26);
            txtSubject.TabIndex = 30;
            // 
            // txtTo
            // 
            txtTo.Location = new Point(110, 25);
            txtTo.Name = "txtTo";
            txtTo.Size = new Size(400, 26);
            txtTo.TabIndex = 29;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(15, 95);
            label4.Name = "label4";
            label4.Size = new Size(70, 18);
            label4.TabIndex = 28;
            label4.Text = "Nội dung:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(15, 60);
            label3.Name = "label3";
            label3.Size = new Size(63, 18);
            label3.TabIndex = 27;
            label3.Text = "Tiêu đề:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(15, 25);
            label2.Name = "label2";
            label2.Size = new Size(39, 18);
            label2.TabIndex = 26;
            label2.Text = "Đến:";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 533);
            Controls.Add(grpContent);
            Controls.Add(grpSMTPServer);
            Controls.Add(btnSend);
            Name = "MainForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gửi mail";
            grpSMTPServer.ResumeLayout(false);
            grpSMTPServer.PerformLayout();
            grpContent.ResumeLayout(false);
            grpContent.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnSend;
        private GroupBox grpSMTPServer;
        private TextBox txtPsswrd;
        private Label label5;
        private TextBox txtFrom;
        private Label label1;
        private GroupBox grpContent;
        private RichTextBox rtbBody;
        private TextBox txtSubject;
        private TextBox txtTo;
        private Label label4;
        private Label label3;
        private Label label2;
    }
}