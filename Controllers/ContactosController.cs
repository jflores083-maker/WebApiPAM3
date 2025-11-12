using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ContactosController : ControllerBase
{
    private readonly IContactoRepository _contactoRepository;

    public ContactosController(IContactoRepository contactoRepository)
    {
        _contactoRepository = contactoRepository;
    }

    [HttpPost]
    public ActionResult<Contacto> Crear(Contacto newContacto)
    {
        _contactoRepository.Agregar(newContacto);
        _contactoRepository.Guardar();
        return Ok(newContacto);
    }

    [HttpGet]
    public ActionResult<List<Contacto>> ObtenerTodos()
    {
        var contactos = _contactoRepository.ObtenerTodos();
        return Ok(contactos);
    }

    [HttpPatch("{id:int}")]
    public ActionResult<Contacto> Modificar(int id, [FromBody] Contacto newContacto)
    {
        newContacto.id = id;
        if (!_contactoRepository.Existe(id))
            return NotFound();

        _contactoRepository.Actualizar(newContacto);
        _contactoRepository.Guardar();
        return Ok(newContacto);
    }
}
