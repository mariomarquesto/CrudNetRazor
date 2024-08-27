using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudNetRazor.Modelos
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        [Display(Name = "Nombre del Producto")]
        public required string NombreProducto { get; set; }

        [Display(Name = "Descripción del Producto")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La cantidad en stock es obligatoria.")]
        [Range(0, int.MaxValue, ErrorMessage = "La cantidad en stock debe ser un número positivo.")]
        [Display(Name = "Cantidad en Stock")]
        public int EnStock { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a cero.")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "La fecha de creación es obligatoria.")]
        [Display(Name = "Fecha de Creación")]
        [Column(TypeName = "timestamp without time zone")] // Esta línea es opcional dependiendo del enfoque que elijas
        public DateTime FechaCreacion { get; set; }

        // Método para establecer FechaCreacion en UTC al crear un nuevo producto
        public Producto()
        {
            FechaCreacion = DateTime.UtcNow;
        }
    }
}
