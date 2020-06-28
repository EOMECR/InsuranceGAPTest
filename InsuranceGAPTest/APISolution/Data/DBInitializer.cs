using APISolution.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace APISolution.Data
{
    public static class DBInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var _context = new APISolutionContext (serviceProvider.GetRequiredService<DbContextOptions<APISolutionContext>>()))
            {

                // Add Customers
                if (_context.Customers.Any())
                {
                    return;
                }

                _context.Customers.AddRange(
                    new Customer
                    {
                       Email = "Customer1@admin.com",
                       Name = "UserOne",
                       LastName = "Testing"
                       //Id= 1
                    },

                    new Customer
                    {
                        Email = "Customer2@admin.com",
                        Name = "UserTwo",
                        LastName = "Testing"
                        //Id = 2
                    },

                    new Customer
                    {
                        Email = "Customer3@admin.com",
                        Name = "UserThree",
                        LastName = "Testing"
                        //Id = 3
                    },

                    new Customer
                    {
                        Email = "Customer4@admin.com",
                        Name = "UserFour",
                        LastName = "Testing"
                        //Id = 4
                    }
                );

                // Add Customers
                if (_context.Policies.Any())
                {
                    return;
                }

                _context.Policies.AddRange(
                    new Policy
                    {
                       //Id = 1,
                       Name = "Policy 1",
                       CoveragePercentage = 15,
                       CoverageTime = 3,
                       Description = "Demo Policy 1",
                       Price = 250.25f,
                       StartPolicyDateTime = DateTime.Parse("2020/01/03"),
                       RiskType = Policy.RiskTypeEnum.Low
                    },

                     new Policy
                     {
                         //Id = 2,
                         Name = "Policy 2",
                         CoveragePercentage = 45,
                         CoverageTime = 6,
                         Description = "Demo Policy 2",
                         Price = 120.26f,
                         StartPolicyDateTime = DateTime.Parse("2020/05/02"),
                         RiskType = Policy.RiskTypeEnum.Medium_High
                     }
                );

                _context.SaveChanges();
            }
        }
    }
}
