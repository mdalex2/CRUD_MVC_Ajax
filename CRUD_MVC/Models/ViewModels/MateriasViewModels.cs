using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD_MVC.Models.ViewModels
{
    public class MateriasViewModels
    {
        [Required]
        [Display(Name = "Id Materia")]
        public int Id { get; set; }

        [Required]
        [Display(Name ="Materia")]
        [StringLength(20)]
        public string Nombre_mat { get; set; }
        [StringLength(30)]
        [Display(Name ="Otro")]
        public string otro { get; set; }
    }
}