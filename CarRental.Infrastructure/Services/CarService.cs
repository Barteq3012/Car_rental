using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Core.Domain;
using CarRental.Core.Repository;
using CarRental.Infrastructure.Commands;
using CarRental.Infrastructure.DTO;
using static CarRental.Infrastructure.Commands.CreateCar;

namespace CarRental.Infrastructure.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        async public Task<IEnumerable<CarDTO>> BrowseAll()
        {
            var c = await _carRepository.BrowseAllAsync();

            return c.Select(x => new CarDTO()
            {
                Id = x.Id,
                Brand = x.Brand,
                Model = x.Model,
                ProductionDate = x.ProductionDate,
                Country = x.Country,
                Mileage = x.Mileage,
                RegistrationProof = MapDomain.mapRegistrationProofToDTO(x.RegistrationProof)
            });
        }

        public async Task Delete(int id)
        {
            await _carRepository.DeleteAsync(id);
        }

        public async Task<CarDTO> Get(int id)
        {
            var c = await _carRepository.GetAsync(id);

            if (c == null)
            {
                return null;
            }

            return MapDomain.mapCarToDTO(c);
        }


        public async Task Add(CreateCar c)
        {
            Car car = null;
            try
            {
                car = new Car()
                {
                    Id = c.Id,
                    Brand = c.Brand,
                    Model = c.Model,
                    ProductionDate = c.ProductionDate,
                    Country = c.Country,
                    Mileage = c.Mileage,
                    RegistrationProof = new RegistrationProof()
                    {
                        Id = c.RegistrationProof.Id,
                        FirstRegistrationDate = c.RegistrationProof.FirstRegistrationDate,
                        Plate = c.RegistrationProof.Plate
                    }
                };
            }
            catch (System.NullReferenceException e)
            {
                Console.WriteLine(e.ToString());
                await Task.FromException(e);
            }

            await _carRepository.AddAsync(car);
        }

        public async Task Update(UpdateCar c, int id)
        {
            Car car = null;
            try
            {
                car = new Car()
                {
                    Id = id,
                    Brand = c.Brand,
                    Model = c.Model,
                    ProductionDate = c.ProductionDate,
                    Country = c.Country,
                    Mileage = c.Mileage,
                    RegistrationProof = new RegistrationProof()
                    {
                        Id = c.RegistrationProof.Id,
                        FirstRegistrationDate = c.RegistrationProof.FirstRegistrationDate,
                        Plate = c.RegistrationProof.Plate
                    }
                };
            }
            catch (System.NullReferenceException e)
            {
                Console.WriteLine(e.ToString());
                await Task.FromException(e);
            }

            await _carRepository.UpdateAsync(car);
        }
    }
}
