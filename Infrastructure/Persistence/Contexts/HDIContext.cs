using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Persistence.Contexts
{
    public class HDIContext : DbContext, IHDIContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Sale> Sale { get; set; }
        public DbSet<WarrantyType> WarrantyType { get; set; }
        public DbSet<Problem> Problem { get; set; }
        public DbSet<SaleWarranty> SaleWarranty { get; set; }
        public DbSet<SaleProblem> SaleProblem { get; set; }

        public HDIContext(DbContextOptions<HDIContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
