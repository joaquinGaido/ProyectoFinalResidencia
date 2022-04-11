using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalResidencia.Models
{
    public class RamasEspecialidad
    {
        public int Id { get; set; }

        [Required]
        public string Rama { get; set; }

        public List<Empleados> empleados { get; set; }
    }
}
