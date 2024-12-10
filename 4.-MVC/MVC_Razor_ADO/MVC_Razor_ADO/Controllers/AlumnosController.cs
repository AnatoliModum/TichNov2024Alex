using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;
using Entidades;
using System.Dynamic;

namespace MVC_Razor_ADO.Controllers
{
    public class AlumnosController : Controller
    {
        private NAlumno negAlu = new NAlumno();
        private NEstado negEsta = new NEstado();
        private NEstatusAlumno negEstaAlu = new NEstatusAlumno();


        public ActionResult Index() => View(RetornarDataCompleta());
        public List<ExpandoObject> RetornarDataCompleta()
        {
            var linqCon = from alucno in negAlu.Consultar()
                          join estado in negEsta.Consultar() on alucno.idEstadoOrigen equals estado.id
                          join estatus in negEstaAlu.Consultar() on alucno.idEstatus equals estatus.id
                          select new
                          {
                              id = alucno.id,
                              Nombre = alucno.nombre,
                              pApellido = alucno.pApellido,
                              sApellido = alucno.sApellido,
                              correo = alucno.correo,
                              telefono = alucno.telefono,
                              Estado = estado.nombre,
                              Estatus = estatus.nombre
                          };

            var expandoList = new List<ExpandoObject>();
            foreach (var item in linqCon)
            {
                dynamic expando = new ExpandoObject();
                expando.Nombre = item.Nombre;
                expando.pApellido = item.pApellido;
                expando.sApellido = item.sApellido;
                expando.Estado = item.Estado;
                expando.Estatus = item.Estatus;
                expando.id = item.id;
                expando.correo = item.correo;
                expando.telefono = item.telefono;
                expandoList.Add(expando);
            }

            return expandoList;
        }
        public List<ExpandoObject> RetornarDataById(int idLinq)
        {
            var linqCon = from alucno in negAlu.Consultar()
                          join estado in negEsta.Consultar() on alucno.idEstadoOrigen equals estado.id
                          join estatus in negEstaAlu.Consultar() on alucno.idEstatus equals estatus.id
                          where alucno.id == idLinq
                          select new
                          {
                              id = alucno.id,
                              Nombre = alucno.nombre,
                              pApellido = alucno.pApellido,
                              sApellido = alucno.sApellido,
                              correo = alucno.correo,
                              telefono = alucno.telefono,
                              Estado = estado.nombre,
                              Estatus = estatus.nombre,
                              birthDay = alucno.fNacimiento.ToString("dd/MM/yyyy"),
                              curp = alucno.curp,
                              sueldo = alucno.sueldo

                          };

            var expandoList = new List<ExpandoObject>();
            foreach (var item in linqCon)
            {
                dynamic expando = new ExpandoObject();
                expando.Nombre = item.Nombre;
                expando.pApellido = item.pApellido;
                expando.sApellido = item.sApellido;
                expando.Estado = item.Estado;
                expando.Estatus = item.Estatus;
                expando.id = item.id;
                expando.correo = item.correo;
                expando.telefono = item.telefono;
                expando.birthDay = item.birthDay;
                expando.curp = item.curp;
                expando.sueldo = item.sueldo;
                expandoList.Add(expando);
            }

            return expandoList;
        }
        public ActionResult Details(int id) => View(RetornarDataById(id)[0]);
        [HttpPost]
        public ActionResult Create(Alumno aluEnt)
        {
            negAlu.Agregar(aluEnt);
            return RedirectToAction("Index");
        }
        public ActionResult Create()
        {

            var estados = negEsta.Consultar();
            var estadosList = estados.Select(e => new SelectListItem { Value = e.id.ToString(), Text = e.nombre }).ToList();
            ViewBag.Estados = estadosList;

            var estatus = negEstaAlu.Consultar();
            var estatusList = estatus.Select(e => new SelectListItem { Value = e.id.ToString(), Text = e.nombre }).ToList();
            ViewBag.Estatus = estatusList;

            return View();
        }
        [HttpPost]
        public ActionResult Edit(Alumno aluAct)
        {
            negAlu.Actualizar(aluAct);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var estados = negEsta.Consultar();
            var estadosList = estados.Select(e => new SelectListItem { Value = e.id.ToString(), Text = e.nombre }).ToList();
            ViewBag.Estados = estadosList;

            var estatus = negEstaAlu.Consultar();
            var estatusList = estatus.Select(e => new SelectListItem { Value = e.id.ToString(), Text = e.nombre }).ToList();
            ViewBag.Estatus = estatusList;

            return View(negAlu.Consultar(id));
        } 
        [HttpPost]
        public ActionResult Delete(Alumno aluAct)
        {
            negAlu.Eliminar(aluAct.id);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id) => View(RetornarDataById(id));
    }
}