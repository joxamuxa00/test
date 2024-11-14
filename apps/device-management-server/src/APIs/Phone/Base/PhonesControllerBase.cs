using DeviceManagement.APIs;
using DeviceManagement.APIs.Common;
using DeviceManagement.APIs.Dtos;
using DeviceManagement.APIs.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeviceManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class PhonesControllerBase : ControllerBase
{
    protected readonly IPhonesService _service;

    public PhonesControllerBase(IPhonesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Phone
    /// </summary>
    [HttpPost()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<Phone>> CreatePhone(PhoneCreateInput input)
    {
        var phone = await _service.CreatePhone(input);

        return CreatedAtAction(nameof(Phone), new { id = phone.Id }, phone);
    }

    /// <summary>
    /// Delete one Phone
    /// </summary>
    [HttpDelete("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> DeletePhone([FromRoute()] PhoneWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeletePhone(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Phones
    /// </summary>
    [HttpGet()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<List<Phone>>> Phones([FromQuery()] PhoneFindManyArgs filter)
    {
        return Ok(await _service.Phones(filter));
    }

    /// <summary>
    /// Meta data about Phone records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> PhonesMeta([FromQuery()] PhoneFindManyArgs filter)
    {
        return Ok(await _service.PhonesMeta(filter));
    }

    /// <summary>
    /// Get one Phone
    /// </summary>
    [HttpGet("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<Phone>> Phone([FromRoute()] PhoneWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Phone(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Phone
    /// </summary>
    [HttpPatch("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> UpdatePhone(
        [FromRoute()] PhoneWhereUniqueInput uniqueId,
        [FromQuery()] PhoneUpdateInput phoneUpdateDto
    )
    {
        try
        {
            await _service.UpdatePhone(uniqueId, phoneUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
