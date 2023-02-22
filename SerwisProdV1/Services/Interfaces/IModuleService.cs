using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SerwisProdV1.ModelsDTO;
using SerwisProdV1.Models;

namespace SerwisProdV1.Services.Interfaces
{
    public interface IModuleService
    {
        Module GetModuleByName(string moduleName);
        OperationSuccesDTO<List<Module>> GetModules();
        OperationSuccesDTO<Module> AddModule(Module module);
        OperationResultDTO UpdateModule(Module module);
        OperationResultDTO DeleteModule(string name);
    }
}
