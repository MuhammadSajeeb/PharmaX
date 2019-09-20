using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P.Core.Models
{
    public class Items
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string GenericName { get; set; }
        public int ReorderLevel { get; set; }
        public int CategoriesId { get; set; }
        public int ShelfsId { get; set; }    

    }
}
