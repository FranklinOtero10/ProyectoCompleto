using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ADSProject.Models
{
    [Table("Grupo")]
    public class Grupo
    {
        public int id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Este campo no puede quedar vacio")]
        public String Nombre { get; set; }

        [Display(Name = "Carrera")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public int IdCarrera { get; set; }
        [ForeignKey("IdCarrera")]
        public Carrera Carrera { get; set; }

        [Display(Name = "Materia")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public int IdMateria { get; set; }
        [ForeignKey("IdMateria")]
        public Materia Materia { get; set; }

        [Display(Name = "Profesor")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public int IdProfesor { get; set; }
        [ForeignKey("IdProfesor")]
        public Profesor Profesor { get; set; }

        [Display(Name = "Ciclo")]
        [Required(ErrorMessage = "Este campo no puede quedar vacio")]
        public int Ciclo { get; set; }

        [Display(Name = "Año")]
        [Required(ErrorMessage = "Este campo no puede quedar vacio")]
        public int Anio { get; set; }
    }
}