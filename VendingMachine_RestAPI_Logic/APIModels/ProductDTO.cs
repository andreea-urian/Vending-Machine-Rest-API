using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine_RestAPI_Logic.APIModels
{
    public class ProductDTO
    {
        public int ColumnId { get; set; }
        public string? Name { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
    }
}
