using AutoMapper;
using EmployeeData.Dto;
using EmployeeData.Models;
using EmployeeData.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly IProjectService _projectService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly AppDbContext _dbContext;
        public TaskController(ITaskService taskService, IProjectService projectService, IUserService userService, IMapper mapper, AppDbContext dbContext)
        {
            _taskService = taskService;
            _projectService = projectService;
            _userService = userService;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        [HttpGet]
	public async Task<ActionResult<IEnumerable<Task>>> GetTasks()
    {
        return await _context.Tasks.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Task>> GetTask(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null)
        {
            return NotFound();
        }
        return task;
    }


        [HttpPost]
    public async Task<ActionResult<Task>> CreateTask(Task task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
    }


        [HttpPut("{taskId}")]
public async Task<IActionResult> UpdateTask(int id, Task task)
    {
        if (id != task.Id)
        {
            return BadRequest();
        }

        _context.Entry(task).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TaskExists(id))
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


        [HttpDelete("{taskId}")]
     public async Task<IActionResult> DeleteTask(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null)
        {
            return NotFound();
        }

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TaskExists(int id)
    {
        return _context.Tasks.Any(e => e.Id == id);
    }
}

    } 
}
