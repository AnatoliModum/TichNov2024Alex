using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
    internal class NEstado
    {
        DEstado _controller = new DEstado();
        List<Estado> Consultar() => _controller.Consultar();
        Estado Consultar(int id) => _controller.Consultar(id);
    }
}
