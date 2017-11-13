using FluentNHibernate.Mapping;
using ToDoList.Core.Domain.Entidades;

namespace ToDoList.Core.Infrastructure.Maps
{
    public class StatusTaskMap : ClassMap<StatusTask>
    {
        public StatusTaskMap()
        {
            Table("StatusTarefa");

            Id(x => x.Id, "id_statustarefa");

            Map(x => x.CreationDate, "datahora_criacao").Not.Nullable();
            Map(x => x.CreationUser, "usuario_criacao").Not.Nullable();
            Map(x => x.AlterDate, "datahora_alteracao").Nullable();
            Map(x => x.AlterUser, "usuario_alteracao").Nullable();
            Map(x => x.Description, "descricao").Not.Nullable();
        }
    }
}
