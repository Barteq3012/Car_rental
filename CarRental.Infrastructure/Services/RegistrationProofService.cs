using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarRental.Core.Repository;
using CarRental.Infrastructure.Commands;
using CarRental.Infrastructure.DTO;

namespace CarRental.Infrastructure.Services
{
    public class RegistrationProofService : IRegistrationProofService
    {
        public Task Add(CreateRegistrationProof registrationProof)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RegistrationProofDTO>> BrowseAll()
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RegistrationProofDTO> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(UpdateRegistrationProof registrationProof, int id)
        {
            throw new NotImplementedException();
        }
    }
}
