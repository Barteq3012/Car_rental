using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarRental.Core.Domain;

namespace CarRental.Core.Repository
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> BrowseAllAsync();
        Task<Customer> GetAsync(int id);
        Task AddAsync(Customer c);
        Task DeleteAsync(Customer c);
        Task UpdateAsync(Customer c);
    }
}
