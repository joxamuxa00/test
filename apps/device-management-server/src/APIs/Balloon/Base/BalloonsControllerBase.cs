using DeviceManagement.APIs;
using DeviceManagement.APIs.Common;
using DeviceManagement.APIs.Dtos;
using DeviceManagement.APIs.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeviceManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class BalloonsControllerBase : ControllerBase
{
    protected readonly IBalloonsService _service;

    public BalloonsControllerBase(IBalloonsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Balloon
    /// </summary>
    [HttpPost()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<Balloon>> CreateBalloon(BalloonCreateInput input)
    {
        var balloon = await _service.CreateBalloon(input);

        return CreatedAtAction(nameof(Balloon), new { id = balloon.Id }, balloon);
    }

    /// <summary>
    /// Delete one Balloon
    /// </summary>
    [HttpDelete("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> DeleteBalloon([FromRoute()] BalloonWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteBalloon(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Balloons
    /// </summary>
    [HttpGet()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<List<Balloon>>> Balloons(
        [FromQuery()] BalloonFindManyArgs filter
    )
    {
        return Ok(await _service.Balloons(filter));
    }

    /// <summary>
    /// Meta data about Balloon records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> BalloonsMeta(
        [FromQuery()] BalloonFindManyArgs filter
    )
    {
        return Ok(await _service.BalloonsMeta(filter));
    }

    /// <summary>
    /// Get one Balloon
    /// </summary>
    [HttpGet("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<Balloon>> Balloon([FromRoute()] BalloonWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Balloon(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Balloon
    /// </summary>
    [HttpPatch("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> UpdateBalloon(
        [FromRoute()] BalloonWhereUniqueInput uniqueId,
        [FromQuery()] BalloonUpdateInput balloonUpdateDto
    )
    {
        try
        {
            await _service.UpdateBalloon(uniqueId, balloonUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
