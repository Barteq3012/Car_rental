using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarRental.Infrastructure.Commands;
using CarRental.Infrastructure.DTO;

namespace CarRental.Infrastructure.Services
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyDTO>> BrowseAll();
        Task<CompanyDTO> Get(int id);
        Task Delete(int id);
        Task Add(CreateCompany company);
        Task Update(UpdateCompany company, int id);
    }
}
