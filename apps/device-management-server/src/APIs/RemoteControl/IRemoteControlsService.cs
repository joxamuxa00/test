using DeviceManagement.APIs.Common;
using DeviceManagement.APIs.Dtos;

namespace DeviceManagement.APIs;

public interface IRemoteControlsService
{
    /// <summary>
    /// Create one RemoteControl
    /// </summary>
    public Task<RemoteControl> CreateRemoteControl(RemoteControlCreateInput remotecontrol);

    /// <summary>
    /// Delete one RemoteControl
    /// </summary>
    public Task DeleteRemoteControl(RemoteControlWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many RemoteControls
    /// </summary>
    public Task<List<RemoteControl>> RemoteControls(RemoteControlFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about RemoteControl records
    /// </summary>
    public Task<MetadataDto> RemoteControlsMeta(RemoteControlFindManyArgs findManyArgs);

    /// <summary>
    /// Get one RemoteControl
    /// </summary>
    public Task<RemoteControl> RemoteControl(RemoteControlWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one RemoteControl
    /// </summary>
    public Task UpdateRemoteControl(
        RemoteControlWhereUniqueInput uniqueId,
        RemoteControlUpdateInput updateDto
    );
}
