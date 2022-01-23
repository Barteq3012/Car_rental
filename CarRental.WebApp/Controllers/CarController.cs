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
    public class CarController : Controller
    {
        public IConfiguration Configuration;
        public CarController(IConfiguration configuration)
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
            List<CarVM> carList = new List<CarVM>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_restpath))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    carList = JsonConvert.DeserializeObject<List<CarVM>>(apiResponse);
                }  
            }
            return View(carList);
        }

        public IActionResult Create()
        {
             return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarVM car)
        {
            string _restpath = GetHostUrl().Content + CN();

            try {

                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(car);
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
            CarVM car = new CarVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    car = JsonConvert.DeserializeObject<CarVM>(apiResponse);
                }
                
            }
            return View(car);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CarVM car)
        {
            string _restpath = GetHostUrl().Content + CN();

            try {

                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(car);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PutAsync($"{_restpath}/{car.Id}", content ))
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

            CarVM car = new CarVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    car = JsonConvert.DeserializeObject<CarVM>(apiResponse);
                }
                
            }
            return View(car);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CarVM car)
        {
            string _restpath = GetHostUrl().Content + CN();

            try {

                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.DeleteAsync($"{_restpath}/{car.Id}");       
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
            CarVM car = new CarVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    car = JsonConvert.DeserializeObject<CarVM>(apiResponse);
                }
                
            }
            return View(car);
        }

    }
}
