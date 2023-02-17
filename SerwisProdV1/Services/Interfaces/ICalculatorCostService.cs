using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SerwisProdV1.ModelsDTO;

namespace SerwisProdV1.Services.Interfaces
{
    public interface ICalculatorCostService
    {
        OperationResultDTO CalculateCost(string cityName, ModuleListDTO moduleListDTO);
    }
}
