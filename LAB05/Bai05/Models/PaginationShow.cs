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

        // value dùng trong code
        public int pageSize { get; set; }

        // API có thể trả page_size
        [JsonPropertyName("page_size")]
        public int page_size
        {
            get => pageSize;
            set => pageSize = value;
        }
    }
}
