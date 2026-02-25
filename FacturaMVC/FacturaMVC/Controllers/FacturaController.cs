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

    }
}