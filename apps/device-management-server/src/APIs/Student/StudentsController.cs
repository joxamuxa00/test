using Microsoft.AspNetCore.Mvc;

namespace DeviceManagement.APIs;

[ApiController()]
public class StudentsController : StudentsControllerBase
{
    public StudentsController(IStudentsService service)
        : base(service) { }
}
