using CrudNetRazor.Datos;
using CrudNetRazor.Modelos;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudNetRazor.Pages.Productos
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _contacto;

        public IndexModel(ApplicationDbContext contacto)
        {
            _contacto = contacto;
        }

        public IEnumerable<Producto> Productos { get; set; }

        public async Task OnGetAsync()
        {
            Productos = await _contacto.Productos.ToListAsync();
        }
    }
}
