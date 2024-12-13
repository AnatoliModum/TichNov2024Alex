using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Negocio
{
    public class NAlumno
    {
        static private readonly EjerciciosTichEntities _context = new EjerciciosTichEntities();
        Calculos.WCFAlumnosClient wCFAlumnosClient = new Calculos.WCFAlumnosClient();
        DRepositorio<Alumnos> repoCon = new Datos.DRepositorio<Alumnos>(_context);

        public NAlumno()
        {
        }
        public IEnumerable<Alumnos> ConsultaInterfaz() => repoCon.Consultar();
        public Alumnos ConsultaByIdInterfaz(int id) => repoCon.Consultar(id);
        public void AgregarInterfaz(Alumnos alucno) => repoCon.Agregar(alucno);
        public void ActualizarInterfaz(Alumnos alucno) => repoCon.Actualizar(alucno);
        public void EliminarInterfaz(Alumnos alucno) => repoCon.Eliminar(alucno);







        public IEnumerable<Alumnos> ConsultaCompleta()
        {
            var alumnos = _context.Alumnos.Include(a => a.Estados).Include(a => a.EstatusAlumnos);
            return alumnos.ToList();
        }
        public Alumnos ConsultaCompletaById(int? id)
        {
            var alumnos = _context.Alumnos.Include(a => a.Estados).Include(a => a.EstatusAlumnos).Where(a => a.id == id);
            return alumnos.First();
        }
        public void Agregar(Alumnos alumno)
        {
            _context.Alumnos.Add(alumno);
            _context.SaveChanges();
        }

        public void Actualizar(Alumnos alumno)
        {
            _context.Entry(alumno).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var alumno = _context.Alumnos.Find(id);
            if (alumno != null)
            {
                _context.Alumnos.Remove(alumno);
                _context.SaveChanges();
            }
        }

        public Calculos.AportacionesIMSS CalculoIMSS(int id)
        {
            return wCFAlumnosClient.CalcularIMSS(id);
        }
        public Calculos.ItemTablaISR CalculoISR(int id)
        {
            return wCFAlumnosClient.CalcularISR(id);
        }
    }

}
