using FacturaMVC.Models;
using FacturaMVC.Repositories;

namespace FacturaMVC.Services
{
    public class FacturaService : IFacturaService
    {
        private readonly IFacturaRepository _facturaRepo;
        private readonly IProductoRepository _productoRepo;

        private const decimal TasaImpuesto = 0.13m;

        public FacturaService(IFacturaRepository facturaRepo, IProductoRepository productoRepo)
        {
            _facturaRepo = facturaRepo;
            _productoRepo = productoRepo;
        }

        public FacturaViewModel ObtenerFacturaViewModel()
        {
            return new FacturaViewModel
            {
                ProductosDisponibles = _productoRepo.ObtenerTodos()
            };
        }

        public void CrearFactura(FacturaViewModel model)
        {
            var producto = _productoRepo.ObtenerPorId(model.ProductoId);

            if (producto == null)
                throw new Exception("Producto no encontrado");

            var subtotal = producto.Precio * model.Cantidad;
            var impuesto = subtotal * TasaImpuesto;
            var total = subtotal + impuesto;

            var factura = new Factura
            {
                NombreCliente = model.NombreCliente,
                Fecha = DateTime.Now,
                Subtotal = subtotal,
                Impuesto = impuesto,
                Total = total
            };

            var detalle = new DetalleFactura
            {
                ProductoId = producto.Id,
                NombreProducto = producto.Nombre,
                PrecioUnitario = producto.Precio,
                Cantidad = model.Cantidad
            };

            _facturaRepo.Crear(factura, detalle);
        }

        public List<Factura> ObtenerTodas()
            => _facturaRepo.ObtenerTodas();

        public Factura? ObtenerDetalle(int id)
            => _facturaRepo.ObtenerPorId(id);
    }
}