using JqueryGetPostAlertTest.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JqueryGetPostAlertTest
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult People()
        {
            return View();
        }

        [HttpPost]
        public JsonResult PeopleList(int id)
        {
            List<People> peoples = new List<People>
            {
                new People{Id=1,Name="Ridley",Surname="Scott",City="Manchester"},
                new People{Id=2,Name="Christopher",Surname="Nolan",City="Londan"},
                new People{Id=3,Name="Zack",Surname="Snyder",City="Washinton"}
            };

            People people = peoples.FirstOrDefault(x => x.Id == id);
            

            if (people == null)
            {
                ErrorModel error = new ErrorModel();
                error.ErrorId = id;
                return Json(error);
            }

            return Json(people);
        }
    }
}
