using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine_RestAPI_Domain
{
    public class Sale:EntityBase
    {
        [DataMember]
        public DateTime DateTime { get; set; }

        [DataMember]
        public string ProductName { get; set; }

        [DataMember]
        public float Price { get; set; }

        [DataMember]
        public string PaymentMethod { get; set; }

        public Sale(string productName, float price, string paymentMethod)
        {
            DateTime = DateTime.Now;
            ProductName = productName;
            Price = price;
            PaymentMethod = paymentMethod;
        }
    }
}
