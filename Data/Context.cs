using Microsoft.EntityFrameworkCore;
using OrderProject.Models;

namespace OrderProject.Data
{
    public class Context : DbContext
    {
        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OutsourcingCompany> OutsourcingCompanyes { get; set; }

        public Context(DbContextOptions<Context> dbContext) : base(dbContext)
        {
            Database.Migrate();
        }
    }
}
