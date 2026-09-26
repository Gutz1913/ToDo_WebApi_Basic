using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo.WebApi.Models;

[Route("api/[controller]")]
[ApiController]
public class ToDoItemsController : ControllerBase
{
    private readonly ToDoAppDbContext _context;
    public ToDoItemsController(ToDoAppDbContext context)
    {
        _context = context;
    }

    // GET: api/ToDoItem
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ToDoItem>>> GetToDoItem()
    {
        return await _context.ToDoItems.ToListAsync();
    }

    // GET: api/ToDoItem/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ToDoItem>> GetToDoItem(int id)
    {
        var todoitem = await _context.ToDoItems.FindAsync(id);

        if (todoitem == null)
        {
            return NotFound();
        }

        return todoitem;
    }

    // PUT: api/ToDoItem/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutToDoItem(int? id, ToDoItem todoitem)
    {
        if (id != todoitem.Id)
        {
            return BadRequest();
        }

        _context.Entry(todoitem).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ToDoItemExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/ToDoItem
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<ToDoItem>> PostToDoItem(ToDoItem todoitem)
    {
        _context.ToDoItems.Add(todoitem);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetToDoItem", new { id = todoitem.Id }, todoitem);
    }

    // DELETE: api/ToDoItem/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteToDoItem(int? id)
    {
        var todoitem = await _context.ToDoItems.FindAsync(id);
        if (todoitem == null)
        {
            return NotFound();
        }

        _context.ToDoItems.Remove(todoitem);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ToDoItemExists(int? id)
    {
        return _context.ToDoItems.Any(e => e.Id == id);
    }
}
