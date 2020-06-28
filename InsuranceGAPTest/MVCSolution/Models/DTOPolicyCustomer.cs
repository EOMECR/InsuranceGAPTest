using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSolution.Models
{
    public class DTOPolicyCustomer
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }
        public int PolicyID { get; set; }
        [Display(Name = "Coverage Name")]
        public string PolicyName { get; set; }
    }
}
