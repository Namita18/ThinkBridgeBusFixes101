using Microsoft.AspNetCore.Mvc;

namespace ThinkBridgeASP.netproject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetData()
        {
            string result = "test"; // safe

            if (!string.IsNullOrEmpty(result))
            {
                return Ok(new { message = "Data fetched" });
            }

            return BadRequest("No data");
        }
    }
}
