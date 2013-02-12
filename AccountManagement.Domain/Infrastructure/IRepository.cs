using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.Repositories
{
   

    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById<TId>(TId id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
    }
}
