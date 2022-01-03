using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CarRental.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CarRental.WebApp.Controllers
{
    public class CompanyController : Controller
    {
        public IConfiguration Configuration;
        public CompanyController(IConfiguration configuration)
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
            List<CompanyVM> companyList = new List<CompanyVM>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_restpath))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    companyList = JsonConvert.DeserializeObject<List<CompanyVM>>(apiResponse);
                }
                
            }
            return View(companyList);
        }
    }
}
