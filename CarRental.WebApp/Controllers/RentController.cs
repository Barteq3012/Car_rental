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
    public class RentController : Controller
    {
        public IConfiguration Configuration;
        public RentController(IConfiguration configuration)
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
            List<RentVM> rentList = new List<RentVM>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_restpath))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    rentList = JsonConvert.DeserializeObject<List<RentVM>>(apiResponse);
                }
                
            }
            return View(rentList);
        }

        public IActionResult Create()
        {
             return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RentCreateVM rent)
        {
            string _restpath = GetHostUrl().Content + CN();

            try {

                using (var httpClient = new HttpClient())
                {
                    double x = rent.TotalCost;
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(rent);
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
            RentVM rent = new RentVM();
            RentCreateVM createRent = new RentCreateVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    rent = JsonConvert.DeserializeObject<RentVM>(apiResponse);
                }
                createRent = mapRentToCreate(rent);
            }
            return View(createRent);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RentCreateVM rent)
        {
            string _restpath = GetHostUrl().Content + CN();

            try {

                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(rent);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PutAsync($"{_restpath}/{rent.Id}", content ))
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

            RentVM rent = new RentVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    rent = JsonConvert.DeserializeObject<RentVM>(apiResponse);
                }
                
            }
            return View(rent);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(RentVM rent)
        {
            string _restpath = GetHostUrl().Content + CN();

            try {

                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.DeleteAsync($"{_restpath}/{rent.Id}");       
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
            RentVM rent = new RentVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    rent = JsonConvert.DeserializeObject<RentVM>(apiResponse);
                }
                
            }
            return View(rent);
        }

        static public RentCreateVM mapRentToCreate(RentVM r)
        {
            if (r == null)
            {
                return null;
            }
            else
            {
                var rcVM = new RentCreateVM()
                {
                    Id = r.Id,
                    CarId = r.Car.Id,
                    CustomerId = r.Customer.Id,
                    RentDate = r.RentDate,
                    ReturnDate = (DateTime)r.ReturnDate,
                    TotalCost = r.TotalCost
                };
                return rcVM;
            }
        }
    }
}
