using Microsoft.AspNetCore.Mvc;

namespace DeviceManagement.APIs;

[ApiController()]
public class MenController : MenControllerBase
{
    public MenController(IMenService service)
        : base(service) { }
}
