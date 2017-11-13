using NHibernate;
using ToDoList.Core.Domain.Entidades;
using ToDoList.Core.Domain.Repository;

namespace ToDoList.Core.Infrastructure.Repository
{
    public class StatusTaskRepository : RepositoryBase<StatusTask>, IStatusTaskRepository
    {
        public StatusTaskRepository(ISession session) : base(session)
        {
        }
    }
}
