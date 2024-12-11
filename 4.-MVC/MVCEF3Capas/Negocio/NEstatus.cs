using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Negocio
{
    public class NEstatus
    {
        private readonly EjerciciosTichEntities _context = new EjerciciosTichEntities();

        public NEstatus()
        {
        }

        public NEstatus(EjerciciosTichEntities context)
        {
            _context = context;
        }

        public IEnumerable<EstatusAlumnos> Consultar()
        {
            return _context.EstatusAlumnos.ToList();
        }

    }
}
