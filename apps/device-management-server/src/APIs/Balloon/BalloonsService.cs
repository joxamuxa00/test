using DeviceManagement.Infrastructure;

namespace DeviceManagement.APIs;

public class BalloonsService : BalloonsServiceBase
{
    public BalloonsService(DeviceManagementDbContext context)
        : base(context) { }
}
