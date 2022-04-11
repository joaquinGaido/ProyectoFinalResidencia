using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalResidencia.Models
{
    public class Adolecentes
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [Display(Name = "Nombre Completo")]
        public string NombreCompleto { get { return Apellido + ", " + Nombre; } }

        [Range(1,18)]
        public int Edad { get; set; }

        [Required]
        [StringLength(maximumLength: 9, ErrorMessage = "El dni no puede tener menos de 7 o mas de 10 caracteres", MinimumLength = 7)]
        public string Dni { get; set; }


        public string Genero { get; set; }

        [Display(Name = "Fecha Nacimiento")]
        public DateTime fechaNacimiento { get; set; }

        [Display(Name = "Lugar Nacimiento")]
        public string LugarNacimiento { get; set; }

        [Required]
        public string Nacionalidad { get; set; }

        [Required]
        public string Uder { get; set; }

        [Required]
        public string Jusgado { get; set; }

        [Required]
        public string Escuela { get; set; }

        [Required]
        public string Nivel { get; set; }

        [StringLength(maximumLength: 2, ErrorMessage = "El curso no puede tener menos de 1 o mas de 2 caracteres", MinimumLength = 1)]
        public string Curso { get; set; }

        [Display(Name = "Tratamiento Medico")]
        public bool TratamientoMedico { get; set; }

        [Display(Name = "Tratamiento Psicologico")]
        public bool TratamientoPsicologico { get; set; }

        public bool Medicamento { get; set; }

        [Display(Name = "Reevinculacion Familiares")]
        public string ReevinculacionesFamiliares { get; set; }

        [ForeignKey("Familia")]
        public int familiaId { get; set; }

        public Familias Familia { get; set; }


    }
}
