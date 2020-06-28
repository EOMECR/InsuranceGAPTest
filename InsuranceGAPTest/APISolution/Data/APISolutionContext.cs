using APISolution.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISolution.Data
{
    public class APISolutionContext : DbContext
    {
        public APISolutionContext(DbContextOptions<APISolutionContext> options)
           : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<PolicyCustomer> PolicyCustomers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PolicyCustomer>()
                .HasKey(pc => new { pc.CustomerId, pc.PolicyID });

            modelBuilder.Entity<PolicyCustomer>()
                .HasOne(pc => pc.Customer)
                .WithMany(b => b.PolicyCustomers)
                .HasForeignKey(pc => pc.CustomerId);

            modelBuilder.Entity<PolicyCustomer>()
                .HasOne(pc => pc.Policy)
                .WithMany(c => c.PolicyCustomers)
                .HasForeignKey(pc => pc.PolicyID);
        }
    }
}
