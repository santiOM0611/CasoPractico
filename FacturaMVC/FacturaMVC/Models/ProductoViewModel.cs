using System.ComponentModel.DataAnnotations;

namespace FacturaMVC.Models
{
    public class ProductoViewModel
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Precio inválido")]
        public decimal Precio { get; set; }
    }
}