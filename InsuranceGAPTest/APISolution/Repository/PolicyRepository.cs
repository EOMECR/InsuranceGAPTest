using APISolution.Contracts;
using APISolution.Data;
using APISolution.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISolution.Repository
{
    public class PolicyRepository : RepositoryBase<Policy>, IPolicyRepository
    {
        public PolicyRepository(APISolutionContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}