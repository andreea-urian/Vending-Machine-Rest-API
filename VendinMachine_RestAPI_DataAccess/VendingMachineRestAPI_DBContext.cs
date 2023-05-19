using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine_RestAPI_Domain;

namespace VendinMachine_RestAPI_DataAccess
{
    public class VendingMachineRestAPI_DBContext:DbContext
    {
        public VendingMachineRestAPI_DBContext(DbContextOptions<VendingMachineRestAPI_DBContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
    }
}
