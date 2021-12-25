using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Core.Domain;
using CarRental.Core.Repository;

namespace CarRental.Infrastructure.Repositories
{
    public class CarRepository : ICarRepository
    {
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

        public Task AddAsync(Car c)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Car>> BrowseAllAsync()
        {
            return await Task.FromResult(_carMock);
        }

        public async Task DeleteAsync(int id)
        {
            _carMock.Remove(_carMock.FirstOrDefault(x => x.Id == id));
            await Task.CompletedTask;
        }

        public async Task<Car> GetAsync(int id)
        {
            return await Task.FromResult(_carMock.FirstOrDefault(x => x.Id == id));
        }

        public Task UpdateAsync(Car c)
        {
            throw new NotImplementedException();
        }
    }
}
