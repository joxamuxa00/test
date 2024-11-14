using Microsoft.AspNetCore.Mvc;

namespace DeviceManagement.APIs;

[ApiController()]
public class PhonesController : PhonesControllerBase
{
    public PhonesController(IPhonesService service)
        : base(service) { }
}
