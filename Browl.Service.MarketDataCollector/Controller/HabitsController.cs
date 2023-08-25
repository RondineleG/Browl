using AutoMapper;
using Browl.Core.Dtos.Habit;
using Browl.Core.Interfaces.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Browl.Service.MarketDataCollector.Controller;


[ApiController]
[Route("api/[controller]")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class HabitsController : ControllerBase
{
    private readonly ILogger<HabitsController> _logger;
    private readonly IHabitService _habitService;
    private IMapper _mapper;
    public HabitsController(ILogger<HabitsController> logger, IHabitService habitService, IMapper mapper)
    {
        _logger = logger;
        _habitService = habitService;
        _mapper = mapper;
    }


    [MapToApiVersion("1.0")]
    [HttpGet("version")]
    public virtual async Task<IActionResult> GetVersion()
    {
        return Ok("Response from version 1.0");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(int id)
    {
        return Ok(_mapper.Map<HabitDto>(await _habitService.GetById(id)));
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(_mapper.Map<ICollection<HabitDto>>(await _habitService.GetAll()));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateHabitDto request)
    {
        var habit = await _habitService.Create(request.Name, request.Description);
        var habitDto = _mapper.Map<HabitDto>(habit);
        return CreatedAtAction("Get", "Habits", new
        {
            id =
          habitDto.Id
        }, habitDto);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, UpdateHabitDto request)
    {
        var habit = await _habitService.UpdateById(id, request);
        if (habit == null) return NotFound();
        return Ok(habit);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] JsonPatchDocument<UpdateHabitDto> patch)
    {
        var habit = await _habitService.GetById(id);
        if (habit == null) return NotFound();
        var updateHabitDto = new UpdateHabitDto
        {
            Name = habit.Name,
            Description = habit.Description
        };
        try
        {
            patch.ApplyTo(updateHabitDto, ModelState);
            if (!TryValidateModel(updateHabitDto)) return
              ValidationProblem(ModelState);
            await _habitService.UpdateById(id, updateHabitDto);
            return NoContent();
        }
        catch (JsonPatchException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _habitService.DeleteById(id);
        return NoContent();
    }
}