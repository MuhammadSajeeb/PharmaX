using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P.Core.Models
{
    public class Stocks
    {
        public string Name { get; set; }
        public int  Batch { get; set; }
        public decimal TotalQty { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SellingPrice { get; set; }
    }
}
