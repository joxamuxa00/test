using Microsoft.AspNetCore.Mvc;

namespace DeviceManagement.APIs;

[ApiController()]
public class RemoteControlsController : RemoteControlsControllerBase
{
    public RemoteControlsController(IRemoteControlsService service)
        : base(service) { }
}
