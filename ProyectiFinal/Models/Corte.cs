using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace ProyectiFinal.Models
{
    public class Corte
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Descripcion")]
        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Precio")]
        public int Price { get; set; }
    }
}