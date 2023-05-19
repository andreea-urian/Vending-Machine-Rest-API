using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine_RestAPI_Logic.APIModels
{
    public class SaleDTO
    {
        [DataMember]
        public DateTime DateTime { get; set; }

        [DataMember]
        public string ProductName { get; set; }

        [DataMember]
        public float Price { get; set; }

        [DataMember]
        public string PaymentMethod { get; set; }
    }
}
