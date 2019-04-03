using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StockOut
    {
        public int Id { get; set; }
        public int Item_id { get; set; }
        public int quantity { get; set; }
        public string OutType { get; set; }
        public DateTime date { get; set; }
    }
}
