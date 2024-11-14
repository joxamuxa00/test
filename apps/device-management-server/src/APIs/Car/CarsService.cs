using DeviceManagement.Infrastructure;

namespace DeviceManagement.APIs;

public class CarsService : CarsServiceBase
{
    public CarsService(DeviceManagementDbContext context)
        : base(context) { }
}
