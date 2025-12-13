namespace Bai02_Bai03
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
            listView1 = new ListView();
            colEmail = new ColumnHeader();
            colFrom = new ColumnHeader();
            colTime = new ColumnHeader();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { colEmail, colFrom, colTime });
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Location = new Point(45, 40);
            listView1.Name = "listView1";
            listView1.Size = new Size(690, 270);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // colEmail
            // 
            colEmail.Text = "Email";
            colEmail.Width = 320;
            // 
            // colFrom
            // 
            colFrom.Text = "Từ";
            colFrom.Width = 220;
            // 
            // colTime
            // 
            colTime.Text = "Thời gian";
            colTime.Width = 140;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(490, 330);
            label1.Name = "label1";
            label1.Size = new Size(47, 18);
            label1.TabIndex = 1;
            label1.Text = "Tổng:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(625, 330);
            label2.Name = "label2";
            label2.Size = new Size(61, 18);
            label2.TabIndex = 2;
            label2.Text = "Hiện tại:";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 373);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listView1);
            Name = "MainForm";
            ShowIcon = false;
            Text = "Đọc Mail";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView1;
        private ColumnHeader colEmail;
        private ColumnHeader colFrom;
        private ColumnHeader colTime;
        private Label label1;
        private Label label2;
    }
}