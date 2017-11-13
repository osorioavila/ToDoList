using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using ToDoList.Core.Domain.Entidades;

namespace ToDoList.Osorio.Test.Builder
{
    [ExcludeFromCodeCoverage]
    public static class TaskBuilder
    {
        public static IEnumerable<Task> GetTasks(int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                var item = new Task()
                {
                    Id = i + 1,
                    Status = new StatusTask() { Id = 4 }
                };

                yield return item;
            }
        }

        public static IEnumerable<Task> AllExcluded(this IEnumerable<Task> list)
        {
            foreach (var item in list)
            {
                item.Status.Id = 4;
                yield return item;
            }
        }
    }
}
