using FluentNHibernate.Mapping;
using ToDoList.Core.Domain.Entidades;

namespace ToDoList.Core.Infrastructure.Maps
{
    public class TaskMap : ClassMap<Task>
    {
        public TaskMap()
        {
            Table("Tarefa");

            Id(x => x.Id, "id_tarefa");

            Map(x => x.CreationDate, "datahora_criacao").Not.Nullable();
            Map(x => x.CreationUser, "usuario_criacao").Not.Nullable();
            Map(x => x.AlterDate, "datahora_alteracao").Nullable();
            Map(x => x.AlterUser, "usuario_alteracao").Nullable();
            Map(x => x.Title, "titulo").Not.Nullable();
            Map(x => x.Description, "descricao").Not.Nullable();

            References(c => c.Status).Column("id_statustarefa").Cascade.All().Not.LazyLoad();
        }
    }
}
