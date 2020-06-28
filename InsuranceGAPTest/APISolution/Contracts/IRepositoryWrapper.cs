using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISolution.Contracts
{
    public interface IRepositoryWrapper
    {       
        public IPolicyRepository Policy { get; }
        public ICustomerRepository Customer { get; }
        public IPolicyCustomerRepository PolicyCustomer { get; }
        public void Save();
    }
}
