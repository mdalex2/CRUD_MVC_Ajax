using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CRUD_MVC.Models.ViewModels
{
    public class AlumnosViewModel
    {        
        [Required]
        [Key]
        [Display(Name ="Id Alumno")]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Alumno")]
        [StringLength(30)]

        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Dirección")]
        [StringLength(100)]
        public string Direccion { get; set; }
        [Required]
        [Display(Name = "Teléfono")]
        [StringLength(20)]
        public string Telefono { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de nacimiento")] 
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)] // para visualizar bien la fecha en el date picker del html5
        public Nullable<System.DateTime> Fecha_nac { get; set; }
    }
}