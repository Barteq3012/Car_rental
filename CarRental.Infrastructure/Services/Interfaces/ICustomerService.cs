using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarRental.Infrastructure.Commands;
using CarRental.Infrastructure.DTO;

namespace CarRental.Infrastructure.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDTO>> BrowseAll();
        Task<CustomerDTO> Get(int id);
        Task Delete(int id);
        Task Add(CreateCustomer customer);
        Task Update(UpdateCustomer customer, int id);
    }
}
