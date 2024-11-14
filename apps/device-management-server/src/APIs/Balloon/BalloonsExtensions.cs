using DeviceManagement.APIs.Dtos;
using DeviceManagement.Infrastructure.Models;

namespace DeviceManagement.APIs.Extensions;

public static class BalloonsExtensions
{
    public static Balloon ToDto(this BalloonDbModel model)
    {
        return new Balloon
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static BalloonDbModel ToModel(
        this BalloonUpdateInput updateDto,
        BalloonWhereUniqueInput uniqueId
    )
    {
        var balloon = new BalloonDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            balloon.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            balloon.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return balloon;
    }
}
