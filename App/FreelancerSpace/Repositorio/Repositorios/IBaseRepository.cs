using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio
{
    interface IBaseRepository<T> where T : class
    {
        T get(int id);
        List<T> getAll();
        bool add(T item);
        bool delete(T item);
        bool edit(T item);


       
    }
}
