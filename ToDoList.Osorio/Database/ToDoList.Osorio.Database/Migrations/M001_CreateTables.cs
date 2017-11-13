using FluentMigrator;
using System;

namespace ToDoList.Database.Migrations
{
    [Migration(1)]
    public class M0001_CreateTables : Migration
    {
        public override void Up()
        {
            Create.Table("StatusTarefa")
                .WithColumn("id_statustarefa").AsInt32().PrimaryKey().Identity()
                .WithColumn("datahora_criacao").AsDateTime().NotNullable().WithDefaultValue(DateTime.Now)
                .WithColumn("usuario_criacao").AsString(100).NotNullable()
                .WithColumn("datahora_alteracao").AsDateTime().Nullable()
                .WithColumn("usuario_alteracao").AsCustom("VARCHAR(100)").Nullable()
                .WithColumn("descricao").AsCustom("VARCHAR(max)").NotNullable();

            Create.Table("Tarefa")
                .WithColumn("id_tarefa").AsInt32().PrimaryKey().Identity()
                .WithColumn("datahora_criacao").AsDateTime().NotNullable().WithDefaultValue(DateTime.Now)
                .WithColumn("usuario_criacao").AsString(100).NotNullable()
                .WithColumn("datahora_alteracao").AsDateTime().Nullable()
                .WithColumn("usuario_alteracao").AsCustom("VARCHAR(100)").Nullable()
                .WithColumn("titulo").AsCustom("VARCHAR(15)").NotNullable()
                .WithColumn("descricao").AsCustom("VARCHAR(max)").NotNullable()
                .WithColumn("id_statustarefa").AsInt32().ForeignKey("StatusTarefa", "id_statustarefa");
                
            Execute.Sql("INSERT INTO[dbo].[StatusTarefa]([datahora_criacao],[usuario_criacao],[datahora_alteracao],[usuario_alteracao],[descricao]) VALUES(getdate(),'osorio', NULL, NULL,'A fazer')");
            Execute.Sql("INSERT INTO[dbo].[StatusTarefa]([datahora_criacao],[usuario_criacao],[datahora_alteracao],[usuario_alteracao],[descricao]) VALUES(getdate(),'osorio', NULL, NULL,'Em Andamento')");
            Execute.Sql("INSERT INTO[dbo].[StatusTarefa]([datahora_criacao],[usuario_criacao],[datahora_alteracao],[usuario_alteracao],[descricao]) VALUES(getdate(),'osorio', NULL, NULL,'Em Andamento')");
            Execute.Sql("INSERT INTO[dbo].[StatusTarefa]([datahora_criacao],[usuario_criacao],[datahora_alteracao],[usuario_alteracao],[descricao]) VALUES(getdate(),'osorio', NULL, NULL,'Excluido')");

        }

        public override void Down()
        {
            Delete.Table("StatusTarefa");
            Delete.Table("Tarefa");
        }
    }
}
