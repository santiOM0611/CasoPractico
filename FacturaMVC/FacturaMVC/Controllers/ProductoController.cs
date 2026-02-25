using FacturaMVC.Models;
using FacturaMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace FacturaMVC.Controllers
{
    [Route("producto")]
    public class ProductoController : Controller
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var productos = _productoService.ObtenerTodos();
            return View(productos);
        }

        [HttpGet("detalle/{id:int}")]
        public IActionResult Detalle(int id)
        {
            var producto = _productoService.ObtenerDetalle(id);
            if (producto == null) return NotFound();
            return View(producto);
        }

        [HttpGet("crear")]
        public IActionResult Crear()
        {
            return View(new ProductoViewModel());
        }

        [HttpPost("crear")]
        public IActionResult Crear(ProductoViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var producto = new Producto
            {
                Nombre = model.Nombre,
                Precio = model.Precio
            };

            _productoService.CrearProducto(producto);
            return RedirectToAction("Index");
        }

        [HttpGet("editar/{id:int}")]
        public IActionResult Editar(int id)
        {
            var producto = _productoService.ObtenerDetalle(id);
            if (producto == null) return NotFound();

            var model = new ProductoViewModel
            {
                Nombre = producto.Nombre,
                Precio = producto.Precio
            };

            return View(model);
        }

        [HttpPost("editar/{id:int}")]
        public IActionResult Editar(int id, ProductoViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var producto = new Producto
            {
                Id = id,
                Nombre = model.Nombre,
                Precio = model.Precio
            };

            _productoService.EditarProducto(producto);
            return RedirectToAction("Index");
        }

        [HttpPost("eliminar/{id:int}")]
        public IActionResult Eliminar(int id)
        {
            _productoService.EliminarProducto(id);
            return RedirectToAction("Index");
        }
    }
}