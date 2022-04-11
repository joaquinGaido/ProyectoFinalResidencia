using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalResidencia.Models
{
    public class Empleados
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string NombreEmpleado { get { return Apellido + ", " + Nombre; } }

        [Range(18,70)]
        public int Edad { get; set; }

        [Display(Name = "Dni")]
        [StringLength(maximumLength: 9, ErrorMessage = "El dni no puede tener menos de 7 o mas de 10 caracteres", MinimumLength = 7)]
        public string DniEmpleado { get; set; }

        [Required]
        [StringLength(maximumLength: 9, ErrorMessage = "El Nro de telefono no puede tener menos de 8 o mas de 10 caracteres", MinimumLength = 7)]
        public string Telefono { get; set; }

        [Display(Name = "Correo electronico")]
        [DataType(dataType: DataType.EmailAddress)]
        public string Gmail { get; set; }

        [ForeignKey("Rama")]
        [Display(Name = "Especialidad")]
        public int RamaId { get; set; }

        public RamasEspecialidad Rama { get; set; }

        public string Estado { get; set; }

        public string Observaciones { get; set; }

    }
}
