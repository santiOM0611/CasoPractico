using System.ComponentModel.DataAnnotations;

namespace FacturaMVC.Models
{
    public class FacturaViewModel
    {
        [Required(ErrorMessage = "El nombre del cliente es obligatorio")]
        public string NombreCliente { get; set; }

        [Required(ErrorMessage = "Seleccione un producto")]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser al menos 1")]
        public int Cantidad { get; set; }

        public List<Producto> ProductosDisponibles { get; set; } = new();
    }
}