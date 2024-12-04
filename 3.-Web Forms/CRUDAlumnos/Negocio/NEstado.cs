using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
    public class NEstado
    {
        DEstado _controller = new DEstado();
        public List<Estado> Consultar() => _controller.Consultar();
        public Estado Consultar(int id) => _controller.Consultar(id);
    }
}
