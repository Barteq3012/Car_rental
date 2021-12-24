using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Core.Domain;
using CarRental.Core.Repository;
using CarRental.Infrastructure.DTO;

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
                RegistrationProofDTO = mapRegistrationProofToDTO(x.RegistrationProof)
            });
        }

        private RegistrationProofDTO mapRegistrationProofToDTO(RegistrationProof r)
        {
            if(r == null)
            {
                return null;
            } else
            {
                var rDTO = new RegistrationProofDTO()
                {
                    Id = r.Id,
                    FirstRegistrationDate = r.FirstRegistrationDate,
                    Plate = r.Plate
                };
                return rDTO;
            }
        }

        private CarDTO mapCarToDTO(Car c)
        {
            if(c == null)
            {
                return null;
            } else
            {
                var cDTO = new CarDTO()
                {
                    Id = c.Id,
                    Brand = c.Brand,
                    Model = c.Model,
                    ProductionDate = c.ProductionDate,
                    Country = c.Country,
                    Mileage = c.Mileage,
                    RegistrationProofDTO = mapRegistrationProofToDTO(c.RegistrationProof)
                };
                return cDTO;
            }
        }
    }
}
