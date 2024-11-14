using DeviceManagement.Infrastructure;

namespace DeviceManagement.APIs;

public class RemoteControlsService : RemoteControlsServiceBase
{
    public RemoteControlsService(DeviceManagementDbContext context)
        : base(context) { }
}
