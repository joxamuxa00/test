using DeviceManagement.APIs;
using DeviceManagement.APIs.Common;
using DeviceManagement.APIs.Dtos;
using DeviceManagement.APIs.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeviceManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class GirlsControllerBase : ControllerBase
{
    protected readonly IGirlsService _service;

    public GirlsControllerBase(IGirlsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Girl
    /// </summary>
    [HttpPost()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<Girl>> CreateGirl(GirlCreateInput input)
    {
        var girl = await _service.CreateGirl(input);

        return CreatedAtAction(nameof(Girl), new { id = girl.Id }, girl);
    }

    /// <summary>
    /// Delete one Girl
    /// </summary>
    [HttpDelete("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> DeleteGirl([FromRoute()] GirlWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteGirl(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Girls
    /// </summary>
    [HttpGet()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<List<Girl>>> Girls([FromQuery()] GirlFindManyArgs filter)
    {
        return Ok(await _service.Girls(filter));
    }

    /// <summary>
    /// Meta data about Girl records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> GirlsMeta([FromQuery()] GirlFindManyArgs filter)
    {
        return Ok(await _service.GirlsMeta(filter));
    }

    /// <summary>
    /// Get one Girl
    /// </summary>
    [HttpGet("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<Girl>> Girl([FromRoute()] GirlWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Girl(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Girl
    /// </summary>
    [HttpPatch("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> UpdateGirl(
        [FromRoute()] GirlWhereUniqueInput uniqueId,
        [FromQuery()] GirlUpdateInput girlUpdateDto
    )
    {
        try
        {
            await _service.UpdateGirl(uniqueId, girlUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
