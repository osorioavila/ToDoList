using NHibernate;
using NHibernate.Linq;
using System.Linq;
using ToDoList.Core.Domain.Repository;

namespace ToDoList.Core.Infrastructure.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly ISession _session;

        public RepositoryBase(ISession session)
        {
            _session = session;
        }

        public virtual void Delete(T obj)
        {
            _session.Delete(obj);
            _session.Flush();
        }

        public virtual IQueryable<T> ListAll()
        {
            return _session.Query<T>();
        }

        public virtual T GetById(int id)
        {
            return _session.Get<T>(id);
        }

        public virtual T Save(T obj)
        {
            _session.SaveOrUpdate(obj);
            _session.Flush();

            return obj;
        }

    }
}
