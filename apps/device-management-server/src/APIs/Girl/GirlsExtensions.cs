using DeviceManagement.APIs.Dtos;
using DeviceManagement.Infrastructure.Models;

namespace DeviceManagement.APIs.Extensions;

public static class GirlsExtensions
{
    public static Girl ToDto(this GirlDbModel model)
    {
        return new Girl
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static GirlDbModel ToModel(this GirlUpdateInput updateDto, GirlWhereUniqueInput uniqueId)
    {
        var girl = new GirlDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            girl.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            girl.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return girl;
    }
}
