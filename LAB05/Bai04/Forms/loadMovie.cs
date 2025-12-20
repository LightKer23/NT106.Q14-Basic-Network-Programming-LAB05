using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bai04.Data;

namespace Bai04.Forms
{
    public partial class loadMovie : Form
    {
        private readonly MovieScraper scraper = new();

        public Movie? SelectedMovie { get; private set; }

        public loadMovie()
        {
            InitializeComponent();
        }

        private async void loadMovie_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            progressBar1.Value = 0;

            var progress = new Progress<int>(p =>
            {
                if (p < 0) p = 0;
                if (p > 100) p = 100;
                progressBar1.Value = p;
            });

            List<Movie> movies;
            try
            {
                movies = await scraper.GetMovies(progress);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được danh sách phim.\n\nChi tiết: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                movies = new List<Movie>();
            }

            foreach (var mv in movies)
            {
                var banner = new movieBanner(mv)
                {
                    Width = flowLayoutPanel1.ClientSize.Width - 25,
                    Margin = new Padding(4)
                };

                banner.BannerClick += Banner_Click;
                flowLayoutPanel1.Controls.Add(banner);
            }

            progressBar1.Value = 100;
        }

        private void Banner_Click(Movie mv)
        {
            SelectedMovie = mv;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
