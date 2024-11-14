using DeviceManagement.APIs.Dtos;
using DeviceManagement.Infrastructure.Models;

namespace DeviceManagement.APIs.Extensions;

public static class RemoteControlsExtensions
{
    public static RemoteControl ToDto(this RemoteControlDbModel model)
    {
        return new RemoteControl
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static RemoteControlDbModel ToModel(
        this RemoteControlUpdateInput updateDto,
        RemoteControlWhereUniqueInput uniqueId
    )
    {
        var remoteControl = new RemoteControlDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            remoteControl.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            remoteControl.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return remoteControl;
    }
}
