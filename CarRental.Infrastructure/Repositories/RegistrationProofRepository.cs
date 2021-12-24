using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarRental.Core.Domain;
using CarRental.Core.Repository;

namespace CarRental.Infrastructure.Repositories
{
    class RegistrationProofRepository : IRegistrationProofRepository
    {
        public Task AddAsync(RegistrationProof r)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RegistrationProof>> BrowseAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(RegistrationProof r)
        {
            throw new NotImplementedException();
        }

        public Task<RegistrationProof> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(RegistrationProof r)
        {
            throw new NotImplementedException();
        }
    }
}
