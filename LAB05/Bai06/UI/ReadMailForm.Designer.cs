namespace Bai06.UI
{
    partial class ReadMailForm
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
            txtFrom = new TextBox();
            txtDate = new TextBox();
            rtbBody = new RichTextBox();
            lstAttachments = new ListBox();
            btnSaveAtt = new Button();
            btnReply = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtTo = new TextBox();
            label5 = new Label();
            txtSubject = new Label();
            SuspendLayout();
            // 
            // txtFrom
            // 
            txtFrom.Location = new Point(78, 12);
            txtFrom.Name = "txtFrom";
            txtFrom.ReadOnly = true;
            txtFrom.Size = new Size(267, 27);
            txtFrom.TabIndex = 1;
            // 
            // txtDate
            // 
            txtDate.Location = new Point(78, 66);
            txtDate.Name = "txtDate";
            txtDate.ReadOnly = true;
            txtDate.Size = new Size(136, 27);
            txtDate.TabIndex = 2;
            // 
            // rtbBody
            // 
            rtbBody.Location = new Point(12, 155);
            rtbBody.Name = "rtbBody";
            rtbBody.ReadOnly = true;
            rtbBody.Size = new Size(636, 283);
            rtbBody.TabIndex = 3;
            rtbBody.Text = "";
            // 
            // lstAttachments
            // 
            lstAttachments.FormattingEnabled = true;
            lstAttachments.Location = new Point(659, 192);
            lstAttachments.Name = "lstAttachments";
            lstAttachments.Size = new Size(121, 104);
            lstAttachments.TabIndex = 4;
            // 
            // btnSaveAtt
            // 
            btnSaveAtt.Location = new Point(659, 302);
            btnSaveAtt.Name = "btnSaveAtt";
            btnSaveAtt.Size = new Size(121, 49);
            btnSaveAtt.TabIndex = 5;
            btnSaveAtt.Text = "Lưu ";
            btnSaveAtt.UseVisualStyleBackColor = true;
            btnSaveAtt.Click += btnSaveAtt_Click;
            // 
            // btnReply
            // 
            btnReply.Location = new Point(659, 379);
            btnReply.Name = "btnReply";
            btnReply.Size = new Size(121, 59);
            btnReply.TabIndex = 6;
            btnReply.Text = "Trả lời";
            btnReply.UseVisualStyleBackColor = true;
            btnReply.Click += btnReply_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 15);
            label1.Name = "label1";
            label1.Size = new Size(28, 20);
            label1.TabIndex = 7;
            label1.Text = "TỪ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 73);
            label2.Name = "label2";
            label2.Size = new Size(47, 20);
            label2.TabIndex = 8;
            label2.Text = "NGÀY";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(255, 39);
            label3.Name = "label3";
            label3.Size = new Size(0, 20);
            label3.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(660, 155);
            label4.Name = "label4";
            label4.Size = new Size(120, 25);
            label4.TabIndex = 10;
            label4.Text = "Tệp đính kèm";
            // 
            // txtTo
            // 
            txtTo.Location = new Point(78, 39);
            txtTo.Name = "txtTo";
            txtTo.ReadOnly = true;
            txtTo.Size = new Size(267, 27);
            txtTo.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(25, 46);
            label5.Name = "label5";
            label5.Size = new Size(39, 20);
            label5.TabIndex = 12;
            label5.Text = "ĐẾN";
            // 
            // txtSubject
            // 
            txtSubject.AutoSize = true;
            txtSubject.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtSubject.Location = new Point(12, 112);
            txtSubject.Name = "txtSubject";
            txtSubject.Size = new Size(0, 28);
            txtSubject.TabIndex = 13;
            // 
            // ReadMailForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(800, 450);
            Controls.Add(txtSubject);
            Controls.Add(label5);
            Controls.Add(txtTo);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnReply);
            Controls.Add(btnSaveAtt);
            Controls.Add(lstAttachments);
            Controls.Add(rtbBody);
            Controls.Add(txtDate);
            Controls.Add(txtFrom);
            Name = "ReadMailForm";
            Text = "ReadMailFrom";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtFrom;
        private TextBox txtDate;
        private RichTextBox rtbBody;
        private ListBox lstAttachments;
        private Button btnSaveAtt;
        private Button btnReply;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtTo;
        private Label label5;
        private Label txtSubject;
    }
}