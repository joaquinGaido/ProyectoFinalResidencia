using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalResidencia.Models
{
    public class Familias
    {
        public int Id { get; set; }

        [Required]
        public string NombreFamilia { get; set; }

        [Required]
        public int Telefono { get; set; }

        [Required]
        public string Domicilio { get; set; }

        public List<Adolecentes> adolecentes { get; set; }
    }
}
