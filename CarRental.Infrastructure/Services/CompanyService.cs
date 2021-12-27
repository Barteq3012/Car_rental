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
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public async Task Add(CreateCompany c)
        {
            Company company = null;
            try
            {
                company = new Company()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Address = c.Address,
                    Country = c.Country
                };
            }
            catch (System.NullReferenceException e)
            {
                Console.WriteLine(e.ToString());
                await Task.FromException(e);
            }

            await _companyRepository.AddAsync(company);
        }

        public async Task<IEnumerable<CompanyDTO>> BrowseAll()
        {
            var c = await _companyRepository.BrowseAllAsync();

            return c.Select(x => new CompanyDTO()
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                Country = x.Country,
            });
        }

        public async Task Delete(int id)
        {
            await _companyRepository.DeleteAsync(id);
        }

        public async Task<CompanyDTO> Get(int id)
        {
            var c = await _companyRepository.GetAsync(id);

            if (c == null)
            {
                return null;
            }

            return mapCompanyToDTO(c);
        }

        public async Task Update(UpdateCompany c, int id)
        {
            Company company = null;
            try
            {
                company = new Company()
                {
                    Id = id,
                    Name = c.Name,
                    Address = c.Address,
                    Country = c.Country
                };
            }
            catch (System.NullReferenceException e)
            {
                Console.WriteLine(e.ToString());
                await Task.FromException(e);
            }

            await _companyRepository.UpdateAsync(company);
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
