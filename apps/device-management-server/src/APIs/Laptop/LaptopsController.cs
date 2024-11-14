using Microsoft.AspNetCore.Mvc;

namespace DeviceManagement.APIs;

[ApiController()]
public class LaptopsController : LaptopsControllerBase
{
    public LaptopsController(ILaptopsService service)
        : base(service) { }
}
