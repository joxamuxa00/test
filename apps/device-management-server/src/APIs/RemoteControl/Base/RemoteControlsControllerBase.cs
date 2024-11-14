using DeviceManagement.APIs;
using DeviceManagement.APIs.Common;
using DeviceManagement.APIs.Dtos;
using DeviceManagement.APIs.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeviceManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class RemoteControlsControllerBase : ControllerBase
{
    protected readonly IRemoteControlsService _service;

    public RemoteControlsControllerBase(IRemoteControlsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one RemoteControl
    /// </summary>
    [HttpPost()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<RemoteControl>> CreateRemoteControl(
        RemoteControlCreateInput input
    )
    {
        var remoteControl = await _service.CreateRemoteControl(input);

        return CreatedAtAction(nameof(RemoteControl), new { id = remoteControl.Id }, remoteControl);
    }

    /// <summary>
    /// Delete one RemoteControl
    /// </summary>
    [HttpDelete("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> DeleteRemoteControl(
        [FromRoute()] RemoteControlWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteRemoteControl(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many RemoteControls
    /// </summary>
    [HttpGet()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<List<RemoteControl>>> RemoteControls(
        [FromQuery()] RemoteControlFindManyArgs filter
    )
    {
        return Ok(await _service.RemoteControls(filter));
    }

    /// <summary>
    /// Meta data about RemoteControl records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> RemoteControlsMeta(
        [FromQuery()] RemoteControlFindManyArgs filter
    )
    {
        return Ok(await _service.RemoteControlsMeta(filter));
    }

    /// <summary>
    /// Get one RemoteControl
    /// </summary>
    [HttpGet("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<RemoteControl>> RemoteControl(
        [FromRoute()] RemoteControlWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.RemoteControl(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one RemoteControl
    /// </summary>
    [HttpPatch("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> UpdateRemoteControl(
        [FromRoute()] RemoteControlWhereUniqueInput uniqueId,
        [FromQuery()] RemoteControlUpdateInput remoteControlUpdateDto
    )
    {
        try
        {
            await _service.UpdateRemoteControl(uniqueId, remoteControlUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
