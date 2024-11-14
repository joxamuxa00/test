using Microsoft.AspNetCore.Mvc;

namespace DeviceManagement.APIs;

[ApiController()]
public class CarsController : CarsControllerBase
{
    public CarsController(ICarsService service)
        : base(service) { }
}
