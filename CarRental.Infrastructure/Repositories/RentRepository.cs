using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarRental.Core.Domain;
using CarRental.Core.Repository;

namespace CarRental.Infrastructure.Repositories
{
    public class RentRepository : IRentRepository
    {
        public Task AddAsync(Rent r)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Rent>> BrowseAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Rent> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Rent r)
        {
            throw new NotImplementedException();
        }
    }
}
