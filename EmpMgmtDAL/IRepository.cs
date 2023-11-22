using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpMgmtDAL
{
    // where T : class is used to restrict the type parameter T to be a reference type, i.e., a class or an interface, but not a value type like int or double.
    // Ex; T can be of type Employee class/Grade class
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(string name);
        T GetById(int id);
        bool Add(T entity);
        bool Update(T entity);
    }
}
