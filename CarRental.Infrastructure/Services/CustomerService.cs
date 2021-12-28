using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Core.Domain;
using CarRental.Core.Repository;
using CarRental.Infrastructure.Commands;
using CarRental.Infrastructure.DTO;

namespace CarRental.Infrastructure.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICompanyRepository _companyRepository;
        public CustomerService(ICustomerRepository customerRepository, ICompanyRepository companyRepository)
        {
            _customerRepository = customerRepository;
            _companyRepository = companyRepository;
        }
        public async Task Add(CreateCustomer c)
        {
            Customer customer = null;
            try
            {
                customer = new Customer()
                {
                    Id = c.Id,
                    Name = c.Name,
                    SecondName = c.SecondName,
                    BirthDate = c.BirthDate,
                    Country = c.Country,
                    Company = await _companyRepository.GetAsync(c.CompanyId)
                };
            }
            catch (System.NullReferenceException e)
            {
                Console.WriteLine(e.ToString());
                await Task.FromException(e);
            }

            await _customerRepository.AddAsync(customer);
        }

        public async Task<IEnumerable<CustomerDTO>> BrowseAll()
        {
            var c = await _customerRepository.BrowseAllAsync();

            return c.Select(x => new CustomerDTO()
            {
                Id = x.Id,
                Name = x.Name,
                SecondName = x.SecondName,
                BirthDate = x.BirthDate,
                Country = x.Country,
                Company = MapDomain.mapCompanyToDTO(x.Company)
            });
        }

        public async Task Delete(int id)
        {
            await _customerRepository.DeleteAsync(id);
        }

        public async Task<CustomerDTO> Get(int id)
        {
            var c = await _customerRepository.GetAsync(id);

            if (c == null)
            {
                return null;
            }

            return MapDomain.mapCustomerToDTO(c);
        }

        public async Task Update(UpdateCustomer c, int id)
        {
            Customer customer = null;
            try
            {
                customer = new Customer()
                {
                    Id = id,
                    Name = c.Name,
                    SecondName = c.SecondName,
                    BirthDate = c.BirthDate,
                    Country = c.Country,
                    Company = await _companyRepository.GetAsync(c.CompanyId)
                };
            }
            catch (System.NullReferenceException e)
            {
                Console.WriteLine(e.ToString());
                await Task.FromException(e);
            }

            await _customerRepository.UpdateAsync(customer);
        }
    }
}
