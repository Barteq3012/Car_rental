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
    public class RegistrationProofController : Controller
    {
        private readonly IRegistrationProofService _registrationProofService;
        public RegistrationProofController(IRegistrationProofService registrationProofService)
        {
            _registrationProofService = registrationProofService;
        }

        [HttpGet]
        public async Task<IActionResult> BrowseAll()
        {
            IEnumerable<RegistrationProofDTO> c = await _registrationProofService.BrowseAll();
            return Json(c);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegistrationProof(int id)
        {
            RegistrationProofDTO z = await _registrationProofService.Get(id);
            if (z == null)
            {
                return base.Content("<h1 style='color:red;text-align: center;font-size: 72px'>Nie ma dowodu o tym id!</h1>", "text/html");
            }
            return Json(z);
        }


        [HttpPost]
        public async Task<IActionResult> AddRegistrationProof([FromBody] CreateRegistrationProof c)
        {
            await _registrationProofService.Add(c);
            IEnumerable<RegistrationProofDTO> z = await _registrationProofService.BrowseAll();
            if (z == null)
            {
                return base.Content("<h1 style='color:red;text-align: center;font-size: 72px'>Nie udało się dodać dowodu</h1>", "text/html");
            }
            return Json(z);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRegistrationProof([FromBody] UpdateRegistrationProof c, int id)
        {
            await _registrationProofService.Update(c, id);
            IEnumerable<RegistrationProofDTO> z = await _registrationProofService.BrowseAll();
            if (z == null)
            {
                return base.Content("<h1 style='color:red;text-align: center;font-size: 72px'>Nie udało się zaktualizować dowodu</h1>", "text/html");
            }
            return Json(z);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistrationProof(int id)
        {
            await _registrationProofService.Delete(id);
            IEnumerable<RegistrationProofDTO> z = await _registrationProofService.BrowseAll();
            if (z == null)
            {
                return base.Content("<h1 style='color:red;text-align: center;font-size: 72px'>Nie udało się usunąć dowodu</h1>", "text/html");
            }
            return Json(z);

        }

    }
}
