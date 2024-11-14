using DeviceManagement.Infrastructure;

namespace DeviceManagement.APIs;

public class GirlsService : GirlsServiceBase
{
    public GirlsService(DeviceManagementDbContext context)
        : base(context) { }
}
