using DeviceManagement.Infrastructure;

namespace DeviceManagement.APIs;

public class StudentsService : StudentsServiceBase
{
    public StudentsService(DeviceManagementDbContext context)
        : base(context) { }
}
