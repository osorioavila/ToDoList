using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ToDoList.Core.Domain.Entidades;
using ToDoList.Core.Domain.Repository;



namespace ToDoList.API.Controllers
{
    public class TasksController : ApiController
    {
        private ITaskRepository _taskRepository;
        private IStatusTaskRepository _statusTaskRepository;

        public TasksController(ITaskRepository taskRepository, IStatusTaskRepository statusTaskRepository)
        {
            _taskRepository = taskRepository;
            _statusTaskRepository = statusTaskRepository;

        }

        // GET: api/tasks
        [Route("api/tasks")]
        [HttpGet]
        public List<Task> Get()
        {
            var listTasks = _taskRepository.ListAll().ToList();
            return listTasks;
        }

        // GET: api/tasks/1
        [Route("api/tasks/{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var obj = _taskRepository.GetById(id);

            if (obj == null)
            {
                return NotFound();
            }

            return Ok(obj);
        }

        // POST: api/tasks
        [Route("api/tasks")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]Task task)
        {
            try
            {
                task.CreationUser = "Sistema";
                task.CreationDate = DateTime.Now;
                
                task.Status = _statusTaskRepository.GetById(task.Status.Id);

                _taskRepository.Save(task);

                return Created("Ok", task.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        // PUT: api/tasks/1
        [Route("api/tasks/{id}")]
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]Task task)
        {
            try
            {
                var obj = _taskRepository.GetById(id);

                if (obj == null)
                {
                    return NotFound();
                }

                obj.AlterDate = DateTime.Now;
                obj.AlterUser = "Sistema";
                obj.Title = task.Title;
                obj.Description = task.Description;

                _taskRepository.Save(obj);

                return Ok(task);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/tasks/status/1
        [Route("api/tasks/status/{id}")]
        [HttpPut]
        public IHttpActionResult PutStatus(int id, [FromBody]int task)
        {
            try
            {
                var obj = _taskRepository.GetById(id);

                if (obj == null)
                {
                    return NotFound();
                }

                obj.AlterDate = DateTime.Now;
                obj.AlterUser = "Sistema";
             
                var newStatus = _statusTaskRepository.GetById(task);

                if (obj.Status.Id != newStatus.Id)
                {
                    obj.Status = newStatus;
                    _taskRepository.Save(obj);
                }
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Tasks/5
        [HttpDelete]
        [Route("api/tasks/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var obj = _taskRepository.GetById(id);

                if (obj == null)
                {
                    return NotFound();
                }
                obj.Status = _statusTaskRepository.GetById(4); // cod 4 = Excluido
                
                _taskRepository.Save(obj);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
