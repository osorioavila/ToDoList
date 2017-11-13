using System;

namespace ToDoList.Core.Domain.Entidades
{
    public class Task
    {
        public virtual int Id { get; set; }
        public virtual DateTime CreationDate { get; set; }
        public virtual string CreationUser { get; set; }
        public virtual DateTime? AlterDate { get; set; }
        public virtual string AlterUser { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual StatusTask Status { get; set; }

    }
}
