using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace Negocio
{
    public class NEstados
    {
        private readonly EjerciciosTichEntities _context = new EjerciciosTichEntities();

        public NEstados()
        {
        }

        public NEstados(EjerciciosTichEntities context)
        {
            _context = context;
        }

        public IEnumerable<Estados> Consultar()
        {
            return _context.Estados.ToList();
        }
    }
}
