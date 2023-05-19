using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine_RestAPI_Domain;
using VendingMachine_RestAPI_Logic.APIModels;
using VendingMachine_RestAPI_Logic.APIModels.Request;

namespace VendingMachine_RestAPI_Logic.Abstaction
{
    public interface ISaleService
    {
        Task Add(CreateOrUpdateSaleRequest item);
        Task <List<SaleDTO>>GetSales();
    }
}
