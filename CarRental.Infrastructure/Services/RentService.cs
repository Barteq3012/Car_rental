using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Core.Domain;
using CarRental.Core.Repository;
using CarRental.Infrastructure.Commands;
using CarRental.Infrastructure.DTO;

namespace CarRental.Infrastructure.Services
{
    public class RentService : IRentService
    {
        private readonly IRentRepository _rentRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICarRepository _carRepository;
        public RentService(IRentRepository rentRepository, ICarRepository carRepository, ICustomerRepository customerRepository)
        {
            _rentRepository = rentRepository;
            _carRepository = carRepository;
            _customerRepository = customerRepository;
        }
        public async Task Add(CreateRent r)
        {
            Rent rent = null;
            try
            {
                rent = new Rent()
                {
                    Id = r.Id,
                    Car = await _carRepository.GetAsync(r.CarId),
                    Customer = await _customerRepository.GetAsync(r.CustomerId),
                    RentDate = r.RentDate,
                    ReturnDate = (DateTime)r.ReturnDate,
                    TotalCost = r.TotalCost
                };
            }
            catch (System.NullReferenceException e)
            {
                Console.WriteLine(e.ToString());
                await Task.FromException(e);
            }

            await _rentRepository.AddAsync(rent);
        }

        public async Task<IEnumerable<RentDTO>> BrowseAll()
        {
            var r = await _rentRepository.BrowseAllAsync();

            return r.Select(x => new RentDTO()
            {
                Id = x.Id,
                Car = MapDomain.mapCarToDTO(x.Car),
                Customer = MapDomain.mapCustomerToDTO(x.Customer),
                RentDate = x.RentDate,
                ReturnDate = (DateTime)x.ReturnDate,
                TotalCost = x.TotalCost
            });
        }

        public async Task Delete(int id)
        {
            await _rentRepository.DeleteAsync(id);
        }

        public async Task<RentDTO> Get(int id)
        {
            var r = await _rentRepository.GetAsync(id);

            if (r == null)
            {
                return null;
            }

            return MapDomain.mapRentToDTO(r);
        }

        public async Task Update(UpdateRent r, int id)
        {
            Rent rent = null;
            try
            {
                rent = new Rent()
                {
                    Id = id,
                    Car = await _carRepository.GetAsync(r.CarId),
                    Customer = await _customerRepository.GetAsync(r.CustomerId),
                    RentDate = r.RentDate,
                    ReturnDate = (DateTime)r.ReturnDate,
                    TotalCost = r.TotalCost
                };
            }
            catch (System.NullReferenceException e)
            {
                Console.WriteLine(e.ToString());
                await Task.FromException(e);
            }

            await _rentRepository.UpdateAsync(rent);
        }
    }
}
