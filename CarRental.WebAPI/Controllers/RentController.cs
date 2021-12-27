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
    public class RentController : Controller
    {
        private readonly IRentService _carService;
        public RentController(IRentService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> BrowseAll()
        {
            IEnumerable<RentDTO> c = await _carService.BrowseAll();
            return Json(c);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRent(int id)
        {
            RentDTO z = await _carService.Get(id);
            if (z == null)
            {
                return base.Content("<h1 style='color:red;text-align: center;font-size: 72px'>Nie ma wynajmu o tym id!</h1>", "text/html");
            }
            return Json(z);
        }


        [HttpPost]
        public async Task<IActionResult> AddRent([FromBody] CreateRent c)
        {
            await _carService.Add(c);
            IEnumerable<RentDTO> z = await _carService.BrowseAll();
            if (z == null)
            {
                return base.Content("<h1 style='color:red;text-align: center;font-size: 72px'>Nie udało się dodać wynajmu</h1>", "text/html");
            }
            return Json(z);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRent([FromBody] UpdateRent c, int id)
        {
            await _carService.Update(c, id);
            IEnumerable<RentDTO> z = await _carService.BrowseAll();
            if (z == null)
            {
                return base.Content("<h1 style='color:red;text-align: center;font-size: 72px'>Nie udało się zaktualizować wynajmu</h1>", "text/html");
            }
            return Json(z);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRent(int id)
        {
            await _carService.Delete(id);
            IEnumerable<RentDTO> z = await _carService.BrowseAll();
            if (z == null)
            {
                return base.Content("<h1 style='color:red;text-align: center;font-size: 72px'>Nie udało się usunąć wynajmu</h1>", "text/html");
            }
            return Json(z);

        }

    }
}
