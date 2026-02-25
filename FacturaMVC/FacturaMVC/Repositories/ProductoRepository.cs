using FacturaMVC.Data;
using FacturaMVC.Models;

namespace FacturaMVC.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly AppDbContext _context;

        public ProductoRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Producto> ObtenerTodos()
            => _context.Productos.OrderBy(p => p.Nombre).ToList();

        public Producto? ObtenerPorId(int id)
            => _context.Productos.Find(id);

        public bool ExisteId(int id)
            => _context.Productos.Any(p => p.Id == id);

        public void Agregar(Producto producto)
        {
            _context.Productos.Add(producto);
            _context.SaveChanges();
        }

        public void Actualizar(Producto producto)
        {
            _context.Productos.Update(producto);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var producto = ObtenerPorId(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                _context.SaveChanges();
            }
        }
    }
}