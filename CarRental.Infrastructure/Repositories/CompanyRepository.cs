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
        private AppDbContext _appDbContext;
        public CompanyRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;         
        }
        public async Task AddAsync(Company c)
        {
            try
            {
                _appDbContext.Company.Add(c);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception e)
            {
                await Task.FromException(e);
            }
        }

        public async Task<IEnumerable<Company>> BrowseAllAsync()
        {
            return await Task.FromResult(_appDbContext.Company);
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.Company.FirstOrDefault(x => x.Id == id));
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception e)
            {
                await Task.FromException(e);
            }
        }

        public async Task<Company> GetAsync(int id)
        {
            return await Task.FromResult(_appDbContext.Company.FirstOrDefault(x => x.Id == id));

        }

        public async Task UpdateAsync(Company c)
        {
            try
            {
                var cmp = _appDbContext.Company.FirstOrDefault(x => x.Id == c.Id);

                cmp.Name = c.Name;
                cmp.Address = c.Address;
                cmp.Country = c.Country;

                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch(Exception e)
            {
                await Task.FromException(e);
            }
        }
    }
}
