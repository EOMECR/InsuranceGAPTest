using APISolution.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISolution.Entities
{
    public class PolicyCustomer
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int PolicyID { get; set; }
        public Policy Policy { get; set; }
    }
}
