using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IHDIContext
    {
        DbSet<User> User { get; set; }
        DbSet<Product> Product { get; set; }
        DbSet<Customer> Customer { get; set; }
        DbSet<Sale> Sale { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        int SaveChanges();
    }
}
