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
        #region Private Variable Members
        private APISolutionContext _repoContext;
        private ICustomerRepository _customer;
        private IPolicyRepository _policy;
        private IPolicyCustomerRepository _policyCustomer;
        #endregion

        #region Properties
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

        public IPolicyCustomerRepository PolicyCustomer
        {
            get
            {
                if (_policyCustomer == null)
                {
                    _policyCustomer = new PolicyCustomerRepository(_repoContext);
                }
                return _policyCustomer;
            }
        }

        public RepositoryWrapper(APISolutionContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        #endregion

        #region Methods

        public void Save()
        {
            _repoContext.SaveChanges();
        }
        #endregion
    }
}
