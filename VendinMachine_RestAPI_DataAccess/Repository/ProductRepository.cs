using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine_RestAPI_DataAccess.Exceptions;
using VendingMachine_RestAPI_Domain;
using VendingMachine_RestAPI_Logic.Abstaction;

namespace VendinMachine_RestAPI_DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {

        private readonly VendingMachineRestAPI_DBContext _dbContext;
        public ProductRepository(VendingMachineRestAPI_DBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        }

        public async Task Add(Product entity)
        {
            await _dbContext.Products.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var productDB = await GetById(id);

            if (productDB == null)
            {
                throw new EntityNotFoundException(id);
            }

            _dbContext.Products.Remove(productDB);

            await _dbContext.SaveChangesAsync();

        }

        public async Task<Product> Get(int id)
        {
            var productDB = await GetById(id);

            return productDB;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task Update(int id, Product entity)
        {
            var productDB = await GetById(id);

            if (productDB == null)
            {
                throw new EntityNotFoundException(id);
            }

            productDB.ColumnId = entity.ColumnId;
            productDB.Name = entity.Name;
            productDB.Price = entity.Price;
            productDB.Quantity = entity.Quantity;

            await _dbContext.SaveChangesAsync();
        }

        private async Task<Product?> GetById(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(x => x.ColumnId == id);
        }
    }
}
