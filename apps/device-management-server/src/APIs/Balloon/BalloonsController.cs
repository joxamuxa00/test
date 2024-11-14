using Microsoft.AspNetCore.Mvc;

namespace DeviceManagement.APIs;

[ApiController()]
public class BalloonsController : BalloonsControllerBase
{
    public BalloonsController(IBalloonsService service)
        : base(service) { }
}
