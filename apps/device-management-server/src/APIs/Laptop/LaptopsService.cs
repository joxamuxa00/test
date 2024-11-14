using DeviceManagement.Infrastructure;

namespace DeviceManagement.APIs;

public class LaptopsService : LaptopsServiceBase
{
    public LaptopsService(DeviceManagementDbContext context)
        : base(context) { }
}
