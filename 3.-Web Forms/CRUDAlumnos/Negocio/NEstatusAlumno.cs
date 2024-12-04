using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
    internal class NEstatusAlumno
    {
        DEstatusAlumno _controller = new DEstatusAlumno();
        List<EstatusAlumno> Consultar() => _controller.Consultar();
        
        EstatusAlumno Consultar(int id) => _controller.Consultar(id);
    }
}
