using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TestCors.Base;
using TestCors.Models;
using TestCors.Repositories.Data;

namespace TestCors.Controllers
{
    public class HomeController : BaseController<Person, PersonRepository, int>
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        PersonRepository repository;

        public HomeController(PersonRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<JsonResult> Getsemuadata()
        {
            var result = await repository.GetAllProfile();
            return Json(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Testing()
        {
            return View();
        }
        public IActionResult Pokemon()
        {
            return View();
        }
        public IActionResult Persons()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
