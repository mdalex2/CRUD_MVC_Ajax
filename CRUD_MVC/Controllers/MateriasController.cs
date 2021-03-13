using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD_MVC.Models;
using CRUD_MVC.Models.ViewModels;

namespace CRUD_MVC.Controllers
{
    public class MateriasController : Controller
    {
        // GET: Materias
        public ActionResult Index()
        {
            List<ListMateriasViewModel> lst;
            using (jmendozaEntities db = new jmendozaEntities())
            {
                lst = (from d in db.Materias
                           select new ListMateriasViewModel
                           {
                               Id = d.Id,
                               Nombre_mat = d.Nombre_mat
                           }).ToList();
            }
            return View(lst);
        }
        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(MateriasViewModels model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (jmendozaEntities db = new jmendozaEntities())
                    {
                        Materias dbTabla = new Materias
                        {
                            Id = model.Id,
                            Nombre_mat = model.Nombre_mat
                        };
                        db.Materias.Add(dbTabla);
                        db.SaveChanges();
                        
                    }
                    return Redirect("/Materias");
                }
                return View(model);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);                
            }
        }
        public ActionResult Editar(int Id)
        {
            MateriasViewModels model = new MateriasViewModels();
            using (jmendozaEntities db = new jmendozaEntities())
            {
                var dbTabla = db.Materias.Find(Id);
                model.Id = dbTabla.Id;
                model.Nombre_mat = dbTabla.Nombre_mat;
            }
                return View(model);
        }

        [HttpPost]
        public ActionResult Editar(MateriasViewModels model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (jmendozaEntities db = new jmendozaEntities())
                    {
                        var dbTabla = db.Materias.Find(model.Id);
                        dbTabla.Id = model.Id;
                        dbTabla.Nombre_mat = model.Nombre_mat;
                        db.Entry(dbTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                    }
                    return Redirect("~/Materias");
                }
                return View(model);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        [HttpGet]
        public ActionResult Eliminar(int Id)
        {
            //MateriasViewModels model = new MateriasViewModels();
            using (jmendozaEntities db = new jmendozaEntities())
            {
                var dbTabla = db.Materias.Find(Id);
                db.Materias.Remove(dbTabla);
                db.SaveChanges();
            }
            return Redirect("~/Materias");
        }
    }
}