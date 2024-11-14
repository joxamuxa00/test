using DeviceManagement.Infrastructure;

namespace DeviceManagement.APIs;

public class MenService : MenServiceBase
{
    public MenService(DeviceManagementDbContext context)
        : base(context) { }
}
