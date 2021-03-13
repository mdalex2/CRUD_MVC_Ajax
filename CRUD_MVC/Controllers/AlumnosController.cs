using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD_MVC.Models;
using CRUD_MVC.Models.ViewModels;
using System.Threading;
using System.Configuration;
using System.Data.SqlClient;

namespace CRUD_MVC.Controllers
{
    public class AlumnosController : Controller
    {
        // GET: Alumnos
        public ActionResult Index()
        {
            List<ListAlumnosViewModel> lst;
            using (jmendozaEntities db = new jmendozaEntities())
            {
                lst = (from d in db.Alumnos
                       select new ListAlumnosViewModel
                       {
                           Id = d.Id,
                           Nombre = d.Nombre,
                           Telefono = d.Telefono,
                           Direccion = d.Direccion,
                           Fecha_nac = d.Fecha_nac.Value
                       }).ToList();
            }
            return View(lst);
        }
        public ActionResult Nuevo()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult Nuevo(AlumnosViewModel model)
        {
            var id_gen=0;
            try
            {

                if (ModelState.IsValid)
                {
                    using (jmendozaEntities db = new jmendozaEntities())
                    {

                        Alumnos dbTabla = new Alumnos
                        {
                            Id = model.Id,
                            Nombre = model.Nombre,
                            Direccion = model.Direccion,
                            Telefono = model.Telefono,
                            Fecha_nac = model.Fecha_nac                            
                        };

                        db.Alumnos.Add(dbTabla);
                        db.SaveChanges();
                        id_gen = dbTabla.Id;
                    }
                    
                    return Json(new {auto_ID=id_gen, success = true, alumno = model });
                }
                return Json(new { success = false, alumno = model });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ActionResult Editar(int Id)
        {
            AlumnosViewModel model = new AlumnosViewModel();
            using (jmendozaEntities db = new jmendozaEntities())
            {
                var dbTabla = db.Alumnos.Find(Id);
                model.Id = dbTabla.Id;
                model.Nombre = dbTabla.Nombre;
                model.Direccion = dbTabla.Direccion;
                model.Telefono = dbTabla.Telefono;
                model.Fecha_nac = dbTabla.Fecha_nac;
            }
            return PartialView(model);
        }
        [HttpPost]
        public JsonResult Editar(AlumnosViewModel model)
        {
            //Json result para validar en el js luego si la edición se realizó o no 
            //y hacer las actividades posteriores con jquery para la visualización dinámica de los datos.
            try
            {
                if (ModelState.IsValid)
                {

                    using (jmendozaEntities db = new jmendozaEntities())
                    {
                        var dbTabla = db.Alumnos.Find(model.Id);
                        dbTabla.Id = model.Id;
                        dbTabla.Nombre = model.Nombre;
                        dbTabla.Direccion = model.Direccion;
                        dbTabla.Telefono = model.Telefono;
                        dbTabla.Fecha_nac = model.Fecha_nac;
                        db.Entry(dbTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }                    
                    return Json(new {success=true,alumno = model });
                }
                return Json(new { success = false, alumno = model });

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        [HttpGet]
        public ActionResult Eliminar(int Id)
        {
            //AlumnosViewModel model = new AlumnosViewModel();
            using (jmendozaEntities db = new jmendozaEntities())
            {
                var dbTabla = db.Alumnos.Find(Id);
                db.Alumnos.Remove(dbTabla);
                db.SaveChanges();
            }
            return Redirect("~/Alumnos");
        }

    }
}