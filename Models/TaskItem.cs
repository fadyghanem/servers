namespace TaskApi.Models;

// This is the data structure for each task
public class TaskItem
{
    public int Id { get; set; }          // unique identifier
    public string Title { get; set; }    // task title
    public string Description { get; set; } // optional description
    public bool IsDone { get; set; }     // completed or not
}