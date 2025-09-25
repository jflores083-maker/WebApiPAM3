using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route ("api/[controller]")]
public class ProductosController : ControllerBase{
    private readonly ProdcutoService _productoService;

    public ProductosController(ProdcutoService prodcutoService){
        _productoService = prodcutoService;
    }

    [HttpPost]
    public ActionResult <Producto> Crear(Producto newProducto){
        newProducto = _productoService.Crear(newProducto);
        return Ok( newProducto);
    }

[HttpPatch("{id:int}")]
public ActionResult<Producto> Modificar (int id, [FromBody] Producto newProducto ){
    if (!ModelState.IsValid) return BadRequest (ModelState);

    newProducto.id = id;
    var actualizado = _productoService.Modificar(newProducto);
    return actualizado is null? NotFound(): Ok(actualizado);
}

}