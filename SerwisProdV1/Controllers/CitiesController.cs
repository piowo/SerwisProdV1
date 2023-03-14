using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SerwisProdV1.Services.Interfaces;
using SerwisProdV1.Services.Implementations;
using SerwisProdV1.Models;

namespace SerwisProdV1.Controllers
{
    public class CitiesController : Controller
    {
        private readonly ICityService cityService;

        public CitiesController(ICityService cityService)
        {
            this.cityService = cityService;
        }

        // GET: Cities
        public ViewResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public ViewResult AddCity()
        {

            return View();
        }

        [HttpPost]
        public ViewResult AddCity(City city)
        {
           if (ModelState.IsValid)
            {
                var responce = cityService.AddCity(city);

                if (responce.Message.Equals("Success"))
                {
                    return View("Good");
                } else
                {
                    return View("Bad");
                }
            }
            return View();
        }
    }
}
