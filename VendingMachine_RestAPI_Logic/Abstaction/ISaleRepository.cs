using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine_RestAPI_Domain;

namespace VendingMachine_RestAPI_Logic.Abstaction
{
    public interface ISaleRepository
    {
        Task AddSale(Sale entity);

        Task <List<Sale>> GetAll();
    }
}
