using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine_RestAPI_Logic.APIModels.Request
{
    public class CreateOrUpdateSaleRequest
    {
        [Required(ErrorMessage = "Sale DateTime is required")]
        public DateTime DateTime{ get; set; }

        [Required(ErrorMessage = "Sale Product name is required")]
        public string ?ProductName { get; set; }

        [Required(ErrorMessage = "Sale price is required")]
        public float Price { get; set; }

        [Required(ErrorMessage = "Sale PaymentMethod is required")]
        public string? PaymentMethod { get; set; }
    }
}
