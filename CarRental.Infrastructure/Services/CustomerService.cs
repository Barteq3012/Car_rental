using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarRental.Core.Repository;
using CarRental.Infrastructure.DTO;

namespace CarRental.Infrastructure.Services
{
    public class CustomerService : ICustomerService
    {        
        public Task<IEnumerable<CustomerDTO>> BrowseAll()
        {
            throw new NotImplementedException();
        }
    }
}
