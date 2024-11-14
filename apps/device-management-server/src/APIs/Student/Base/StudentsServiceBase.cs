using DeviceManagement.APIs;
using DeviceManagement.APIs.Common;
using DeviceManagement.APIs.Dtos;
using DeviceManagement.APIs.Errors;
using DeviceManagement.APIs.Extensions;
using DeviceManagement.Infrastructure;
using DeviceManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace DeviceManagement.APIs;

public abstract class StudentsServiceBase : IStudentsService
{
    protected readonly DeviceManagementDbContext _context;

    public StudentsServiceBase(DeviceManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Student
    /// </summary>
    public async Task<Student> CreateStudent(StudentCreateInput createDto)
    {
        var student = new StudentDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            student.Id = createDto.Id;
        }

        _context.Students.Add(student);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<StudentDbModel>(student.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Student
    /// </summary>
    public async Task DeleteStudent(StudentWhereUniqueInput uniqueId)
    {
        var student = await _context.Students.FindAsync(uniqueId.Id);
        if (student == null)
        {
            throw new NotFoundException();
        }

        _context.Students.Remove(student);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Students
    /// </summary>
    public async Task<List<Student>> Students(StudentFindManyArgs findManyArgs)
    {
        var students = await _context
            .Students.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return students.ConvertAll(student => student.ToDto());
    }

    /// <summary>
    /// Meta data about Student records
    /// </summary>
    public async Task<MetadataDto> StudentsMeta(StudentFindManyArgs findManyArgs)
    {
        var count = await _context.Students.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Student
    /// </summary>
    public async Task<Student> Student(StudentWhereUniqueInput uniqueId)
    {
        var students = await this.Students(
            new StudentFindManyArgs { Where = new StudentWhereInput { Id = uniqueId.Id } }
        );
        var student = students.FirstOrDefault();
        if (student == null)
        {
            throw new NotFoundException();
        }

        return student;
    }

    /// <summary>
    /// Update one Student
    /// </summary>
    public async Task UpdateStudent(StudentWhereUniqueInput uniqueId, StudentUpdateInput updateDto)
    {
        var student = updateDto.ToModel(uniqueId);

        _context.Entry(student).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Students.Any(e => e.Id == student.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
