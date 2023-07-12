using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Application.Common.Interfaces;

namespace Infrastructure.Persistence.Contexts
{
    public class HDIContext : DbContext, IHDIContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }

        public HDIContext(DbContextOptions<HDIContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Configurations
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Ignores
            //modelBuilder.Ignore<User>();
            //modelBuilder.Ignore<Role>();
            //modelBuilder.Ignore<UserRole>();
            //modelBuilder.Ignore<RoleClaim>();
            //modelBuilder.Ignore<UserToken>();
            //modelBuilder.Ignore<UserClaim>();
            //modelBuilder.Ignore<UserLogin>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
