using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarRental.Core.Domain;

namespace CarRental.Core.Repository
{
    public interface IRentRepository
    {
        Task<IEnumerable<Rent>> BrowseAllAsync();
        Task<Rent> GetAsync(int id);
        Task AddAsync(Rent r);
        Task DeleteAsync(int id);
        Task UpdateAsync(Rent r);
    }
}
