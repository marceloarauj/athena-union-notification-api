using Microsoft.AspNetCore.Mvc;

namespace Notification.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] string id)
        {
            return Ok(new { status = "Sucesso: " + id });
        }
    }
}
