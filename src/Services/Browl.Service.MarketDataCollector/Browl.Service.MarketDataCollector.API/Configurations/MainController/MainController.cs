using Microsoft.AspNetCore.Mvc;

namespace Browl.Service.MarketDataCollector.API.Configurations.BaseApiController
{
    [Route("/api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public abstract class MainController : ControllerBase
    {
    }
}