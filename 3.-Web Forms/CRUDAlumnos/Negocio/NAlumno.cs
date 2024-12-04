using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
    public class NAlumno
    {
        DAlumno _controller = new DAlumno();
        public List<Alumno> Consultar() => _controller.Consultar();
        public Alumno Consultar(int id) => _controller.Consultar(id);
        public void Agregar(Alumno alumno) => _controller.Agregar(alumno);
        public void Actualizar(Alumno alumno) => _controller.Actualizar(alumno);
        public void Eliminar(int id) => _controller.Eliminar(id);
    }
}
