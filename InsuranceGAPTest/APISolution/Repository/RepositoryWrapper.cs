using APISolution.Contracts;
using APISolution.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISolution.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private APISolutionContext _repoContext;
        private ICustomerRepository _customer;
        private IPolicyRepository _policy;
        public ICustomerRepository Customer
        {
            get
            {
                if (_customer == null)
                {
                    _customer = new CustomerRepository(_repoContext);
                }
                return _customer;
            }
        }

        public IPolicyRepository Policy
        {
            get
            {
                if (_policy == null)
                {
                    _policy = new PolicyRepository(_repoContext);
                }
                return _policy;
            }
        }

        public RepositoryWrapper(APISolutionContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
