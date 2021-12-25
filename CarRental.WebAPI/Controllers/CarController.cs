using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRental.Infrastructure.Commands;
using CarRental.Infrastructure.DTO;
using CarRental.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebAPI.Controllers
{
    [Route("[Controller]")]
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> BrowseAll()
        {
            IEnumerable<CarDTO> c = await _carService.BrowseAll();
            return Json(c);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCar(int id)
        {
            CarDTO z = await _carService.Get(id);
            if(z == null)
            {
                return base.Content("<h1 style='color:red;text-align: center;font-size: 72px'>Nie ma zawodnika o tym id!</h1>", "text/html");
            }
            return Json(z);
        }

        /*
        [HttpPost]
        public async Task<IActionResult> AddCar([FromBody] CreateCar)
        {
            throw new NotImplementedException();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar([FromBody] UpdateCar, int id)
        {
            throw new NotImplementedException();

        }
        */

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            await _carService.Delete(id);
            IEnumerable<CarDTO> z = await _carService.BrowseAll();
            if(z == null)
            {
                return base.Content("<h1 style='color:red;text-align: center;font-size: 72px'>Nie udało się usunąć zawodnika</h1>", "text/html");
            }
            return Json(z);

        }

    }
}
