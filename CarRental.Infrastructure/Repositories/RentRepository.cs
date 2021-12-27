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
    public class RentRepository : IRentRepository
    {
        private AppDbContext _appDbContext;

        public RentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task AddAsync(Rent r)
        {
            try
            {
                _appDbContext.Rent.Add(r);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception e)
            {
                await Task.FromException(e);
            }
        }

        public async Task<IEnumerable<Rent>> BrowseAllAsync()
        {
            return await Task.FromResult(_appDbContext.Rent.Include(x => x.Customer).Include(x => x.Car)); //podwojny include
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.Rent.Include(x => x.Customer).Include(x => x.Car).FirstOrDefault(x => x.Id == id));
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception e)
            {
                await Task.FromException(e);
            }
        }

        public async Task<Rent> GetAsync(int id)
        {
            return await Task.FromResult(_appDbContext.Rent.Include(x => x.Customer).Include(x => x.Car).FirstOrDefault(x => x.Id == id));
        }

        public async Task UpdateAsync(Rent r)
        {
            try
            {
                var rent = _appDbContext.Rent.Include(x => x.Customer).Include(x => x.Car).FirstOrDefault(x => x.Id == r.Id);

                rent.Customer = r.Customer;
                rent.Car = r.Car;
                rent.RentDate = r.RentDate;
                rent.ReturnDate = r.ReturnDate;
                rent.TotalCost = r.TotalCost;

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
