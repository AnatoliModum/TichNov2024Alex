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
        private readonly EjerciciosTichEntities _context = new EjerciciosTichEntities();

        public NAlumno(EjerciciosTichEntities context)
        {
            _context = context;
        }

        public NAlumno()
        {
        }

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
    }

}
