using Microsoft.AspNetCore.Mvc;
using TaskApi.Models;

namespace TaskApi.Controllers;

[ApiController]
[Route("tasks")]
public class TasksController : ControllerBase
{
    // In-memory storage for tasks (replace with DB later)
    private static List<TaskItem> tasks = new();
    private static int nextId = 1; // auto-increment ID

    // GET /tasks
    [HttpGet]
    public IActionResult GetTasks()
    {
        return Ok(tasks); // return all tasks
    }

    // GET /tasks/{id}
    [HttpGet("{id}")]
    public IActionResult GetTask(int id)
    {
        var task = tasks.FirstOrDefault(t => t.Id == id);
        if (task == null) return NotFound();
        return Ok(task);
    }

    // POST /tasks
    [HttpPost]
    public IActionResult CreateTask([FromBody] TaskItem task)
    {
        task.Id = nextId++;
        tasks.Add(task);
        return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
    }

    // PUT /tasks/{id}
    [HttpPut("{id}")]
    public IActionResult UpdateTask(int id, [FromBody] TaskItem updatedTask)
    {
        var task = tasks.FirstOrDefault(t => t.Id == id);
        if (task == null) return NotFound();

        task.Title = updatedTask.Title;
        task.Description = updatedTask.Description;
        task.IsDone = updatedTask.IsDone;

        return Ok(task);
    }

    // DELETE /tasks/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteTask(int id)
    {
        var task = tasks.FirstOrDefault(t => t.Id == id);
        if (task == null) return NotFound();

        tasks.Remove(task);
        return NoContent();
    }
}