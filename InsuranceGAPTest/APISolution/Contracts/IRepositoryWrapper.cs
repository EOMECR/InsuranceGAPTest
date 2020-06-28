using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISolution.Contracts
{
    public interface IRepositoryWrapper
    {
        IPolicyRepository Policy { get; }
        ICustomerRepository Customer { get; }
        void Save();
    }
}
