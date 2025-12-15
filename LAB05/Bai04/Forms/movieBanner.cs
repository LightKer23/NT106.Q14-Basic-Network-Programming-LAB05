using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bai04.Data;

namespace Bai04.Forms
{
    public partial class movieBanner : UserControl
    {
        public Movie Data { get; private set; }
        public event Action<Movie>? BannerClick;

        public movieBanner(Movie mv)
        {
            InitializeComponent();
            Data = mv;

            movieName.Text = mv.Title;
            LoadPoster();

            this.Click += ClickBanner;
            pictureBox1.Click += ClickBanner;
            movieName.Click += ClickBanner;
        }

        private async void LoadPoster()
        {
            try
            {
                var client = new HttpClient();
                var bytes = await client.GetByteArrayAsync(Data.PosterUrl);
                using var ms = new MemoryStream(bytes);
                pictureBox1.Image = Image.FromStream(ms);
            }
            catch { }   
        }


        private void ClickBanner(object? sender, EventArgs e)
        {
            BannerClick?.Invoke(Data);
        }
    }
}
