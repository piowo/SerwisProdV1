using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SerwisProdV1.Models
{
    public class City
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Proszę podać nazwę miasta")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Proszę podać koszt transportu")]
        [RegularExpression(@"\d+",ErrorMessage = "Proszę podać prawidłową wartość liczbową")]
        public double TransportCost { get; set; }

        [Required(ErrorMessage = "Proszę podać koszt 1 godziny roboczej")]
        [RegularExpression(@"\d+",ErrorMessage = "Proszę podać prawidłową wartość liczbową")]
        public double CostOfWorkingHour { get; set; }

        public virtual SearchHistory SearchHistory { get; set;  }
    }
}
