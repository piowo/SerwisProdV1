using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SerwisProdV1.Models
{
    public class Module
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Proszę podać kod wyrobu")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Proszę podać cenę")]
        [RegularExpression(@"\d+", ErrorMessage = "Proszę podać prawidłową wartość liczbową")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Proszę podać czas wykonania części (modułu)")]
        [RegularExpression(@"\d+", ErrorMessage = "Proszę podać prawidłową wartość liczbową")]
        public double AssemblyTime { get; set; }

        [Required(ErrorMessage = "Proszę podać masę")]
        [RegularExpression(@"\d+", ErrorMessage = "Proszę podać prawidłową wartość liczbową")]
        public double Weight { get; set; }

        [Required(ErrorMessage = "Proszę podać opis")]
        public string Description { get; set; }

        public virtual SearchHistory SearchHistory { get; set; }
    }
}
