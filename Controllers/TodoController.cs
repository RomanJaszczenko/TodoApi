using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Dtos;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext _context;
        private readonly IMapper _mapper;

        public TodoController(TodoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemDto>>> GetAll()
        {
            var items = await _context.TodoItems.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<TodoItemDto>>(items));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemDto>> Get(int id)
        {
            var item = await _context.TodoItems.FindAsync(id);
            return item == null ? NotFound() : Ok(_mapper.Map<TodoItemDto>(item));
        }

        [HttpPost]
        public async Task<ActionResult<TodoItemDto>> Create(CreateTodoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var item = _mapper.Map<TodoItem>(dto);
            _context.TodoItems.Add(item);
            await _context.SaveChangesAsync();

            var resultDto = _mapper.Map<TodoItemDto>(item);
            return CreatedAtAction(nameof(Get), new { id = resultDto.Id }, resultDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTodoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var item = await _context.TodoItems.FindAsync(id);
            if (item == null) return NotFound();

            _mapper.Map(dto, item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.TodoItems.FindAsync(id);
            if (item == null) return NotFound();

            _context.TodoItems.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
