using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ToDoList.Web.Models;

namespace ToDoList.Web.Controllers
{
    public class TasksController : Controller
    {
        // GET: Tasks
        public async Task<ActionResult> Index()
        {
            List<TaskModel> tasks = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIAddress"]);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync("api/tasks");

                if (response.IsSuccessStatusCode)
                {
                    var tasksResponse = response.Content.ReadAsStringAsync().Result;
                    var task = JsonConvert.DeserializeObject<List<TaskModel>>(tasksResponse);

                    tasks = task.ToList();
                }
            }

            ViewBag.Tasks = tasks;

            return View("Index", new TaskModel());
        }

        // GET: Tasks/Create
        public ActionResult Create(int id)
        {
            var model = new TaskModel();
            model.Status = new StatusTaskModel() { Id = id };

            return PartialView("Create", model);
        }

        // POST: Tasks/Create
        [HttpPost]
        public async Task<ActionResult> Create(TaskModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var client = new HttpClient())
                    {
                        model.Status = new StatusTaskModel() { Id = model.Id };

                        model.Id = 0;

                        client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIAddress"]);
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        var content = JsonConvert.SerializeObject(model);
                        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                        var byteContent = new ByteArrayContent(buffer);
                        byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                        var response = await client.PostAsync("api/tasks", byteContent);

                        if (response.IsSuccessStatusCode)
                        {
                            var tasksResponse = response.Content.ReadAsStringAsync().Result;
                        }
                    }

                    return RedirectToAction("Index");
                }
                else
                {
                    return PartialView(model);
                }
            }
            catch
            {
                return PartialView(model);
            }
        }

        // GET: Tasks/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            TaskModel task = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIAddress"]);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync(string.Format("api/tasks/{0}", id));

                if (response.IsSuccessStatusCode)
                {
                    var tasksResponse = response.Content.ReadAsStringAsync().Result;
                    task = JsonConvert.DeserializeObject<TaskModel>(tasksResponse);
                }
            }

            return PartialView("Edit", task);
        }

        // POST: Tasks/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, TaskModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIAddress"]);
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        var content = JsonConvert.SerializeObject(model);
                        var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                        var byteContent = new ByteArrayContent(buffer);
                        byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                        var response = await client.PutAsync(string.Format("api/tasks/{0}", id), byteContent);

                        if (response.IsSuccessStatusCode)
                        {
                            var tasksResponse = response.Content.ReadAsStringAsync().Result;
                        }
                    }

                    return RedirectToAction("Index");
                }
                else
                {
                    return PartialView(model);
                }
            }
            catch
            {
                return PartialView(model);
            }
        }

        public async Task<ActionResult> Details(int id)
        {
            TaskModel task = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIAddress"]);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync(string.Format("api/tasks/{0}", id));

                if (response.IsSuccessStatusCode)
                {
                    var tasksResponse = response.Content.ReadAsStringAsync().Result;
                    task = JsonConvert.DeserializeObject<TaskModel>(tasksResponse);
                }
            }

            return PartialView("Details", task);
        }

        // GET: Tasks/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            TaskModel task = null;

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIAddress"]);

                client.DefaultRequestHeaders.Clear();

                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                var response = await client.GetAsync(string.Format("api/tasks/{0}", id));

                //Checking the response is successful or not which is sent using HttpClient  
                if (response.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var tasksResponse = response.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    task = JsonConvert.DeserializeObject<TaskModel>(tasksResponse);

                }
            }

            //returning the employee list to view  
            return PartialView("Delete", task);
        }

        // POST: Tasks/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIAddress"]);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = await client.DeleteAsync(string.Format("api/tasks/{0}", id));

                    if (response.IsSuccessStatusCode)
                    {
                        var tasksResponse = response.Content.ReadAsStringAsync().Result;
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public async Task UpdateNewList(string tasks, string column)
        {

            var newTasks = tasks.Split(',').Select(Int32.Parse).ToList();
            var newStatus = new String(column.ToCharArray().Where(c => Char.IsDigit(c)).ToArray());

            foreach (var item in newTasks)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIAddress"]);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var content = JsonConvert.SerializeObject(newStatus);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    var response = await client.PutAsync(string.Format("api/tasks/status/{0}", item), byteContent);

                    if (response.IsSuccessStatusCode)
                    {
                        var tasksResponse = response.Content.ReadAsStringAsync().Result;
                    }
                }
            }

        }
    }
}
