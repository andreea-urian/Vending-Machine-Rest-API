using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine_RestAPI_Domain;
using VendingMachine_RestAPI_Logic.Abstaction;

namespace VendinMachine_RestAPI_DataAccess.Repository
{
    public class SaleRepository:ISaleRepository
    {
        private readonly VendingMachineRestAPI_DBContext _dbContext;

        public SaleRepository(VendingMachineRestAPI_DBContext dbContext)
        {
            _dbContext = dbContext??throw new ArgumentNullException(nameof(_dbContext));
        }

        public async Task AddSale(Sale entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _dbContext.Sales.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Sale>> GetAll()
        {
            return await _dbContext.Sales.ToListAsync();;
        }
    }
}
