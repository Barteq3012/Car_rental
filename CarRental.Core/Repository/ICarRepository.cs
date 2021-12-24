using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarRental.Core.Domain;

namespace CarRental.Core.Repository
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> BrowseAllAsync();
        Task<Car> GetAsync(int id);
        Task AddAsync(Car c);
        Task DeleteAsync(Car c);
        Task UpdateAsync(Car c);
    }
}
