using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarRental.Core.Repository;
using CarRental.Infrastructure.Commands;
using CarRental.Infrastructure.DTO;

namespace CarRental.Infrastructure.Services
{
    public class CompanyService : ICompanyService
    {
        public Task Add(CreateCompany company)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CompanyDTO>> BrowseAll()
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CompanyDTO> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(UpdateCompany company, int id)
        {
            throw new NotImplementedException();
        }
    }
}
