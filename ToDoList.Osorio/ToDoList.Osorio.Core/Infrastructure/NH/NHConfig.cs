using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Core.Infrastructure.NH
{
    public class NHConfig
    {
        public static ISessionFactory SessionFactory;

        public static void Configure()
        {
            SessionFactory = Fluently
           .Configure()
                .Database(MsSqlConfiguration
                    .MsSql2008
                    .ConnectionString(builder => builder.FromConnectionStringWithKey("ConnectionString"))
                    .DoNot.UseOuterJoin()
                    .UseReflectionOptimizer()
                    .ShowSql()
                    .FormatSql())
                .Mappings(m =>
                {
                    m.FluentMappings.Conventions.Setup(x => x.Add(FluentNHibernate.Conventions.Helpers.AutoImport.Never()));
                    IEnumerable<Assembly> dlls = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.GetName().Name.Contains("ToDoList.Core"));
                    foreach (var dll in dlls)
                    {
                        m.FluentMappings.AddFromAssembly(dll);
                    }
                })
                .CurrentSessionContext<ThreadStaticSessionContext>()
                .BuildSessionFactory();
        }
    }
}
