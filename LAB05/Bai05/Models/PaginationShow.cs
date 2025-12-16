using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bai05.Models
{
    public class PaginationShow
    {
        public int current { get; set; }
        public int total { get; set; }
        public int pageSize { get; set; }

        [JsonPropertyName("page_size")]
        public int page_size
        {
            get => pageSize;
            set => pageSize = value;
        }
    }
}
