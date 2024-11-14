using Microsoft.AspNetCore.Mvc;

namespace DeviceManagement.APIs;

[ApiController()]
public class GirlsController : GirlsControllerBase
{
    public GirlsController(IGirlsService service)
        : base(service) { }
}
