using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P.Core.Models
{
    public class PurchaseDetails
    {
        public int Id { get; set; }
        public string PurchaseId { get; set; }
        public string Item { get; set; }
        public int Batch { get; set; }
        public decimal Qty { get; set; }
        public decimal CostPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public int SupplierId { get; set; }
        public string Expire { get; set; }
        public string Date { get; set; }
    }
}
