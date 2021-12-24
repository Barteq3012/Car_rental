using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

    }
}
