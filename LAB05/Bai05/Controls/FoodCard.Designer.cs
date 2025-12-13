namespace Bai05.Controls
{
    partial class FoodCard
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
            lblName = new Label();
            lblPrice = new Label();
            lblAddress = new Label();
            lblContributor = new Label();
            pbImage = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbImage).BeginInit();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(52, 54);
            lblName.Name = "lblName";
            lblName.Size = new Size(116, 20);
            lblName.TabIndex = 0;
            lblName.Text = "Tên người dùng:";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(52, 92);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(34, 20);
            lblPrice.TabIndex = 1;
            lblPrice.Text = "Giá:";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(52, 130);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(58, 20);
            lblAddress.TabIndex = 2;
            lblAddress.Text = "Địa chỉ:";
            // 
            // lblContributor
            // 
            lblContributor.AutoSize = true;
            lblContributor.Location = new Point(52, 162);
            lblContributor.Name = "lblContributor";
            lblContributor.Size = new Size(124, 20);
            lblContributor.TabIndex = 3;
            lblContributor.Text = "Người đóng góp:";
            // 
            // pbImage
            // 
            pbImage.Location = new Point(411, 162);
            pbImage.Name = "pbImage";
            pbImage.Size = new Size(125, 62);
            pbImage.TabIndex = 4;
            pbImage.TabStop = false;
            // 
            // FoodCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pbImage);
            Controls.Add(lblContributor);
            Controls.Add(lblAddress);
            Controls.Add(lblPrice);
            Controls.Add(lblName);
            Name = "FoodCard";
            Text = "FoodCard";
            ((System.ComponentModel.ISupportInitialize)pbImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private Label lblPrice;
        private Label lblAddress;
        private Label lblContributor;
        private PictureBox pbImage;
    }
}