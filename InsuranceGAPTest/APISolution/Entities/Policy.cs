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
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "varchar(500)")]
        [Required]
        public string Description { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int CoveragePercentage { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime StartPolicyDateTime { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int CoverageTime { get; set; }

        [Column(TypeName = "float")]
        [Required]
        public float Price { get; set; }

        [Required]
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
