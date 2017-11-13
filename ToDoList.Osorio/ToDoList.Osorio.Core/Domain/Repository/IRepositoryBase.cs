using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Core.Domain.Repository
{
    public interface IRepositoryBase<T> where T : class
    {
        T GetById(int id);
        void Delete(T obj);
        IQueryable<T> ListAll();
        T Save(T obj);
    }
}
