using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ContactosController : ControllerBase{
    private readonly ContactoService _contactoService;

    public ContactosController(ContactoService contactoService){
        _contactoService = contactoService;
    }

    [HttpPost]
    public ActionResult <Contacto> Crear(Contacto newContacto){
        newContacto = _contactoService.Crear(newContacto);
        return Ok( newContacto);
    }

[HttpPatch("{id:int}")]
public ActionResult<Contacto> Modificar (int id, [FromBody] Contacto newContacto ){
    if (!ModelState.IsValid) return BadRequest (ModelState);

    newContacto.id = id;
    var actualizado = _contactoService.Modificar(newContacto);
    return actualizado is null? NotFound(): Ok(actualizado);
}

}