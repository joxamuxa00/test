using DeviceManagement.APIs;
using DeviceManagement.APIs.Common;
using DeviceManagement.APIs.Dtos;
using DeviceManagement.APIs.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeviceManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class MenControllerBase : ControllerBase
{
    protected readonly IMenService _service;

    public MenControllerBase(IMenService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Man
    /// </summary>
    [HttpPost()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<Man>> CreateMan(ManCreateInput input)
    {
        var man = await _service.CreateMan(input);

        return CreatedAtAction(nameof(Man), new { id = man.Id }, man);
    }

    /// <summary>
    /// Delete one Man
    /// </summary>
    [HttpDelete("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> DeleteMan([FromRoute()] ManWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteMan(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Men
    /// </summary>
    [HttpGet()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<List<Man>>> Men([FromQuery()] ManFindManyArgs filter)
    {
        return Ok(await _service.Men(filter));
    }

    /// <summary>
    /// Meta data about Man records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> MenMeta([FromQuery()] ManFindManyArgs filter)
    {
        return Ok(await _service.MenMeta(filter));
    }

    /// <summary>
    /// Get one Man
    /// </summary>
    [HttpGet("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<Man>> Man([FromRoute()] ManWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Man(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Man
    /// </summary>
    [HttpPatch("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> UpdateMan(
        [FromRoute()] ManWhereUniqueInput uniqueId,
        [FromQuery()] ManUpdateInput manUpdateDto
    )
    {
        try
        {
            await _service.UpdateMan(uniqueId, manUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
