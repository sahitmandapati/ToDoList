using Microsoft.AspNetCore.Mvc;
using ToDoList;
using ToDoList.Services;

namespace TodoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly TodoItemService todoItemService;

        public TodoItemsController(TodoItemService todoItemService)
        {
            this.todoItemService = todoItemService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>> GetAll([FromQuery] Category? category = null)
        {
            return Ok(todoItemService.GetAll());
        }

        
        [HttpGet("{id:Guid}")]
        public ActionResult<TodoItem> GetById(Guid id)
        {
            try
            {
                var item = todoItemService.FindById(id);
                if (item == null)
                {
                    return NotFound();
                }
                return Ok(item);

            }
            catch (InvalidOperationException e)
            {
                return Problem(e.Message);
            }
        }

        
        [HttpPost]
        public ActionResult<TodoItem> Create([FromBody] TodoItem item)
        {
            var added = todoItemService.Add(item);
            return CreatedAtAction(nameof(GetById), new { id = added.Id }, added);
        }

        [HttpPut("{id:Guid}")]
        public IActionResult Update(Guid id, [FromBody] TodoItem updatedItem)
        {
            try
            {
                var item = todoItemService.Update(id, updatedItem);
                if (item == null)
                {
                    return NotFound();
                }
                return Ok(item);
            }
            catch (InvalidOperationException e)
            {
                return Problem(e.Message);
            }
        }


        [HttpDelete("{id:Guid}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var item = todoItemService.Remove(id);
                if (item is null)
                {
                    return NotFound();
                }
                return Ok(item);
            }
            catch (InvalidOperationException e)
            {
                return Problem(e.Message);
            }
        }
    }
}
