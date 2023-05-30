using csharp_ef_pizze;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaMiaPizzeria.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PizzaAPIController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPizzas()
        {
            using (PizzaContext db = new PizzaContext())
            {
                List<Pizza> list = db.Pizza.ToList();
                return Ok(list);
            }
        }
    }

    [HttpGet("{keyWord}")]
    public IActionResult GetPizzasByKeyword(string keyWord)
    {
        using (PizzaContext db = new())
        {
            List<Pizza> pizzaByKeyword = db.Pizza.Where(pizza => pizza.Title.Contains(keyWord)).ToList();
            if (pizzaByKeyword != null)
            {
                return Ok(pizzaByKeyword);
            }
            else
            {
                return NotFound();
            }
        }
    }

    [HttpGet("{id}")]
    public IActionResult SearchById(int id)
    {
        using (PizzaContext db = new PizzaContext())
        {
            Pizza? pizzaId = db.Pizza.Where(pizza => pizza.Id == id).FirstOrDefault();
            if (pizzaId != null)
            {

                return Ok(pizzaId);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
