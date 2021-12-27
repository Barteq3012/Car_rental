using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Core.Domain;
using CarRental.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private AppDbContext _appDbContext;
        public CustomerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task AddAsync(Customer c)
        {
            try
            {
                _appDbContext.Customer.Add(c);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception e)
            {
                await Task.FromException(e);
            }
        }

        public async Task<IEnumerable<Customer>> BrowseAllAsync()
        {
            return await Task.FromResult(_appDbContext.Customer.Include(x => x.Company));

        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.Customer.Include(x => x.Company).FirstOrDefault(x => x.Id == id));
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception e)
            {
                await Task.FromException(e);
            }
        }

        public async Task<Customer> GetAsync(int id)
        {
            return await Task.FromResult(_appDbContext.Customer.Include(x => x.Company).FirstOrDefault(x => x.Id == id));

        }

        public async Task UpdateAsync(Customer c)
        {
            try
            {
                var cstr = _appDbContext.Customer.Include(x => x.Company).FirstOrDefault(x => x.Id == c.Id);

                cstr.Name = c.Name;
                cstr.SecondName = c.SecondName;
                cstr.BirthDate = c.BirthDate;
                cstr.Country = c.Country;
                cstr.Company = c.Company;

                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception e)
            {
                await Task.FromException(e);
            }
        }
    }
}
