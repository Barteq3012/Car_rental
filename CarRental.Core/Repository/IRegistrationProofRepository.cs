using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarRental.Core.Domain;

namespace CarRental.Core.Repository
{
    public interface IRegistrationProofRepository
    {
        Task<IEnumerable<RegistrationProof>> BrowseAllAsync();
        Task<RegistrationProof> GetAsync(int id);
        Task AddAsync(RegistrationProof r);
        Task DeleteAsync(RegistrationProof r);
        Task UpdateAsync(RegistrationProof r);
    }
}
