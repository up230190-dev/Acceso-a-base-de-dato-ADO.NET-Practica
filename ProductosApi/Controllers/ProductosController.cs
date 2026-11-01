using Microsoft.AspNetCore.Mvc;
using ProductosApi.Models;
using ProductosApi.Repositories;

namespace ProductosApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    private readonly IProductoRepository _repo;

    public ProductosController(IProductoRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public IActionResult ObtenerTodos()
    {
        return Ok(_repo.ObtenerTodos());
    }

    [HttpGet("{id}")]
    public IActionResult ObtenerPorId(int id)
    {
        var producto = _repo.ObtenerPorId(id);
        if (producto == null) return NotFound();
        return Ok(producto);
    }

    [HttpGet("buscar")]
    public IActionResult Buscar(string nombre)
    {
        return Ok(_repo.Buscar(nombre));
    }

    [HttpPost]
    public IActionResult Insertar(Producto producto)
    {
        producto.Id = _repo.Insertar(producto);
        return Ok(producto);
    }

    [HttpPut("{id}")]
    public IActionResult Actualizar(int id, Producto producto)
    {
        producto.Id = id;
        if (!_repo.Actualizar(producto)) return NotFound();
        return Ok(producto);
    }

    [HttpDelete("{id}")]
    public IActionResult Eliminar(int id)
    {
        if (!_repo.Eliminar(id)) return NotFound();
        return Ok();
    }
}
