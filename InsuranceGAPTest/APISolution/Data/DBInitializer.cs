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
                       Email = "juancagarita@admin.com",
                       Name = "Juan Carlos",
                       LastName = "Garita"                       
                    },

                    new Customer
                    {
                        Email = "EmiliaNavas@admin.com",
                        Name = "Emilia Maria",
                        LastName = "Navas"
                    },

                    new Customer
                    {
                        Email = "Enrique@admin.com",
                        Name = "Enrique Josue",
                        LastName = "Morales"
                    },

                    new Customer
                    {
                        Email = "KarlaVanessa@admin.com",
                        Name = "Karla Vannessa",
                        LastName = "Miranda"
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
                       Name = "Riesgo Incendio",
                       CoveragePercentage = 15,
                       CoverageTime = 3,
                       Description = "Póliza de seguro contra incendio",
                       Price = 250.25f,
                       StartPolicyDateTime = DateTime.Parse("2020/01/03"),
                       RiskType = Policy.RiskTypeEnum.Low
                    },

                     new Policy
                     {
                         Name = "Robo tipo 2",
                         CoveragePercentage = 45,
                         CoverageTime = 6,
                         Description = "Encapsula los riesgos de robo tipo 1 y 2",
                         Price = 120.26f,
                         StartPolicyDateTime = DateTime.Parse("2020/05/02"),
                         RiskType = Policy.RiskTypeEnum.Medium_High
                     },
                     new Policy
                     {
                         Name = "Desastres naturales",
                         CoveragePercentage = 40,
                         CoverageTime = 6,
                         Description = "Sujeto a tipo de desastre",
                         Price = 120.26f,
                         StartPolicyDateTime = DateTime.Parse("2020/05/02"),
                         RiskType = Policy.RiskTypeEnum.Medium_High
                     },
                     new Policy
                     {
                         Name = "Terremoto",
                         CoveragePercentage = 75,
                         CoverageTime = 12,
                         Description = "Póliza de cobertura contra terremotos",
                         Price = 120.26f,
                         StartPolicyDateTime = DateTime.Parse("2020/05/02"),
                         RiskType = Policy.RiskTypeEnum.Low 
                     }
                );

                // Add PolicyCustomers
                if (_context.PolicyCustomers.Any())
                {
                    return;
                }

                _context.PolicyCustomers.AddRange(
                    new PolicyCustomer
                    {
                       CustomerId =1,
                       PolicyID = 1
                    },

                    new PolicyCustomer
                    {
                        CustomerId = 2,
                        PolicyID = 1
                    },
                    new PolicyCustomer
                    {
                        CustomerId = 4,
                        PolicyID = 2
                    }
                );

                _context.SaveChanges();
            }
        }
    }
}
