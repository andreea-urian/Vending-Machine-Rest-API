using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine_RestAPI_Domain;
using VendingMachine_RestAPI_Logic.Abstaction;
using VendingMachine_RestAPI_Logic.APIModels;
using VendingMachine_RestAPI_Logic.APIModels.Request;

namespace VendingMachine_RestAPI_Logic
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        public SaleService(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository ?? throw new ArgumentNullException(nameof(_saleRepository)) ;
        }

        public async Task Add(CreateOrUpdateSaleRequest item)
        {
            var sale= Mapper.CreateOrUpdateSaleDTOToSaleDbModel(item);
            await _saleRepository.AddSale(sale);
        }

        public async Task<List<SaleDTO>> GetSales()
        {
            var results = new List<SaleDTO>();
            var resultsFromRepo = await _saleRepository.GetAll();

            resultsFromRepo.ForEach(x => results.Add(Mapper.SaleDbModelToSaleDTO(x)));

            return results;
        }
    }
}
