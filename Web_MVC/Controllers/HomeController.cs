using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Web_MVC.Models;

namespace Web_MVC.Controllers
{


    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private readonly IConfiguration Configuration;


        public HomeController(IConfiguration configuration)
        {

            Configuration = configuration;
        }


        public IActionResult Index2() => View(); 

        [HttpGet]

        public IActionResult Print_Value()
        {
            int age = 38;
            string name = "Dron";
          
            User user = new User() { Name = name, Age = age}; 
            return View(user);
        }



        public IActionResult Print_info()
        {
            var adminName = Configuration.GetSection("Admin:Name");
            return View();

        }

        public IActionResult Index()
        {
         //   var adminName = Configuration.GetSection("Admin:Name");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Print_Collection()
        {
            List<User> users = new List<User>();//создаем коллекцию 
            users.Add(new User() { Name = "Nata", Age = 39 });
            users.Add(new User() { Name = "Dron", Age = 38 });
            users.Add(new User() { Name = "Lera", Age = 10 });
           
            return View(users);
        }


        public IActionResult Print_Collection_int()
        {
           
            List<int> i = new List<int>();
            i = new List<int> { 1, 2, 3, 4, 5 };
            return View(i);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
