using DeviceManagement.APIs;
using DeviceManagement.APIs.Common;
using DeviceManagement.APIs.Dtos;
using DeviceManagement.APIs.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeviceManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class StudentsControllerBase : ControllerBase
{
    protected readonly IStudentsService _service;

    public StudentsControllerBase(IStudentsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Student
    /// </summary>
    [HttpPost()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<Student>> CreateStudent(StudentCreateInput input)
    {
        var student = await _service.CreateStudent(input);

        return CreatedAtAction(nameof(Student), new { id = student.Id }, student);
    }

    /// <summary>
    /// Delete one Student
    /// </summary>
    [HttpDelete("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> DeleteStudent([FromRoute()] StudentWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteStudent(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Students
    /// </summary>
    [HttpGet()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<List<Student>>> Students(
        [FromQuery()] StudentFindManyArgs filter
    )
    {
        return Ok(await _service.Students(filter));
    }

    /// <summary>
    /// Meta data about Student records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> StudentsMeta(
        [FromQuery()] StudentFindManyArgs filter
    )
    {
        return Ok(await _service.StudentsMeta(filter));
    }

    /// <summary>
    /// Get one Student
    /// </summary>
    [HttpGet("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<Student>> Student([FromRoute()] StudentWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Student(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Student
    /// </summary>
    [HttpPatch("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> UpdateStudent(
        [FromRoute()] StudentWhereUniqueInput uniqueId,
        [FromQuery()] StudentUpdateInput studentUpdateDto
    )
    {
        try
        {
            await _service.UpdateStudent(uniqueId, studentUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
