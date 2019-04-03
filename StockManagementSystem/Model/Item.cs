using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public int CategoryId { get; set; }
        public int ReorderLebel { get; set; }
        public int Quantity { get; set; }
    }
}
