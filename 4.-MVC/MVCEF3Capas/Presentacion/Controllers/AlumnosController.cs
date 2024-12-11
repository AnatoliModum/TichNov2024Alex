using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Negocio;
using Entidades;

namespace Presentacion.Controllers
{
    public class AlumnosController : Controller
    {
        NAlumno negAlu = new NAlumno();
        NEstados negEsta = new NEstados();
        NEstatus negEstaAlu = new NEstatus();

        // GET: Alumnos
        public ActionResult Index() => View(negAlu.ConsultaCompleta());

        // GET: Alumnos/Details/5
        public ActionResult Details(int? id) => View(negAlu.ConsultaCompletaById(id));

        // GET: Alumnos/Create
        public ActionResult Create()
        {
            ViewBag.idEstadoOrigen = new SelectList(negEsta.Consultar(), "id", "nombre");
            ViewBag.idEstatus = new SelectList(negEstaAlu.Consultar(), "id", "nombre");
            return View();
        }

        // POST: Alumnos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,primerApellido,segundoApellido,correo,telefono,fechaNacimiento,curp,sueldo,idEstadoOrigen,idEstatus")] Alumnos alumnos)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    negAlu.Agregar(alumnos);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                   
                }
                
            }

            ViewBag.idEstadoOrigen = new SelectList(negEsta.Consultar(), "id", "nombre");
            ViewBag.idEstatus = new SelectList(negEstaAlu.Consultar(), "id", "nombre");
            return View(alumnos);
        }

        // GET: Alumnos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumnos alumnos = negAlu.ConsultaCompletaById(id);
            if (alumnos == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEstadoOrigen = new SelectList(negEsta.Consultar(), "id", "nombre");
            ViewBag.idEstatus = new SelectList(negEstaAlu.Consultar(), "id", "nombre");
            return View(alumnos);
        }

        // POST: Alumnos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,primerApellido,segundoApellido,correo,telefono,fechaNacimiento,curp,sueldo,idEstadoOrigen,idEstatus")] Alumnos alumnos)
        {
            if (ModelState.IsValid)
            {
                negAlu.Actualizar(alumnos);
                return RedirectToAction("Index");
            }
            ViewBag.idEstadoOrigen = new SelectList(negEsta.Consultar(), "id", "nombre");
            ViewBag.idEstatus = new SelectList(negEstaAlu.Consultar(), "id", "nombre");
            return View(alumnos);
        }

        // GET: Alumnos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumnos alumnos = negAlu.ConsultaCompletaById(id);
            if (alumnos == null)
            {
                return HttpNotFound();
            }
            return View(alumnos);
        }

        // POST: Alumnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alumnos alumnos = negAlu.ConsultaCompletaById(id);
            negAlu.Eliminar(alumnos.id);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

    }
}