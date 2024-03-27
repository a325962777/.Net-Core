using Microsoft.AspNetCore.Mvc;
using Tasks.Interfaces;
using Tasks.Models;

namespace Tasks.controllers;

[ApiController]
[Route("[controller]")]
public class MyTasksController : ControllerBase
{
    public ITaskService TaskService;
    public MyTasksController(ITaskService TaskService)
    {
        this.TaskService = TaskService;
    }
    [HttpGet]
    public ActionResult<IEnumerable<MyTask>> Get()
    {
        return TaskService.GetAll();
    }
    [HttpGet("{id}")]
    public ActionResult<MyTask> Get(int id)
    {
        return TaskService.Get(id);
    }
    [HttpPost]
    public IActionResult Post(MyTask newTask)
    {
           TaskService.Post(newTask);
        return CreatedAtAction(nameof(Post), new { id = newTask.Id }, newTask);
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, MyTask newTask)
    {
        TaskService.Put(id, newTask);
        return Ok();
    }
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        TaskService.Delete(id);
        return Ok();


    }

}