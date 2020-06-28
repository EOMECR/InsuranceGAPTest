using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSolution.Models
{
    public class Policy
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Percentage of coverage")]
        [Required]
        [Range(1, 100)]
        public int CoveragePercentage { get; set; }

        [Display(Name = "Starting date")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartPolicyDateTime { get; set; }

        [Display(Name = "Months of Coverage")]
        [Required]
        [Range(1, 124)]
        public int CoverageTime { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public float Price { get; set; }

        [Display(Name = "Risk Type")]
        [Required]
        public RiskTypeEnum RiskType { get; set; }

    }

    public enum RiskTypeEnum
    {
        Low = 1,
        Medium = 2,
        Medium_High = 3,
        High = 4
    }
}
