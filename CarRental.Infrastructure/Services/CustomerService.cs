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
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
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
                    Company = new Company()
                    {
                        Id = c.Company.Id,
                        Name = c.Company.Name,
                        Address = c.Company.Address,
                        Country = c.Company.Country
                    }
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
                Company = mapCompanyToDTO(x.Company)
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

            return mapCustomerToDTO(c);
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
                    Company = new Company()
                    {
                        Id = c.Company.Id,
                        Name = c.Company.Name,
                        Address = c.Company.Address,
                        Country = c.Company.Country
                    }
                };
            }
            catch (System.NullReferenceException e)
            {
                Console.WriteLine(e.ToString());
                await Task.FromException(e);
            }

            await _customerRepository.UpdateAsync(customer);
        }

        private CustomerDTO mapCustomerToDTO(Customer c)
        {
            if (c == null)
            {
                return null;
            }
            else
            {
                var cDTO = new CustomerDTO()
                {
                    Id = c.Id,
                    Name = c.Name,
                    SecondName = c.SecondName,
                    BirthDate = c.BirthDate,
                    Country = c.Country,
                    Company = mapCompanyToDTO(c.Company)
                };
                return cDTO;
            }
        }

        private CompanyDTO mapCompanyToDTO(Company c)
        {
            if (c == null)
            {
                return null;
            }
            else
            {
                var cDTO = new CompanyDTO()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Address = c.Address,
                    Country = c.Country
                };
                return cDTO;
            }
        }

    }
}
