using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
    public class NEstatusAlumno
    {
        DEstatusAlumno _controller = new DEstatusAlumno();
        public List<EstatusAlumno> Consultar() => _controller.Consultar();

        public EstatusAlumno Consultar(int id) => _controller.Consultar(id);
    }
}
