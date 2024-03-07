using Microsoft.AspNetCore.Mvc; 
using Tasks.Models;

namespace Tasks.Controllers;
[ApiController]
[Route("[controller]")]
public class MyTaskController : ControllerBase

{
    static List<MyTask> list;

    static MyTaskController()
    {
         list = new List<MyTask>
         {
            new MyTask { Id = 1, NameTask = "HW", IsDone = false},
            new MyTask { Id = 2, NameTask = "wash the dishes", IsDone = true},
            new MyTask { Id = 3, NameTask = "go to sleep", IsDone = true},
         };
    }

    [HttpGet]
    public IEnumerable<MyTask> Get()
    {
        return list;
    }

     [HttpGet("{id}")]
    public MyTask Get(int id)
    {
        return list.FirstOrDefault(t => t.Id == id);
    }

    [HttpPost]
    public int Post(MyTask newTask)
    {
        int max = list.Max(t => t.Id);
        newTask.Id = max+1;
        list.Add(newTask);
        return newTask.Id;
    }

     [HttpPut("{id}")]
    public void Put(int id, MyTask newTask)
    {
        if (id == newTask.Id)
        {
            var task = list.Find(t => t.Id == id);
            if (task != null)
            {
                int index = list.IndexOf(task);
                list[index]=newTask;
            }
        }
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        var task = list.Find(t => t.Id == id);
        if (task != null)
        {
            list.Remove(task);
        }
    }

           

}

