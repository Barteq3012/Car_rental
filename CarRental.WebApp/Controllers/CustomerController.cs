using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CarRental.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CarRental.WebApp.Controllers
{
    public class CustomerController : Controller
    {
        public IConfiguration Configuration;
        public CustomerController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public ContentResult GetHostUrl()
        {
            var result = Configuration["RestApiUrl:HostUrl"];
            return Content(result);
        }

        private string CN()
        {
            return ControllerContext.RouteData.Values["controller"].ToString();
        }

        public async Task<IActionResult> Index()
        {
            string _restpath = GetHostUrl().Content + CN();
            List<CustomerVM> customerList = new List<CustomerVM>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_restpath))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    customerList = JsonConvert.DeserializeObject<List<CustomerVM>>(apiResponse);
                }
                
            }
            return View(customerList);
        }

        public IActionResult Create()
        {
             return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerCreateVM customer)
        {
            string _restpath = GetHostUrl().Content + CN();

            try {

                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(customer);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    await httpClient.PostAsync(_restpath, content);
                    return RedirectToAction(nameof(Index));
                }
            } 
            catch(Exception ex)
            {
                return View(ex);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            string _restpath = GetHostUrl().Content + CN();
            CustomerVM customer = new CustomerVM();
            CustomerCreateVM createCustomer = new CustomerCreateVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    customer = JsonConvert.DeserializeObject<CustomerVM>(apiResponse);
                }
                createCustomer = mapCustomerToCreate(customer);
            }
            return View(createCustomer);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CustomerCreateVM customer)
        {
            string _restpath = GetHostUrl().Content + CN();

            try {

                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(customer);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PutAsync($"{_restpath}/{customer.Id}", content ))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                    }
                
                }
            } 
            catch(Exception ex)
            {
                return View(ex); //tu trzeba by obsłużyć ten wyjątek
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            string _restpath = GetHostUrl().Content + CN();

            CustomerVM customer = new CustomerVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    customer = JsonConvert.DeserializeObject<CustomerVM>(apiResponse);
                }
                
            }
            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CustomerVM customer)
        {
            string _restpath = GetHostUrl().Content + CN();

            try {

                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.DeleteAsync($"{_restpath}/{customer.Id}");       
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return RedirectToAction(nameof(Index));
                }
            } 
            catch(Exception ex)
            {
                return View(ex);
            } 
        }

        public async Task<IActionResult> Details(int id)
        {
            string _restpath = GetHostUrl().Content + CN();
            CustomerVM customer = new CustomerVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    customer = JsonConvert.DeserializeObject<CustomerVM>(apiResponse);
                }
                
            }
            return View(customer);
        }

        static public CustomerCreateVM mapCustomerToCreate(CustomerVM c)
        {
            if (c == null)
            {
                return null;
            }
            else
            {
                var ccVM = new CustomerCreateVM()
                {
                    Id = c.Id,
                    Name = c.Name,
                    SecondName = c.SecondName,
                    BirthDate = c.BirthDate,
                    Country = c.Country,
                    CompanyId = c.Company.Id
                };
                return ccVM;
            }
        }

    }
}
