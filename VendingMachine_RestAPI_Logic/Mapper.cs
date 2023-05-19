using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine_RestAPI_Domain;
using VendingMachine_RestAPI_Logic.APIModels.Request;

namespace VendingMachine_RestAPI_Logic
{
    public class Mapper
    {
        public static Product CreateOrUpdateProductDTOToProductDbModel(CreateOrUpdateProductRequest request)
        {
            return new Product(request.ColumnId, request.Name, request.Price, request.Quantity);
        }

        public static APIModels.ProductDTO ProductDbModelToProductDTO(Product product)
        {
            return new APIModels.ProductDTO()
            {
                ColumnId = product.ColumnId,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity
            };
        }

        public static Sale CreateOrUpdateSaleDTOToSaleDbModel(CreateOrUpdateSaleRequest request)
        {
            return new Sale( request.ProductName, request.Price, request.PaymentMethod);
        }
        public static APIModels.SaleDTO SaleDbModelToSaleDTO(Sale sale)
        {
            return new APIModels.SaleDTO()
            {
                DateTime = sale.DateTime,
                ProductName = sale.ProductName,
                Price = sale.Price,
                PaymentMethod = sale.PaymentMethod
            };
        }
    }
}
