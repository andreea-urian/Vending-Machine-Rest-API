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
    public interface IProductService
    {
        Task<int> CreateProduct(CreateOrUpdateProductRequest request);
        Task<List<ProductDTO>> GetProducts();
        Task<ProductDTO> GetProductById(int productColumnId);
        Task UpdateProduct(int productColumnId, CreateOrUpdateProductRequest request);
        Task DeleteProduct(int productColumnId);
    }
}
