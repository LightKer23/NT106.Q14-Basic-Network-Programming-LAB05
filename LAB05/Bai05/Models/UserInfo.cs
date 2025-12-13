using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Bai05.Models
{
    public class UserInfo
    {
        public string username { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public string? first_name { get; set; } = string.Empty;
        public string? last_name { get; set; } = string.Empty;
        public int sex { get; set; }
        public DateTime? birthday { get; set; }
        public string? language { get; set; } = string.Empty;
        public string? phone { get; set; } = string.Empty;

        [JsonIgnore]
        public string? token { get; set; } = string.Empty;
    }
}
