using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SerwisProdV1.Services.Interfaces;
using SerwisProdV1.Models;
using SerwisProdV1.ModelsDTO;

namespace SerwisProdV1.Services.Implementations
{
   
    public class ModuleService : IModuleService
    {
        private readonly CalculatorContext context;

        public ModuleService(CalculatorContext context)
        {
            this.context = context;
        }

        public OperationSuccesDTO<Module> AddModule(Module module)
        {
            context.Module.Add(module);
            context.SaveChanges();
            return new OperationSuccesDTO<Module> { Message = "Success" };
        }

        public Module GetModuleByName(string moduleName)
        {
            return context.Module.Where(module => module.Name == moduleName).FirstOrDefault();
        }

        public OperationSuccesDTO<List<Module>> GetModules()
        {
            List<Module> modules = context.Module.ToList();
            return new OperationSuccesDTO<List<Module>> { Message = "Success", Result = modules };
        }

        public OperationResultDTO DeleteModule(string name)
        {
            var module = GetModuleByName(name);
            if (module == null)
            {
                return new OperationErrorDTO { Code = 404, Message = $"Module with name: {name} doesn't exist" };
            }
            context.Module.Remove(module);
            context.SaveChanges();
            return new OperationSuccesDTO<Module> { Message = "Success" };
        }

        public OperationResultDTO UpdateModule(Module module)
        {
            var mod = GetModuleByName(module.Name);
            if (mod == null)
            {
                return new OperationErrorDTO { Code = 404, Message = $"Module with name: {module.Name} doesn't exist" };
            }
            mod.Price = module.Price;
            mod.Weight = module.Weight;
            mod.AssemblyTime = module.AssemblyTime;
            mod.Code = module.Code;
            mod.Description = module.Description;
            context.SaveChanges();
            return new OperationSuccesDTO<Module> { Message = "Success" };
        }
    }
}
