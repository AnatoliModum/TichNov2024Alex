using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDAdoEstatus
{
    internal interface ICRUDEstatus
    {
        List<Estatus> Consultar();
        Estatus Consultar(int id);
        int Agregar(Estatus _estatus);
        void Actualizar(Estatus _estatus);
        void Eliminar(int id);
    }
}
