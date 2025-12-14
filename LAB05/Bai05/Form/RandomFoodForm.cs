using Bai05.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai05
{
    public partial class RandomFoodForm : Form
    {
        private readonly FoodItem _food;
        public RandomFoodForm(FoodItem food)
        {
            InitializeComponent();
            _food = food;
        }

        private void RandomFoodForm_Load(object sender, EventArgs e)
        {
            this.Text = $"Ăn {_food.ten_mon_an} đi!!!";
            foodItemControl1.SetData(_food);
        }
    }
}
