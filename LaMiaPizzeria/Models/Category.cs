using csharp_ef_pizze;

namespace LaMiaPizzeria.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Pizza> Pizzas { get; set; }
    }
}
