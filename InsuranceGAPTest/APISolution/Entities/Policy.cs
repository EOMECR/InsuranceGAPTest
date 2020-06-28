using APISolution.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APISolution.Entities
{
    public class Policy 
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string Description { get; set; }
        [Column(TypeName = "int")]
        public int CoveragePercentage { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartPolicyDateTime { get; set; }
        [Column(TypeName = "int")]
        public int CoverageTime { get; set; }
        [Column(TypeName = "float")]
        public float Price { get; set; }
        public RiskTypeEnum RiskType { get; set; }
        public ICollection<PolicyCustomer> PolicyCustomers { get; set; }

        public enum RiskTypeEnum
        {
            Low = 1,
            Medium = 2,
            Medium_High = 3,
            High = 4
        }
    }
}
