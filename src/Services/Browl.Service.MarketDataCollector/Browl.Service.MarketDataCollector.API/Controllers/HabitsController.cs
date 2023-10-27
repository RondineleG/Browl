using AutoMapper;

using Browl.Service.MarketDataCollector.Domain.Interfaces.Services;
using Browl.Service.MarketDataCollector.Domain.Resources.Habit;

using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Browl.Service.MarketDataCollector.API.Controllers;


[ApiController]
[Route("api/[controller]")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class HabitsController : ControllerBase
{
	private readonly ILogger<HabitsController> _logger;
	private readonly IHabitService _habitService;
	private readonly IMapper _mapper;
	public HabitsController(ILogger<HabitsController> logger, IHabitService habitService, IMapper mapper)
	{
		_logger = logger;
		_habitService = habitService;
		_mapper = mapper;
	}


	[MapToApiVersion("1.0")]
	[HttpGet("version")]
	public virtual IActionResult GetVersion() => Ok("Response from version 1.0");

	[HttpGet("{id}")]
	public async Task<IActionResult> GetAsync(int id) => 
		Ok(_mapper.Map<HabitResource>(await _habitService.GetById(id)));


	/// <summary>
	/// Lists all habits.
	/// </summary>
	/// <returns>List os habits.</returns>
	[HttpGet]
	public async Task<IActionResult> GetAsync() => Ok(_mapper.Map<ICollection<HabitResource>>(await _habitService.GetAll()));

	[HttpPost]
	public async Task<IActionResult> CreateAsync(CreateHabitResource request)
	{
		var habit = await _habitService.Create(request.Name, request.Description);
		var habitDto = _mapper.Map<HabitResource>(habit);
		return CreatedAtAction("Get", "Habits", new
		{
			id =
		  habitDto.Id
		}, habitDto);
	}


	[HttpPut("{id}")]
	public async Task<IActionResult> UpdateAsync(int id, UpdateHabitResource request)
	{
		var habit = await _habitService.UpdateById(id, request);
		return habit == null ? NotFound() : Ok(habit);
	}

	[HttpPatch("{id}")]
	public async Task<IActionResult> UpdateAsync(int id, [FromBody] JsonPatchDocument<UpdateHabitResource> patch)
	{
		var habit = await _habitService.GetById(id);
		if (habit == null)
		{
			return NotFound();
		}

		UpdateHabitResource updateHabitDto = new()
		{
			Name = habit.Name,
			Description = habit.Description
		};
		try
		{
			patch.ApplyTo(updateHabitDto, ModelState);
			if (!TryValidateModel(updateHabitDto))
			{
				return
			  ValidationProblem(ModelState);
			}

			_ = await _habitService.UpdateById(id, updateHabitDto);
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
