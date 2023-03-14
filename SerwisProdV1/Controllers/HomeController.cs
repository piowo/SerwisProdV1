using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SerwisProdV1.Services.Interfaces;
using SerwisProdV1.Services.Implementations;

namespace SerwisProdV1.Controllers
{
    public class HomeController : Controller
    {
        

        public ViewResult Index()
        {
            return View();
        }       
    }
}