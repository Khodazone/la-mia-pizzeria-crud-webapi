using csharp_ef_pizze;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaMiaPizzeria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaAPIController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPizza()
        {
            using (PizzaContext db = new PizzaContext())
            {
                List<Pizza> list = db.Pizza.ToList();
                return Ok(list);
            }
        }
    }
}
