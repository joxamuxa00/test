using DeviceManagement.Infrastructure;

namespace DeviceManagement.APIs;

public class PhonesService : PhonesServiceBase
{
    public PhonesService(DeviceManagementDbContext context)
        : base(context) { }
}
