using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISolution.Entities.DTO
{
    public class DTOPolicyCustomer
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int PolicyID { get; set; }
        public string PolicyName { get; set; }
    }
}
