using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine_RestAPI_Domain;

namespace VendingMachine_RestAPI_Logic.Abstaction
{
    public interface IProductRepository
    {
        Task Add(Product entity);
        Task<Product> Get(int id);
        Task<List<Product>> GetAll();
        Task Delete(int id);
        Task Update(int id, Product entity);
    }
}
