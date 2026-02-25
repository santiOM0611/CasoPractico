using FacturaMVC.Data;
using FacturaMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace FacturaMVC.Repositories
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly AppDbContext _context;

        public FacturaRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Factura> ObtenerTodas()
            => _context.Facturas
                .Include(f => f.Detalles)
                .OrderByDescending(f => f.Fecha)
                .ToList();

        public Factura? ObtenerPorId(int id)
            => _context.Facturas
                .Include(f => f.Detalles)
                .FirstOrDefault(f => f.Id == id);

        public void Crear(Factura factura, DetalleFactura detalle)
        {
            _context.Facturas.Add(factura);
            _context.SaveChanges();

            detalle.FacturaId = factura.Id;
            _context.DetallesFactura.Add(detalle);
            _context.SaveChanges();
        }
    }
}