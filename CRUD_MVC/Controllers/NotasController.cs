	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web;
	using System.Web.Mvc;
	using CRUD_MVC.Models.ViewModels;
	using CRUD_MVC.Models;

	namespace CRUD_MVC.Controllers
	{
	public class NotasController : Controller
	{
		// GET: Notas
		public ActionResult Index()
		{
			List<ListNotasViewModel> lst;
			using (jmendozaEntities db = new jmendozaEntities())
			{
				lst = (from dt in db.Notas_Alumnos select new ListNotasViewModel
						{
							Id = dt.Id,
							Alumno = dt.Alumno,
							Materia = dt.Materia,
							Nota1 = dt.Nota1,
							Nota2 = dt.Nota2,
							Nota3 = dt.Nota3,
							Promedio = dt.Promedio,
							Estado = dt.Estado
				}).ToList();
			}
			return View(lst);
		}
		public ActionResult Nuevo()
		{
			return PartialView();
		}

		[HttpPost]
		public JsonResult Nuevo(NotasViewModel model)
		{
			int id_gen = 0;
			try
			{
				if (ModelState.IsValid)
				{
					using (jmendozaEntities db = new jmendozaEntities())
					{

						Notas_Alumnos dbTabla = new Notas_Alumnos
						{
							Id = model.Id,
							Alumno = model.Alumno,
							Materia = model.Materia,
							Nota1 = model.Nota1,
							Nota2 = model.Nota2,
							Nota3 = model.Nota3,
							Promedio = (model.Nota1+ model.Nota2+ model.Nota3)/3,
							Estado = model.Estado
						};
						db.Notas_Alumnos.Add(dbTabla);
						db.SaveChanges();
						id_gen = dbTabla.Id;
					}
					return Json(new { auto_ID = id_gen, success = true, alumno = model });
				}
				return Json(new { auto_ID = id_gen, success = false, alumno = model });
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
		public ActionResult Editar(int Id)
		{
			NotasViewModel model = new NotasViewModel();
			using (jmendozaEntities db = new jmendozaEntities())
			{
				var dbTabla = db.Notas_Alumnos.Find(Id);
				model.Id = dbTabla.Id;
				model.Alumno= dbTabla.Alumno;
				model.Materia = dbTabla.Materia;
				model.Nota1 = dbTabla.Nota1;
				model.Nota2 = dbTabla.Nota2;
				model.Nota3 = dbTabla.Nota3;
				model.Promedio = dbTabla.Promedio;
				model.Estado = dbTabla.Estado;
			}
			return PartialView(model);
		}
		[HttpPost]
		public ActionResult Editar(NotasViewModel model)
		{
			int id_gen=0;
			try
			{
				if (ModelState.IsValid)
				{
					using (jmendozaEntities db = new jmendozaEntities())
					{
						var dbTabla = db.Notas_Alumnos.Find(model.Id);
						dbTabla.Id = model.Id;
						dbTabla.Alumno= model.Alumno;
						dbTabla.Materia = model.Materia;
						dbTabla.Nota1 = model.Nota1;
						dbTabla.Nota2= model.Nota2;
						dbTabla.Nota3 = model.Nota3;
						dbTabla.Promedio = (model.Nota1 + model.Nota2 + model.Nota3)/3;
						dbTabla.Estado = model.Estado;
						//Guarda los cambios
						db.Entry(dbTabla).State = System.Data.Entity.EntityState.Modified;
						db.SaveChanges();
						id_gen = dbTabla.Id;

					}
					return Json(new { auto_ID = id_gen, success = true, alumno = model });
				}
				return Json(new { auto_ID = id_gen, success = false, alumno = model });

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
				var dbTabla = db.Notas_Alumnos.Find(Id);
				db.Notas_Alumnos.Remove(dbTabla);
				db.SaveChanges();
			}
			return Redirect("~/Notas");
		}
	}
	}