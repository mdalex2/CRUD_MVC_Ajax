using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_MVC.Models.ViewModels
{
    public class ListNotasViewModel
    {
        public int Id { get; set; }
        public string Alumno { get; set; }
        public string Materia { get; set; }
        public decimal Nota1 { get; set; }
        public decimal Nota2 { get; set; }
        public decimal Nota3 { get; set; }
        public decimal Promedio { get; set; }
        public string Estado { get; set; }
    }
}