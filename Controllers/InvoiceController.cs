using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ThinkBridgeASP.netproject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetInvoice()
        {
            var items = new List<Item>
            {
                new Item { Name = "Pen", Price = 10 },
                new Item { Name = "Notebook", Price = 50 }
            };

            return Ok(new { items });
        }
    }

    public class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
