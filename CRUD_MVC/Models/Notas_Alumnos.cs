//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRUD_MVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Notas_Alumnos
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
