using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectiFinal.Models
{
    public class Barber
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Descripcion")]
        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Horario")]
        public string Horary { get; set; }

        [Required]
        [Display(Name = "Telefono")]
        [MaxLength(100)]
        public string Phone { get; set; }
    }
}