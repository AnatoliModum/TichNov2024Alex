using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADOWebForms.Entidades;

namespace ADOWebForms.ADO
{
    internal interface ICRUD
    {
        List<EstatusAlumno> Consultar();
        EstatusAlumno Consultar(int id);
        int Agregar(EstatusAlumno estatus);
        void Actualizar(EstatusAlumno estatus);
        void Eliminar(int id);
    }
}
