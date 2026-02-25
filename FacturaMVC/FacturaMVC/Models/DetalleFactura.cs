using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FacturaMVC.Models
{
    public class DetalleFactura
    {
        [Key]
        public int Id { get; set; }

        public string NombreProducto { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser al menos 1")]
        public int Cantidad { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecioUnitario { get; set; }

        [ForeignKey(nameof(Factura))]
        public int FacturaId { get; set; }
        public Factura? Factura { get; set; }

        [ForeignKey(nameof(Producto))]
        public int ProductoId { get; set; }
        public Producto? Producto { get; set; }
    }
}