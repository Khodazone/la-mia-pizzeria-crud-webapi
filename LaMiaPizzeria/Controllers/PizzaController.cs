using csharp_ef_pizze;
using LaMiaPizzeria.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaMiaPizzeria.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            using (PizzaContext db = new PizzaContext())
            {
                List<Pizza> ourPizze = db.Pizza.ToList();
                return View(ourPizze);
            }


        }

        public IActionResult Details(int id)
        {
            using (PizzaContext db = new PizzaContext())
            {
                Pizza? dettagliPizze = db.Pizza.Where(pizze => pizze.Id == id).FirstOrDefault();

                if (dettagliPizze != null)
                {
                    return View("Details", dettagliPizze);
                }
                else
                {
                    return NotFound($"La pizza con id {id} non è stato trovato!");
                }
            }

        }

        // ACTIONS PER LA CREAZIONE DI UNA PIZZA
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza newPizza)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", newPizza);
            }

            using (PizzaContext db = new PizzaContext())
            {
                db.Pizza.Add(newPizza);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        // ACTIONS PER LA MODIFICA DI UNA PIZZA
        [HttpGet]
        public IActionResult Update(int id)
        {
            using (PizzaContext db = new PizzaContext())
            {
                Pizza? pizzaToModify = db.Pizza.Where(pizza => pizza.Id == id).FirstOrDefault();

                if (pizzaToModify != null)
                {
                    return View("Update", pizzaToModify);
                }
                else
                {

                    return NotFound("Pizza da modifcare inesistente!");
                }
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Pizza modifiedPizza)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", modifiedPizza);
            }

            using (PizzaContext db = new PizzaContext())
            {
                Pizza? pizzaToModify = db.Pizza.Where(article => article.Id == id).FirstOrDefault();

                if (pizzaToModify != null)
                {

                    pizzaToModify.Title = modifiedPizza.Title;
                    pizzaToModify.Description = modifiedPizza.Description;
                    pizzaToModify.Price = modifiedPizza.Price;
                    pizzaToModify.Image = modifiedPizza.Image;

                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                else
                {
                    return NotFound("La pizza da modificare non esiste!");
                }
            }

        }

        // ACTION PER ELIMINARE UNA PIZZA
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            using (PizzaContext db = new PizzaContext())
            {
                Pizza? pizzaToDelete = db.Pizza.Where(pizza => pizza.Id == id).FirstOrDefault();

                if (pizzaToDelete != null)
                {
                    db.Remove(pizzaToDelete);
                    db.SaveChanges();

                    return RedirectToAction("Index");

                }
                else
                {
                    return NotFound("Non ho trovato la pizza da eliminare");

                }
            }
        }

    }
}

