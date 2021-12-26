using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarRental.Core.Repository;
using CarRental.Infrastructure.Commands;
using CarRental.Infrastructure.DTO;

namespace CarRental.Infrastructure.Services
{
    public class RentService : IRentService
    {
        public Task Add(CreateRent rent)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RentDTO>> BrowseAll()
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RentDTO> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(UpdateRent rent, int id)
        {
            throw new NotImplementedException();
        }
    }
}
