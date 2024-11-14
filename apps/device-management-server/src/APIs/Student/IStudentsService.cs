using DeviceManagement.APIs.Common;
using DeviceManagement.APIs.Dtos;

namespace DeviceManagement.APIs;

public interface IStudentsService
{
    /// <summary>
    /// Create one Student
    /// </summary>
    public Task<Student> CreateStudent(StudentCreateInput student);

    /// <summary>
    /// Delete one Student
    /// </summary>
    public Task DeleteStudent(StudentWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Students
    /// </summary>
    public Task<List<Student>> Students(StudentFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Student records
    /// </summary>
    public Task<MetadataDto> StudentsMeta(StudentFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Student
    /// </summary>
    public Task<Student> Student(StudentWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Student
    /// </summary>
    public Task UpdateStudent(StudentWhereUniqueInput uniqueId, StudentUpdateInput updateDto);
}
