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
            return View(cityService.GetCities().Result);
        }
        
        [HttpGet]
        public ViewResult AddCity()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddCity(City city)
        {
           if (ModelState.IsValid)
            {
                var responce = cityService.AddCity(city);

                if (responce.Message.Equals("Success"))
                {
                    return Redirect("Index");
                }
                else
                {
                    return View("Bad");
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult UpdateCity()
        {
            int cityId = Convert.ToInt32(Request["Id"]);
            return View(cityService.GetCityById(cityId));
        }

        [HttpPost]
        public ActionResult FinalUpdateCity(City city)
        {
            if (ModelState.IsValid)
            {
                var responce = cityService.UpdateCostOfWorkingHour(city.Name, city.CostOfWorkingHour);

                if (!responce.Message.Equals("Success"))
                {
                    return View("Bad");
                }

                responce = cityService.UpdateTransportCost(city.Name, city.TransportCost);

                if (responce.Message.Equals("Success"))
                {
                    return Redirect("Index");
                }
                else
                {
                    return View("Bad");
                }
            }
            return View("UpdateCity",city);
        }

        [HttpPost]
        public ActionResult DeleteCity()
        {
            int cityId = Convert.ToInt32(Request["Id"]);
            return View(cityService.GetCityById(cityId));
        }

        [HttpPost]
        public ActionResult FinalDeleteCity()
        {
            
                if (Request["Odpowiedz"] == "Tak")
                {
                    var cityId = Convert.ToInt32(Request["CityId"]);
                    var responce = cityService.DeleteCity(cityId);

                    if (!responce.Message.Equals("Success"))
                    {
                        ViewBag.wiadomosc = responce.Message;
                        return View("Bad");
                    }
                    
                }
                return Redirect("Index");
        }

    }
}
