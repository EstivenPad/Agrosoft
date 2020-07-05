using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Agrosoft.BLL
{
    public interface IRepository<T> where T : class
    {
        List<T> GetList(Expression<Func<T, bool>> expression);
        T Buscar(int id);
        bool Guardar(T entity, int id);
        bool Insertar(T entity);
        bool Modificar(T entity);
        bool Eliminar(int id);
        bool Existe(int id);
    }
}
