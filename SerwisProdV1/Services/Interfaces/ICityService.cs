using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SerwisProdV1.ModelsDTO;
using SerwisProdV1.Models;

namespace SerwisProdV1.Services.Interfaces
{
    public interface ICityService
    {
        City GetCityByName(string cityName);
        OperationSuccesDTO<IList<City>> GetCities();
        OperationResultDTO AddCity(City city);
        OperationResultDTO UpdateCostOfWorkingHour(string cityName, double workingHourCost);
        OperationResultDTO UpdateTransportCost(string cityName, double transportCost);
        OperationResultDTO DeleteCity(string cityName);
    }
}
