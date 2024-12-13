using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    internal interface IRepositorioBase<T> where T : class
    {
        List<T> Consultar();
        List<T> Consultar(Expression<Func<T,bool>> predicado);
        T Consultar(int d);
        T Consultar2(Expression<Func<T, bool>> predicado);
        void Agregar(T entidad);
        void Actualizar(T entidad);
        void Eliminar(int id);
        void Eliminar(T Entidad);
        void Eliminar(Expression<Func<T,bool>> predicado);
    }
}
