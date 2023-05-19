using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine_RestAPI_Logic.APIModels.Request
{
    public class CreateOrUpdateProductRequest
    {
        [Required(ErrorMessage = "Product columnId is required")]
        public int ColumnId { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Product price is required")]
        public float Price { get; set; }

        [Required(ErrorMessage = "Product quantity is required")]
        public int Quantity { get; set; }
    }
}
