using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Composition;
using LaMiaPizzeria.Models;

namespace csharp_ef_pizze
{
    public class PizzaContext : IdentityDbContext<IdentityUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=EfPizze;" +
                "Integrated Security=True;TrustServerCertificate=True");
        }

        public DbSet<Pizza> Pizza { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
