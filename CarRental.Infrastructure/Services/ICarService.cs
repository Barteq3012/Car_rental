using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarRental.Core.Domain;
using CarRental.Infrastructure.Commands;
using CarRental.Infrastructure.DTO;

namespace CarRental.Infrastructure.Services
{
    public interface ICarService
    {
        Task<IEnumerable<CarDTO>> BrowseAll();
        Task<CarDTO> Get(int id);
        Task Delete(int id);
        Task Add(CreateCar car);
        Task Update(UpdateCar car, int id);
    }
}
