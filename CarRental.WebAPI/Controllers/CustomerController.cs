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
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> BrowseAll()
        {
            IEnumerable<CustomerDTO> c = await _customerService.BrowseAll();
            return Json(c);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            CustomerDTO z = await _customerService.Get(id);
            if (z == null)
            {
                return base.Content("<h1 style='color:red;text-align: center;font-size: 72px'>Nie ma klienta o tym id!</h1>", "text/html");
            }
            return Json(z);
        }


        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] CreateCustomer c)
        {
            await _customerService.Add(c);
            IEnumerable<CustomerDTO> z = await _customerService.BrowseAll();
            if (z == null)
            {
                return base.Content("<h1 style='color:red;text-align: center;font-size: 72px'>Nie udało się dodać klienta</h1>", "text/html");
            }
            return Json(z);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomer c, int id)
        {
            await _customerService.Update(c, id);
            IEnumerable<CustomerDTO> z = await _customerService.BrowseAll();
            if (z == null)
            {
                return base.Content("<h1 style='color:red;text-align: center;font-size: 72px'>Nie udało się zaktualizować klienta</h1>", "text/html");
            }
            return Json(z);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _customerService.Delete(id);
            IEnumerable<CustomerDTO> z = await _customerService.BrowseAll();
            if (z == null)
            {
                return base.Content("<h1 style='color:red;text-align: center;font-size: 72px'>Nie udało się usunąć klienta</h1>", "text/html");
            }
            return Json(z);

        }

    }
}
