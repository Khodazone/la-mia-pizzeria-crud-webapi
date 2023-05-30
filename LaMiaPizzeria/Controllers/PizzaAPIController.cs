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

        [HttpGet("{keyWord}")]
        public IActionResult GetPizzaByKeyword(string keyWord)
        {
            using (PizzaContext db = new PizzaContext())
            {
                List<Pizza> pizzaByKeyword = db.Pizza.Where(pizza => pizza.Title.Contains(keyWord)).ToList();
                if (pizzaByKeyword == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(pizzaByKeyword);
                }
            }
        }

        [HttpGet("{id}")]
        public IActionResult SearchById(int id)
        {
            using (PizzaContext db = new PizzaContext())
            {
                Pizza? pizzaId = db.Pizza.Where(pizza => pizza.Id == id).FirstOrDefault();
                if (pizzaId == null)
                {

                    return NotFound();
                }
                else
                {
                    return Ok(pizzaId);
                }
            }
        }
    }
}
