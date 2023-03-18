using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SerwisProdV1.Services.Interfaces;
using SerwisProdV1.Models;
using SerwisProdV1.ModelsDTO;

namespace SerwisProdV1.Services.Implementations
{
    public class SearchHistoryService : ISearchHistoryService
    {
        private readonly CalculatorContext context;
        private readonly IModuleService moduleService;
        private readonly ICityService cityService;
        
        

        public SearchHistoryService(
            CalculatorContext context,
            IModuleService moduleService,
            ICityService cityService
            )
        {
            this.context = context;
            this.moduleService = moduleService;
            this.cityService = cityService;
            
        }

        double CalculateCost(SearchHistory sH)
        {
            var city = cityService.GetCityById(sH.CityId);

            ModuleListDTO moduleList = new ModuleListDTO();
            moduleList.ModuleList = new List<string>();
            if (sH.ModuleName1 != "Brak") moduleList.ModuleList.Add(sH.ModuleName1);
            if (sH.ModuleName2 != "Brak") moduleList.ModuleList.Add(sH.ModuleName2);
            if (sH.ModuleName3 != "Brak") moduleList.ModuleList.Add(sH.ModuleName3);
            if (sH.ModuleName4 != "Brak") moduleList.ModuleList.Add(sH.ModuleName4);

            return CalculateCost(city, moduleList);
        }

        double CalculateCost(City city, ModuleListDTO moduleListDTO)
        {
            var modulesCost = city.TransportCost;

            foreach (string moduleName in moduleListDTO.ModuleList)
            {
                var module = moduleService.GetModuleByName(moduleName);
                modulesCost = modulesCost + module.Price + (module.AssemblyTime * city.CostOfWorkingHour);
            }

            modulesCost = modulesCost * 1.3;

            return modulesCost;
        }

        public OperationResultDTO AddSearchHistory(SearchHistory searchHistory)
        {
           
            searchHistory.ProductionCost = CalculateCost(searchHistory);
            context.SearchHistory.Add(searchHistory);
            context.SaveChanges();

            return new OperationSuccesDTO<Module> { Message = "Success" };
        }

        public SearchHistory GetSearchHistoryById(int Id)
        {
           
            return context.SearchHistory.Where(x => x.Id == Id).FirstOrDefault();
        }

        private int ModuleHasValue(SearchHistory searchHistory)
        {
            int counter = 0;

            if (!(searchHistory.ModuleName1 == string.Empty))
                counter++;
            if (!(searchHistory.ModuleName2 == string.Empty))
                counter++;
            if (!(searchHistory.ModuleName3 == string.Empty))
                counter++;
            if (!(searchHistory.ModuleName4 == string.Empty))
                counter++;

            return counter;
        }

        public ResultCostDTO GetSearchHistory(string cityName, ModuleListDTO moduleListDTO)
        {
            var city = cityService.GetCityByName(cityName);

            if (city == null)
            {
                return new ResultCostDTO { InSearchHistory = false };
            }

            var searchHistoryList = context.SearchHistory.Where(sh => sh.CityId == city.Id);

            if (searchHistoryList == null)
            {
                return new ResultCostDTO { InSearchHistory = false };
            }

            int counterModule = 0;

            foreach (SearchHistory searchHistory in searchHistoryList)
            {
                counterModule = 0;

                foreach(string searchHistoryPar in moduleListDTO.ModuleList)
                {
                    if (searchHistory.ModuleName1 == searchHistoryPar || 
                            searchHistory.ModuleName2 == searchHistoryPar ||
                            searchHistory.ModuleName3 == searchHistoryPar ||
                            searchHistory.ModuleName4 == searchHistoryPar)
                    {
                        counterModule++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (moduleListDTO.ModuleList.Count() == ModuleHasValue(searchHistory) && 
                    moduleListDTO.ModuleList.Count() == counterModule)
                {
                    return new ResultCostDTO
                    {
                        InSearchHistory = true,
                        Cost = searchHistory.ProductionCost
                    };
                }
                
            }
            return new ResultCostDTO { InSearchHistory = false };
        }
        
        OperationSuccesDTO<IList<SearchHistory>> ISearchHistoryService.GetSearchHistories()
        {
            List<SearchHistory> searchHistories = context.SearchHistory.ToList();
            return new OperationSuccesDTO<IList<SearchHistory>> { Message = "Success", Result = searchHistories };
        }

        public OperationResultDTO UpdateSearchHistory(SearchHistory sH)
        {
            var mod = GetSearchHistoryById (sH.Id);
            if (mod == null)
            {
                return new OperationErrorDTO { Code = 404, Message = $"SearchHistory with Id: {sH.Id} doesn't exist" };
            }
            mod.Name = sH.Name;
            mod.ModuleName1 = sH.ModuleName1;
            mod.ModuleName2 = sH.ModuleName2;
            mod.ModuleName3 = sH.ModuleName3;
            mod.ModuleName4 = sH.ModuleName4;
            mod.CityId = sH.CityId;
            mod.ProductionCost = CalculateCost(sH);
            context.SaveChanges();
            return new OperationSuccesDTO<SearchHistory> { Message = "Success" };
        }

        public OperationResultDTO DeleteSearchHistory(int Id)
        {
            var sH = GetSearchHistoryById(Id);
            if (sH == null)
            {
                return new OperationErrorDTO { Code = 404, Message = $"SearchHistory with Id: {Id} doesn't exist" };
            }
            context.SearchHistory.Remove(sH);
            context.SaveChanges();
            return new OperationSuccesDTO<Module> { Message = "Success" };
        }

    }
}