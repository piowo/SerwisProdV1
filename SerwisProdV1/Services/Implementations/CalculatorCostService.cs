using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SerwisProdV1.Services.Interfaces;
using SerwisProdV1.Models;
using SerwisProdV1.ModelsDTO;

namespace SerwisProdV1.Services.Implementations
{
    public class CalculatorCostService : ICalculatorCostService
    {
        private readonly CalculatorContext context;
        private readonly ICityService cityService;
        private readonly IModuleService moduleService;
        private readonly ISearchHistoryService searchHistoryService;

        public CalculatorCostService (
            CalculatorContext context,
            ICityService cityService,
            IModuleService moduleService,
            ISearchHistoryService searchHistoryService)
        {
            this.context = context;
            this.cityService = cityService;
            this.moduleService = moduleService;
            this.searchHistoryService = searchHistoryService;
        }

        OperationResultDTO ICalculatorCostService.CalculateCost(string cityName, ModuleListDTO moduleListDTO)
        {
            var city = cityService.GetCityByName(cityName);

            if (city == null)
            {
                return new OperationErrorDTO { Code = 404, Message = $"City with name: {cityName} doesn't exist" };
            }

            var modulesCost = city.TransportCost;

            foreach (string moduleName in moduleListDTO.ModuleList)
            {
                var module = moduleService.GetModuleByName(moduleName);

                if (module == null)
                {
                    return new OperationErrorDTO { Code = 404, Message = $"Module with name: {moduleName} doesn't exist" };
                }

                modulesCost = modulesCost + module.Price + (module.AssemblyTime * city.CostOfWorkingHour);
            }

            modulesCost = modulesCost * 1.3;

            return new OperationSuccesDTO<ResultCostDTO>
            {
                Message = "Success",
                Result = new ResultCostDTO { Cost = modulesCost, InSearchHistory = false }
            };
            
        }
        
    }
}