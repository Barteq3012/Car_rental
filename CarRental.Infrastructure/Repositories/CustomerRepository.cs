using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarRental.Core.Domain;
using CarRental.Core.Repository;

namespace CarRental.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public Task AddAsync(Customer c)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> BrowseAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Customer c)
        {
            throw new NotImplementedException();
        }
    }
}
