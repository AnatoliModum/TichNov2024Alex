using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    public class DRepositorio<T> : IRepositorioBase<T> where T : class
    {
        private readonly EjerciciosTichEntities _context;
        private readonly DbSet<T> _dbSet;

        public DRepositorio(EjerciciosTichEntities context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public void Actualizar(T entidad)
        {
            _dbSet.Attach(entidad);
            _context.Entry(entidad).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Agregar(T entidad) { 
            _dbSet.Add(entidad);
            _context.SaveChanges();
        }
        public List<T> Consultar() => _dbSet.ToList();
        

        public List<T> Consultar(Expression<Func<T, bool>> predicado)
        {
            throw new NotImplementedException();
        }

        public T Consultar(int id) => _dbSet.Find(id);
        public T Consultar2(Expression<Func<T, bool>> predicado) => throw new NotImplementedException();

        public void Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(T Entidad)
        {
            _context.Entry(Entidad).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void Eliminar(Expression<Func<T, bool>> predicado)
        {
            throw new NotImplementedException();
        }
    }
}
