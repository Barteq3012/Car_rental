using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using CarRental.Core.Domain;
using CarRental.Core.Repository;

namespace CarRental.Infrastructure.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        public Task AddAsync(Company c)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Company>> BrowseAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Company> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Company c)
        {
            throw new NotImplementedException();
        }
    }
}
