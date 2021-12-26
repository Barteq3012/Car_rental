using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarRental.Infrastructure.Commands;
using CarRental.Infrastructure.DTO;

namespace CarRental.Infrastructure.Services
{
    public interface IRegistrationProofService
    {
        Task<IEnumerable<RegistrationProofDTO>> BrowseAll();
        Task<RegistrationProofDTO> Get(int id);
        Task Delete(int id);
        Task Add(CreateRegistrationProof registrationProof);
        Task Update(UpdateRegistrationProof registrationProof, int id);
    }
}
