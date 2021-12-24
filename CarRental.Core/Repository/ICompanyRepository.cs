using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarRental.Core.Domain;

namespace CarRental.Core.Repository
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> BrowseAllAsync();
        Task<Company> GetAsync(int id);
        Task AddAsync(Company c);
        Task DeleteAsync(Company c);
        Task UpdateAsync(Company c);
    }
}
