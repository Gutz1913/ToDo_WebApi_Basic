namespace ToDo.WebApi.Models;

public class ToDoItem
{
    public int Id { get; set; }
    public string Task { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = null!;
}
