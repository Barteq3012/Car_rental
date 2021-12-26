using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarRental.Infrastructure.Commands;
using CarRental.Infrastructure.DTO;

namespace CarRental.Infrastructure.Services
{
    public interface IRentService
    {
        Task<IEnumerable<RentDTO>> BrowseAll();
        Task<RentDTO> Get(int id);
        Task Delete(int id);
        Task Add(CreateRent rent);
        Task Update(UpdateRent rent, int id);
    }
}
