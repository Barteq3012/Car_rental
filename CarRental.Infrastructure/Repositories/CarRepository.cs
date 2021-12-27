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


        /*
        public static List<Car> _carMock = new List<Car>(){
            new Car()
            {
                Id = 1,
                Brand = "Ferrari",
                Model = "Enzo",
                ProductionDate = DateTime.Parse("2000-12-30 21:37"),
                Country = "Italy",
                Mileage = 20000,
                RegistrationProof = new RegistrationProof()
                {
                    Id = 10,
                    FirstRegistrationDate = DateTime.Parse("2011-03-21 13:26"),
                    Plate = "WBR3012"
                }
            },
            new Car()
            {
                Id = 2,
                Brand = "Ferrari",
                Model = "Enzo",
                ProductionDate = DateTime.Parse("2011-03-21 13:26"),
                Country = "Italy",
                Mileage = 10000,
                RegistrationProof = new RegistrationProof()
                {
                    Id = 11,
                    FirstRegistrationDate = DateTime.Parse("2011-03-21 13:26"),
                    Plate = "WBR3212"
                }
            },
            new Car()
            {
                Id = 3,
                Brand = "Ferrari",
                Model = "Enzo",
                ProductionDate = DateTime.Parse("2011-03-21 13:26"),
                Country = "Italy",
                Mileage = 30000,
                RegistrationProof = new RegistrationProof()
                {
                    Id = 12,
                    FirstRegistrationDate = DateTime.Parse("2011-03-21 13:26"),
                    Plate = "WBR3112"
                }
            }
        };
        */
        public async Task AddAsync(Car c)
        {
            //_carMock.Add(c);
            //await Task.CompletedTask;
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
            //return await Task.FromResult(_carMock);
            return await Task.FromResult(_appDbContext.Car.Include(x => x.RegistrationProof));

        }

        public async Task DeleteAsync(int id)
        {
            //_carMock.Remove(_carMock.FirstOrDefault(x => x.Id == id));
            //await Task.CompletedTask;
            try
            {
                _appDbContext.Remove(_appDbContext.Car.Include(x => x.RegistrationProof).FirstOrDefault(x => x.Id == id));
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
            //return await Task.FromResult(_carMock.FirstOrDefault(x => x.Id == id));
            return await Task.FromResult(_appDbContext.Car.Include(x => x.RegistrationProof).FirstOrDefault(x => x.Id == id));
        }

        public async Task UpdateAsync(Car c)
        {
            /*
            var car = _carMock.FirstOrDefault(x => x.Id == c.Id);

            car.Brand = c.Brand;
            car.Model = c.Model;
            car.ProductionDate = c.ProductionDate;
            car.Country = c.Country;
            car.Mileage = c.Mileage;
            car.RegistrationProof = c.RegistrationProof;

            await Task.CompletedTask;
            */

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
