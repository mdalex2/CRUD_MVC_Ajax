using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_MVC.Models.ViewModels
{
    public class NotasViewModel
    {
        [Required]
        [Display(Name = "Id Registro")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Alumno")]
        [StringLength(30)]
        public string Alumno { get; set; }

        [Required]
        [Display(Name = "Materia")]
        [StringLength(30)]
        public string Materia { get; set; }

        [Required]
        //[DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
        [Display(Name = "Nota 1")]
        public decimal Nota1 { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Nota 2")]

        public decimal Nota2 { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Nota 3")]
        public decimal Nota3 { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Promedio")]
        public decimal Promedio { get; set; }

        [Required]
        [Display(Name = "Estado")]
        [StringLength(30)]
        public string Estado { get; set; }
    }
}