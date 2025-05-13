using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static List<string> products = new List<string> { "Pizza", "Burger" };

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(products);
        }

        [HttpPost("AddNewProduct")]
        public IActionResult Add([FromBody] string name)
        {
            products.Add(name);
            return Ok(products);
        }

        [HttpDelete("DeleteProductById")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= products.Count)
                return NotFound("Invalid index");

            products.RemoveAt(id);
            return Ok(products);
        }
    }
}
