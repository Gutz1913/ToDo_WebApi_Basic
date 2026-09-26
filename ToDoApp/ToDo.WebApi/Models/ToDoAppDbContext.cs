using Microsoft.EntityFrameworkCore;

namespace ToDo.WebApi.Models;

public class ToDoAppDbContext : DbContext
{
    public ToDoAppDbContext(DbContextOptions<ToDoAppDbContext> options) : base(options)
    {       
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<ToDoItem> ToDoItems => Set<ToDoItem>();
}
