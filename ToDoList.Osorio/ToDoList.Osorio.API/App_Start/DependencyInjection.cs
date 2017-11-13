using DryIoc;
using DryIoc.WebApi;
using NHibernate;
using NHibernate.Context;
using System.Web.Http;
using ToDoList.Core.Domain.Repository;
using ToDoList.Core.Infrastructure.NH;
using ToDoList.Core.Infrastructure.Repository;

namespace ToDoList.API
{
    public class DependencyInjection
    {
        public static Container Container = new Container();

        public static void Configure(HttpConfiguration config)
        {
            Container.UseInstance(GetSession());

            //Repositorys
            Container.Register(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            Container.Register<ITaskRepository, TaskRepository>(Reuse.InWebRequest);
            Container.Register<IStatusTaskRepository, StatusTaskRepository>(Reuse.InWebRequest);

            Container.WithWebApi(config);
        }

        private static ISession GetSession()
        {
            ISession session;

            if (CurrentSessionContext.HasBind(NHConfig.SessionFactory))
            {
                session = NHConfig.SessionFactory.GetCurrentSession();
            }
            else
            {
                session = NHConfig.SessionFactory.OpenSession();
                CurrentSessionContext.Bind(session);
            }

            return session;
        }
    }
}