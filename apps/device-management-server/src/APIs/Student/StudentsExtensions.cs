using DeviceManagement.APIs.Dtos;
using DeviceManagement.Infrastructure.Models;

namespace DeviceManagement.APIs.Extensions;

public static class StudentsExtensions
{
    public static Student ToDto(this StudentDbModel model)
    {
        return new Student
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static StudentDbModel ToModel(
        this StudentUpdateInput updateDto,
        StudentWhereUniqueInput uniqueId
    )
    {
        var student = new StudentDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            student.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            student.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return student;
    }
}
