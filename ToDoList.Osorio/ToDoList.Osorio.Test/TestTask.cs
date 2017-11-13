using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.API.Controllers;
using ToDoList.Core.Domain.Entidades;
using System.Collections.Generic;
using ToDoList.Core.Infrastructure.Repository;
using ToDoList.Core.Domain.Repository;
using AutoMoq;
using ToDoList.Osorio.Test.Builder;
using System.Linq;

namespace ToDoList.Osorio.Test
{
    [TestClass]
    public class TestTask
    {
        [TestClass]
        public class TestSimpleTaskController
        {
            [TestMethod]
            public void GetAllTasks()
            {
                var quantity = 1;
                var tasks = TaskBuilder.GetTasks(quantity);

                var moq = new AutoMoqer();
                moq.GetMock<ITaskRepository>()
                    .Setup(x => x.ListAll())
                    .Returns(tasks.AsQueryable());

                var svc = moq.Create<TaskRepository>();

                var activeTasks = svc.ListAll().ToList();

                Assert.IsTrue(activeTasks.Count == 1);
            }
            [TestMethod]
            public void GetByIdTasks()
            {
                var quantity = 1;
                var tasks = TaskBuilder.GetTasks(quantity);

                var moq = new AutoMoqer();
                moq.GetMock<ITaskRepository>()
                    .Setup(x => x.ListAll())
                    .Returns(tasks.AsQueryable());

                var svc = moq.Create<TaskRepository>();

                var activeTask = svc.GetById(1);

                Assert.IsTrue(activeTask != null);
            }
            
        }
    }
}
