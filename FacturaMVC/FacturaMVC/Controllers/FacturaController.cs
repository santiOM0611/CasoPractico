using FacturaMVC.Models;
using FacturaMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace FacturaMVC.Controllers
{
    [Route("factura")]
    public class FacturaController : Controller
    {
        private readonly IFacturaService _facturaService;

        public FacturaController(IFacturaService facturaService)
        {
            _facturaService = facturaService;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var facturas = _facturaService.ObtenerTodas();
            return View(facturas);
        }

        [HttpGet("crear")]
        public IActionResult Crear()
        {
            var model = _facturaService.ObtenerFacturaViewModel();
            return View(model);
        }

        [HttpPost("crear")]
        public IActionResult Crear(FacturaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model = _facturaService.ObtenerFacturaViewModel();
                return View(model);
            }

            _facturaService.CrearFactura(model);
            return RedirectToAction("Index");
        }

        [HttpGet("detalle/{id:int}")]
        public IActionResult Detalle(int id)
        {
            var factura = _facturaService.ObtenerDetalle(id);
            if (factura == null) return NotFound();
            return View(factura);
        }

        [HttpGet("descargar/{id:int}")]
        public FileResult Descargar(int id)
        {
            var factura = _facturaService.ObtenerDetalle(id);

            var contenido = $"""
                Factura #{factura.Id}
                Cliente: {factura.NombreCliente}
                Fecha: {factura.Fecha:dd/MM/yyyy HH:mm}

                Detalle:
                """;

            foreach (var d in factura.Detalles)
            {
                contenido += $"\n{d.NombreProducto} x{d.Cantidad} @ {d.PrecioUnitario:C} = {d.PrecioUnitario * d.Cantidad:C}";
            }

            contenido += $"""

                Subtotal: {factura.Subtotal:C}
                Impuesto: {factura.Impuesto:C}
                Total: {factura.Total:C}
                """;

            var bytes = System.Text.Encoding.UTF8.GetBytes(contenido);
            return File(bytes, "text/plain", $"Factura_{factura.Id}.txt");
        }

    }
}