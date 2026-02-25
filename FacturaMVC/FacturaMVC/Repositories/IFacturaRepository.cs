using FacturaMVC.Models;

namespace FacturaMVC.Repositories
{
    public interface IFacturaRepository
    {
        List<Factura> ObtenerTodas();
        Factura? ObtenerPorId(int id);
        void Crear(Factura factura, DetalleFactura detalle);
    }
}