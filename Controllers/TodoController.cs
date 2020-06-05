using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    [ApiController]
    [Route("todo")]
    public class TodoController : ControllerBase
    {
        private ApiContext _context;
        public TodoController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<TodoItem> Get()
        {
            return _context.TodoItems.Select(x => x);
        }

        [HttpPost]
        public IActionResult Add(TodoItem todoItem)
        {
            if (String.IsNullOrEmpty(todoItem.Name))
                return BadRequest();

            var added = _context.TodoItems.Add(todoItem);
            _context.SaveChanges();
            return Ok(todoItem);
        }
    }
}
