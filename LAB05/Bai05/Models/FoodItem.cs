using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai05.Models
{
    public class FoodItem
    {
        public int id { get; set; }
        public string? ten_mon_an { get; set; } = string.Empty;
        public double gia { get; set; }
        public string? mo_ta { get; set; } = string.Empty;
        public string? hinh_anh { get; set; } = string.Empty;
        public string? dia_chi { get; set; } = string.Empty;
        public string? nguoi_dong_gop { get; set; } = string.Empty;
    }
}
