using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarRental.Infrastructure.DTO;

namespace CarRental.Infrastructure.Services
{
    public interface IRegistrationProofService
    {
        Task<IEnumerable<RegistrationProofDTO>> BrowseAll();
    }
}
