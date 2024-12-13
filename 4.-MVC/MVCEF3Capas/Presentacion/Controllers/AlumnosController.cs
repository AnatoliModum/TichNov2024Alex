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



        public ActionResult Index() => View(negAlu.ConsultaInterfaz());
        public ActionResult Details(int id) => View(negAlu.ConsultaByIdInterfaz(id));
        public ActionResult Create()
        {
            ViewBag.idEstadoOrigen = new SelectList(negEsta.Consultar(), "id", "nombre");
            ViewBag.idEstatus = new SelectList(negEstaAlu.Consultar(), "id", "nombre");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,primerApellido,segundoApellido,correo,telefono,fechaNacimiento,curp,sueldo,idEstadoOrigen,idEstatus")] Alumnos alumnos)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    negAlu.AgregarInterfaz(alumnos);
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            negAlu.EliminarInterfaz(negAlu.ConsultaByIdInterfaz(id));
            return RedirectToAction("Index");
        }

        public ActionResult _AportacionesIMSS(int id)
        {
            return PartialView(negAlu.CalculoIMSS(id));
        }
        public ActionResult _TablaISR(int id)
        {
            return PartialView(negAlu.CalculoISR(id));
        } 

    }
}