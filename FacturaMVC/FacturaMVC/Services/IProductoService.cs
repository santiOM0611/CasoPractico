using FacturaMVC.Models;

namespace FacturaMVC.Services
{
    public interface IProductoService
    {
        List<Producto> ObtenerTodos();
        Producto? ObtenerDetalle(int id);
        bool CrearProducto(Producto producto); 
    }
}