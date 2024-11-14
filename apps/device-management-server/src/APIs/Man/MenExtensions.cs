using DeviceManagement.APIs.Dtos;
using DeviceManagement.Infrastructure.Models;

namespace DeviceManagement.APIs.Extensions;

public static class MenExtensions
{
    public static Man ToDto(this ManDbModel model)
    {
        return new Man
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static ManDbModel ToModel(this ManUpdateInput updateDto, ManWhereUniqueInput uniqueId)
    {
        var man = new ManDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            man.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            man.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return man;
    }
}
