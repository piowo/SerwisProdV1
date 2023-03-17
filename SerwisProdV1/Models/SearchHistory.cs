using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SerwisProdV1.Models
{
    public class SearchHistory
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę wyrobu")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Proszę wybrać miasto z listy")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "Proszę zdefiniować choć jedną część")]
        public string ModuleName1 { get; set; }

        public string ModuleName2 { get; set; }
        public string ModuleName3 { get; set; }
        public string ModuleName4 { get; set; }
        public double ProductionCost { get; set; }
    }
}
