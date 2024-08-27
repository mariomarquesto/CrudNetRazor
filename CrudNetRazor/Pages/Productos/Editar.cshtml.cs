using CrudNetRazor.Datos;
using CrudNetRazor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace CrudNetRazor.Pages.Productos
{
    public class EditarModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditarModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Producto Producto { get; set; }

        // Maneja la solicitud GET para mostrar el formulario de edici�n
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Producto = await _context.Productos.FindAsync(id);

            if (Producto == null)
            {
                return NotFound();
            }

            return Page();
        }

        // Maneja la solicitud POST para guardar los cambios del producto
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var productoExistente = await _context.Productos.FindAsync(Producto.Id);

            if (productoExistente == null)
            {
                return NotFound();
            }

            // Actualiza las propiedades del producto existente con los valores del producto actualizado
            productoExistente.NombreProducto = Producto.NombreProducto;
            productoExistente.Descripcion = Producto.Descripcion;
            productoExistente.EnStock = Producto.EnStock;
            productoExistente.Precio = Producto.Precio;

            // Guarda los cambios en la base de datos
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
