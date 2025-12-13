using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai05.Models
{
    public class DishListResponse<T>
    {
        public List<T> data { get; set; } = new();
        public PaginationShow? pagination { get; set; } = new();
    }
}
