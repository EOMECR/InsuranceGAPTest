using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSolution.Models
{
    public class PolicyCustomer
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int PolicyID { get; set; }        
    }
}
