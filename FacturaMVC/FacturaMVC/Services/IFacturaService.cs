using FacturaMVC.Models;

namespace FacturaMVC.Services
{
    public interface IFacturaService
    {
        FacturaViewModel ObtenerFacturaViewModel();
        void CrearFactura(FacturaViewModel model);
        List<Factura> ObtenerTodas();
        Factura? ObtenerDetalle(int id);
    }
}