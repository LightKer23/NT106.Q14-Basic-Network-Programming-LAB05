using Bai05;
using Bai05.User_Controls;

namespace Bai05
{
    partial class RandomFoodForm
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
            foodItemControl1 = new FoodItemControl();
            SuspendLayout();
            // 
            // foodItemControl1
            // 
            foodItemControl1.Location = new Point(0, 0);
            foodItemControl1.Name = "foodItemControl1";
            foodItemControl1.ShowDeleteButton = false;
            foodItemControl1.Size = new Size(600, 155);
            foodItemControl1.TabIndex = 0;
            // 
            // RandomFoodForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(602, 158);
            Controls.Add(foodItemControl1);
            Name = "RandomFoodForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RandomFoodForm";
            Load += RandomFoodForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private FoodItemControl foodItemControl1;
    }
}