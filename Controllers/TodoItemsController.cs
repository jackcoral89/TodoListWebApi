using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using TodoListApp.Migrations;

namespace TodoApi.Controllers
{
    [ApiController]
	public class TodoItemsController : ControllerBase
	{
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

		private readonly ApplicationDBContext _context;

		public TodoItemsController(ApplicationDBContext context)
		{
			_context = context;
		}

		// GET
		[HttpGet("api/todo-items")]
		public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
		{
			return await _context.TodoItems.ToListAsync();
		}

		// GET
		[HttpGet("api/todo-items/{id}")]
		public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
		{
			var todoItem = await _context.TodoItems.FindAsync(id);

			if (todoItem == null)
			{
				return NotFound();
			}

			return todoItem;
		}

		// POST
		[HttpPost("api/todo-items")]
		public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
		{
			_context.TodoItems.Add(todoItem);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
		}

		// PUT
		[HttpPut("api/todo-items/{id}")]
		public async Task<IActionResult> PutTodoItem(long id, TodoItem todoItem)
		{
			if (id != todoItem.Id)
			{
				return BadRequest();
			}

			_context.Entry(todoItem).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!TodoItemExists(id))
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

		// DELETE
		[HttpDelete("api/todo-items/{id}")]
		public async Task<IActionResult> DeleteTodoItem(long id)
		{
			var todoItem = await _context.TodoItems.FindAsync(id);
			if (todoItem == null)
			{
				return NotFound();
			}

			_context.TodoItems.Remove(todoItem);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool TodoItemExists(long id)
		{
			return _context.TodoItems.Any(e => e.Id == id);
		}
	}
}
