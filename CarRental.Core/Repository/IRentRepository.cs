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
        Task DeleteAsync(Rent r);
        Task UpdateAsync(Rent r);
    }
}
