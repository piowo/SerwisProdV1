using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using SerwisProdV1.Models;
using SerwisProdV1.Services.Interfaces;
using SerwisProdV1.Services.Implementations;



namespace SerwisProdV1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            var container = new Container();

            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            container.Register<CalculatorContext>(Lifestyle.Scoped);
            container.Register<ICityService, CityService>(Lifestyle.Scoped);
            container.Register<IModuleService, ModuleService>(Lifestyle.Scoped);
            container.Register<ICalculatorCostService, CalculatorCostService>(Lifestyle.Scoped);
            container.Register<ISearchHistoryService, SearchHistoryService>(Lifestyle.Scoped);
            container.Register<IShowResultService, ShowResultService>(Lifestyle.Scoped);

            container.Verify();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
