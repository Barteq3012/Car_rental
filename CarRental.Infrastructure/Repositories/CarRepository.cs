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
    public class CarRepository : ICarRepository
    {
        private AppDbContext _appDbContext;
        public CarRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Car c)
        {
            try
            {
                _appDbContext.Car.Add(c);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception e)
            {
                await Task.FromException(e);
            }
        }

        public async Task<IEnumerable<Car>> BrowseAllAsync()
        {
            return await Task.FromResult(_appDbContext.Car.Include(x => x.RegistrationProof));
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var c = _appDbContext.Car.Include(x => x.RegistrationProof).FirstOrDefault(x => x.Id == id);
                _appDbContext.Remove(c);
                _appDbContext.Remove(_appDbContext.RegistrationProof.FirstOrDefault(x => x.Id == c.RegistrationProof.Id));
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception e)
            {
                await Task.FromException(e);
            }
        }

        public async Task<Car> GetAsync(int id)
        {
            return await Task.FromResult(_appDbContext.Car.Include(x => x.RegistrationProof).FirstOrDefault(x => x.Id == id));
        }

        public async Task UpdateAsync(Car c)
        {
            try
            {
                var car = _appDbContext.Car.Include(x => x.RegistrationProof).FirstOrDefault(x => x.Id == c.Id);

                car.Brand = c.Brand;
                car.Model = c.Model;
                car.ProductionDate = c.ProductionDate;
                car.Country = c.Country;
                car.Mileage = c.Mileage;
                car.RegistrationProof = c.RegistrationProof;

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
