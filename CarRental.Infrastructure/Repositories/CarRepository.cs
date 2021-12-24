using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarRental.Core.Domain;
using CarRental.Core.Repository;

namespace CarRental.Infrastructure.Repositories
{
    class CarRepository : ICarRepository
    {
        public Task AddAsync(Car c)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Car>> BrowseAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Car c)
        {
            throw new NotImplementedException();
        }

        public Task<Car> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Car c)
        {
            throw new NotImplementedException();
        }
    }
}
