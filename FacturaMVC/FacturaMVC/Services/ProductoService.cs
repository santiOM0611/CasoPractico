using FacturaMVC.Models;
using FacturaMVC.Repositories;

namespace FacturaMVC.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repository;

        public ProductoService(IProductoRepository repository)
        {
            _repository = repository;
        }

        public List<Producto> ObtenerTodos()
            => _repository.ObtenerTodos();

        public Producto? ObtenerDetalle(int id)
            => _repository.ObtenerPorId(id);

        public bool CrearProducto(Producto producto)
        {
            _repository.Agregar(producto);
            return true;
        }
    }
}