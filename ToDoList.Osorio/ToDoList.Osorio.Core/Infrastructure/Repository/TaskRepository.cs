using NHibernate;
using ToDoList.Core.Domain.Entidades;
using ToDoList.Core.Domain.Repository;

namespace ToDoList.Core.Infrastructure.Repository
{
    public class TaskRepository : RepositoryBase<Task>, ITaskRepository
    {
        public TaskRepository(ISession session) : base(session)
        {
        }
    }
}
