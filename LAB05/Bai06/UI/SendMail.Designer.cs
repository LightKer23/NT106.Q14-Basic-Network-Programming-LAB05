namespace Bai06.UI
{
    partial class SendMail
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
            label1 = new Label();
            txtFrom = new TextBox();
            txtTo = new TextBox();
            label2 = new Label();
            txtName = new TextBox();
            label3 = new Label();
            txtSubject = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            chkHTML = new CheckBox();
            rtbContent = new RichTextBox();
            txtBrowse = new TextBox();
            btnBrowse = new Button();
            btnSend = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(29, 20);
            label1.TabIndex = 0;
            label1.Text = "Từ:";
            // 
            // txtFrom
            // 
            txtFrom.Location = new Point(122, 16);
            txtFrom.Name = "txtFrom";
            txtFrom.ReadOnly = true;
            txtFrom.Size = new Size(322, 27);
            txtFrom.TabIndex = 1;
            // 
            // txtTo
            // 
            txtTo.Location = new Point(122, 82);
            txtTo.Name = "txtTo";
            txtTo.Size = new Size(322, 27);
            txtTo.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 85);
            label2.Name = "label2";
            label2.Size = new Size(64, 20);
            label2.TabIndex = 2;
            label2.Text = "Gửi đến:";
            // 
            // txtName
            // 
            txtName.Location = new Point(122, 49);
            txtName.Name = "txtName";
            txtName.Size = new Size(322, 27);
            txtName.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 52);
            label3.Name = "label3";
            label3.Size = new Size(104, 20);
            label3.TabIndex = 4;
            label3.Text = "Tên người gửi:";
            // 
            // txtSubject
            // 
            txtSubject.Location = new Point(122, 115);
            txtSubject.Name = "txtSubject";
            txtSubject.Size = new Size(322, 27);
            txtSubject.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 118);
            label4.Name = "label4";
            label4.Size = new Size(61, 20);
            label4.TabIndex = 6;
            label4.Text = "Tiêu đề:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 154);
            label5.Name = "label5";
            label5.Size = new Size(78, 20);
            label5.TabIndex = 8;
            label5.Text = "Định dạng";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(129, 157);
            label6.Name = "label6";
            label6.Size = new Size(0, 20);
            label6.TabIndex = 9;
            // 
            // chkHTML
            // 
            chkHTML.AutoSize = true;
            chkHTML.Location = new Point(96, 153);
            chkHTML.Name = "chkHTML";
            chkHTML.Size = new Size(70, 24);
            chkHTML.TabIndex = 10;
            chkHTML.Text = "HTML";
            chkHTML.UseVisualStyleBackColor = true;
            // 
            // rtbContent
            // 
            rtbContent.Location = new Point(12, 177);
            rtbContent.Name = "rtbContent";
            rtbContent.Size = new Size(432, 241);
            rtbContent.TabIndex = 11;
            rtbContent.Text = "";
            // 
            // txtBrowse
            // 
            txtBrowse.Location = new Point(12, 424);
            txtBrowse.Name = "txtBrowse";
            txtBrowse.ReadOnly = true;
            txtBrowse.Size = new Size(328, 27);
            txtBrowse.TabIndex = 12;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(346, 424);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(97, 29);
            btnBrowse.TabIndex = 13;
            btnBrowse.Text = "Thư mục";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(346, 459);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(94, 29);
            btnSend.TabIndex = 14;
            btnSend.Text = "Gửi";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // SendMail
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(455, 497);
            Controls.Add(btnSend);
            Controls.Add(btnBrowse);
            Controls.Add(txtBrowse);
            Controls.Add(rtbContent);
            Controls.Add(chkHTML);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(txtSubject);
            Controls.Add(label4);
            Controls.Add(txtName);
            Controls.Add(label3);
            Controls.Add(txtTo);
            Controls.Add(label2);
            Controls.Add(txtFrom);
            Controls.Add(label1);
            Name = "SendMail";
            Text = "SendMail";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtFrom;
        private TextBox txtTo;
        private Label label2;
        private TextBox txtName;
        private Label label3;
        private TextBox txtSubject;
        private Label label4;
        private Label label5;
        private Label label6;
        private CheckBox chkHTML;
        private RichTextBox rtbContent;
        private TextBox txtBrowse;
        private Button btnBrowse;
        private Button btnSend;
    }
}