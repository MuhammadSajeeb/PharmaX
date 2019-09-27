using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P.Core.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public string CustomerContact { get; set; }
        public string SalesId { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal Changes { get; set; }
        public decimal RemainingDue { get; set; }
        public string Status { get; set; }
        public string Date { get; set; }
    }
}
