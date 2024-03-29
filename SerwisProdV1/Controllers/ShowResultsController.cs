﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SerwisProdV1.Services.Interfaces;
using SerwisProdV1.Services.Implementations;
using SerwisProdV1.Models;

namespace SerwisProdV1.Controllers
{
    public class ShowResultsController : Controller
    {
        private readonly ISearchHistoryService SHService;
        private readonly ICityService cityService;
        private readonly IModuleService moduleService;

        public ShowResultsController(ISearchHistoryService SHService, ICityService cityService, IModuleService moduleService)
        {
            this.SHService = SHService;
            this.cityService = cityService;
            this.moduleService = moduleService;
        }

        // GET: ShowResults
        public ActionResult Index()
        {
            SHelpObjectWithCity sHObject = new SHelpObjectWithCity();
            sHObject.sHList = SHService.GetSearchHistories().Result;
            sHObject.cities = new Hashtable();
            foreach (City city in cityService.GetCities().Result)
            {
                sHObject.cities.Add(city.Id, city.Name);
            }

            return View(sHObject);
        }

        [HttpGet]
        public ViewResult AddSearchHistory()
        {

            ViewBag.cities = new Hashtable();
            foreach (City city in cityService.GetCities().Result)
            {
                ViewBag.cities.Add(city.Name, city.Id);
            }

            ViewBag.modulesNames = new ArrayList();
            foreach (Module module in moduleService.GetModules().Result)
            {
                ViewBag.modulesNames.Add(module.Name);
            }

            return View();
        }

        [HttpPost]
        public ActionResult AddSearchHistory(SearchHistory searchHistory)
        {
            if (ModelState.IsValid)
            {
                var responce = SHService.AddSearchHistory(searchHistory);

                if (responce.Message.Equals("Success"))
                {
                    return Redirect("Index");
                }
                else
                {
                    return View("Bad");
                }
            }

            ViewBag.cities = new Hashtable();
            foreach (City city in cityService.GetCities().Result)
            {
                ViewBag.cities.Add(city.Name, city.Id);
            }

            ViewBag.modulesNames = new ArrayList();
            foreach (Module module in moduleService.GetModules().Result)
            {
                ViewBag.modulesNames.Add(module.Name);
            }

            return View();
        }

        [HttpPost]
        public ActionResult UpdateSearchHistory()
        {
            ViewBag.cities = new Hashtable();
            ViewBag.cityName = new Hashtable();
            foreach (City city in cityService.GetCities().Result)
            {
                ViewBag.cityName.Add(city.Id, city.Name);
                ViewBag.cities.Add(city.Name, city.Id);
            }

            ViewBag.modulesNames = new ArrayList();
            foreach (Module module in moduleService.GetModules().Result)
            {
                ViewBag.modulesNames.Add(module.Name);
            }
            var sHId = Convert.ToInt32(Request["Id"]);
            return View(SHService.GetSearchHistoryById(sHId));
        }

        [HttpPost]
        public ActionResult FinalUpdateSearchHistory(SearchHistory searchHistory)
        {
            if (ModelState.IsValid)
            {
                var responce = SHService.UpdateSearchHistory(searchHistory);

                if (responce.Message.Equals("Success"))
                {
                    return Redirect("Index");
                }
                else
                {
                    ViewBag.Message = responce.Message;
                    return View("Bad");
                }
            }
            ViewBag.cities = new Hashtable();
            ViewBag.cityName = new Hashtable();
            foreach (City city in cityService.GetCities().Result)
            {
                ViewBag.cityName.Add(city.Id, city.Name);
                ViewBag.cities.Add(city.Name, city.Id);
            }

            ViewBag.modulesNames = new ArrayList();
            foreach (Module module in moduleService.GetModules().Result)
            {
                ViewBag.modulesNames.Add(module.Name);
            }
            var sHId = Convert.ToInt32(Request["Id"]);
            return View("UpdateSearchHistory",SHService.GetSearchHistoryById(sHId));
        }

        [HttpPost]
        public ActionResult DeleteSearchHistory()
        {
            ViewBag.cities = new Hashtable();
            foreach (City city in cityService.GetCities().Result)
            {
                ViewBag.cities.Add(city.Id, city.Name);
            }
            int sHId = Convert.ToInt32(Request["Id"]);
            return View(SHService.GetSearchHistoryById(sHId));
        }

        [HttpPost]
        public ActionResult FinalDeleteSearchHistory()
        {

            if (Request["Odpowiedz"] == "Tak")
            {
                var sHId = Convert.ToInt32(Request["sHId"]);
                var responce = SHService.DeleteSearchHistory(sHId);

                if (!responce.Message.Equals("Success"))
                {
                    ViewBag.Message = responce.Message;
                    return View("Bad");
                }

            }
            return Redirect("Index");
        }
    }
}