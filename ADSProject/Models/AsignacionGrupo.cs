using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADSProject.Models
{
    [Table("AsignacionGrupo")]
    public class AsignacionGrupo
    {
        public int Id { get; set; }
        [Display(Name = "Grupo")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public int IdGrupo { get; set; }
        [Display(Name = "Estudiante")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public int IdEstudiante { get; set; }
        [ForeignKey("IdGrupo")]
        public Grupo Grupo { get; set; }
        [ForeignKey("IdEstudiante")]
        public Estudiante Estudiante { get; set; }
    }
}