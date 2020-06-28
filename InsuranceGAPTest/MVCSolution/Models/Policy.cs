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
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "Percentage of coverage")]
        public int CoveragePercentage { get; set; }
        [Display(Name = "Starting date")]
        [DataType(DataType.Date)]
        public DateTime StartPolicyDateTime { get; set; }
        [Display(Name = "Months of Coverage")]
        public int CoverageTime { get; set; }
        public float Price { get; set; }
        [Display(Name = "Risk Type")]
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
