using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenModuloC.Model.Interface
{
    internal interface ICrudDao<T>
    {
        T get(int id);
        T save(T entity);
        bool update(T entity);
        bool delete(int id);
    }
}
