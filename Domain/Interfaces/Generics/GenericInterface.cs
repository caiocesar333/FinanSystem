using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Generics
{
    public interface GenericInterface<T> where T : class
    {

        Task Add(T obj);

        Task Update(T obj);

        Task Delete(int Id);

        Task<T> GetEntityById(int Id);

        Task<List<T>> List();
    }
}
