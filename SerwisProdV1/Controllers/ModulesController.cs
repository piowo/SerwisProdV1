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
    public class ModulesController : Controller
    {
        private readonly IModuleService moduleService;

        public ModulesController(IModuleService moduleService)
        {
            this.moduleService = moduleService;
        }

        // GET: Cities
        public ViewResult Index()
        {
            return View(moduleService.GetModules().Result);
        }

        [HttpGet]
        public ViewResult AddModule()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddModule(Module module)
        {
            if (ModelState.IsValid)
            {
                var responce = moduleService.AddModule(module);

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
        public ActionResult UpdateModule()
        {
            var moduleId = Convert.ToInt32(Request["Id"]);
            return View(moduleService.GetModuleById(moduleId));
        }

        [HttpPost]
        public ActionResult FinalUpdateModule(Module module)
        {
            if (ModelState.IsValid)
            {
                var responce = moduleService.UpdateModule(module);

                if (responce.Message.Equals("Success"))
                {
                    return Redirect("Index");
                }
                else
                {
                    return View("Bad");
                }
            }
            return View("UpdateModule", module);
        }

        [HttpPost]
        public ActionResult DeleteModule()
        {
            int moduleId = Convert.ToInt32(Request["Id"]);
            return View(moduleService.GetModuleById(moduleId));
        }

        [HttpPost]
        public ActionResult FinalDeleteModule()
        {

            if (Request["Odpowiedz"] == "Tak")
            {
                var moduleId = Convert.ToInt32(Request["ModuleId"]);
                var responce = moduleService.DeleteModule(moduleId);

                if (!responce.Message.Equals("Success"))
                {

                    return View("Bad");
                }

            }
            return Redirect("Index");
        }

    }
}
