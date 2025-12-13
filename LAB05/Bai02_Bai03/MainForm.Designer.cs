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
            btnLogOut = new Button();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { colEmail, colFrom, colTime });
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Location = new Point(45, 40);
            listView1.Name = "listView1";
            listView1.Size = new Size(690, 360);
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
            label1.Location = new Point(474, 418);
            label1.Name = "label1";
            label1.Size = new Size(47, 18);
            label1.TabIndex = 1;
            label1.Text = "Tổng:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(609, 418);
            label2.Name = "label2";
            label2.Size = new Size(73, 18);
            label2.TabIndex = 2;
            label2.Text = "Gần nhất:";
            // 
            // btnLogOut
            // 
            btnLogOut.Location = new Point(45, 412);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(100, 30);
            btnLogOut.TabIndex = 3;
            btnLogOut.Text = "Đăng xuất";
            btnLogOut.UseVisualStyleBackColor = true;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 453);
            Controls.Add(btnLogOut);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listView1);
            Name = "MainForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
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
        private Button btnLogOut;
    }
}