using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bai04.Data;
using HtmlAgilityPack;
using System.Net.Http;
using System.Reflection;
using System.Xml;

namespace Bai04.Data
{
    internal class MovieScraper
    {
        private readonly HttpClient http = new();

        private const string URL = "https://betacinemas.vn/phim.htm";

        public async Task<List<Movie>> GetMovies(IProgress<int>? progress = null)
        {
            var list = new List<Movie>();

            string html = await http.GetStringAsync(URL);
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            var infoBlocks = doc.DocumentNode
                .SelectNodes("//div[contains(@class,'film-info') and contains(@class,'film-xs-info')]");

            if (infoBlocks == null) return list;

            int i = 0;
            int total = infoBlocks.Count;

            foreach (var info in infoBlocks)
            {
                i++;
                progress?.Report(i * 100 / total);

                var linkNode = info.SelectSingleNode(".//h3//a[contains(@href,'chi-tiet-phim')]");
                string title = HtmlEntity.DeEntitize(linkNode?.InnerText ?? "").Trim();

                string href = linkNode?.GetAttributeValue("href", "") ?? "";
                if (!string.IsNullOrEmpty(href) && href.StartsWith("/"))
                    href = "https://betacinemas.vn" + href;
                else if (string.IsNullOrEmpty(href))
                    href = "https://betacinemas.vn";

                if (string.IsNullOrWhiteSpace(title))
                    title = "Unknown";

                var row = info.ParentNode?.ParentNode;
                var imgNode = row?.SelectSingleNode(".//div[contains(@class,'pi-img-wrapper')]//img");
                string poster = imgNode?.GetAttributeValue("src", "") ?? "";

                list.Add(new Movie
                {
                    Title = title,
                    PosterUrl = poster
                });
            }

            return list;
        }

    }
}