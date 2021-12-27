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
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<IActionResult> BrowseAll()
        {
            IEnumerable<CompanyDTO> c = await _companyService.BrowseAll();
            return Json(c);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompany(int id)
        {
            CompanyDTO z = await _companyService.Get(id);
            if (z == null)
            {
                return base.Content("<h1 style='color:red;text-align: center;font-size: 72px'>Nie ma firmy o tym id!</h1>", "text/html");
            }
            return Json(z);
        }


        [HttpPost]
        public async Task<IActionResult> AddCompany([FromBody] CreateCompany c)
        {
            await _companyService.Add(c);
            IEnumerable<CompanyDTO> z = await _companyService.BrowseAll();
            if (z == null)
            {
                return base.Content("<h1 style='color:red;text-align: center;font-size: 72px'>Nie udało się dodać firmy</h1>", "text/html");
            }
            return Json(z);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompany([FromBody] UpdateCompany c, int id)
        {
            await _companyService.Update(c, id);
            IEnumerable<CompanyDTO> z = await _companyService.BrowseAll();
            if (z == null)
            {
                return base.Content("<h1 style='color:red;text-align: center;font-size: 72px'>Nie udało się zaktualizować firmy</h1>", "text/html");
            }
            return Json(z);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            await _companyService.Delete(id);
            IEnumerable<CompanyDTO> z = await _companyService.BrowseAll();
            if (z == null)
            {
                return base.Content("<h1 style='color:red;text-align: center;font-size: 72px'>Nie udało się usunąć firmy</h1>", "text/html");
            }
            return Json(z);

        }

    }
}
