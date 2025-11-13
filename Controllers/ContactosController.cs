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
    public ActionResult<Contacto> Crear(ContactoDto contactoDto)
    {
        var contacto = new Contacto
        {
            Nombre = contactoDto.Nombre,
            Apellido = contactoDto.Apellido,
            Telefono = contactoDto.Telefono,
            Email = contactoDto.Email
        };
        var estado = _contactoRepository.Agregar(contacto);
        return estado ? Ok(contacto) : StatusCode(500, "Error al insertar");
    }

    // GET: api/Contactos
    [HttpGet]
    public ActionResult<List<Contacto>> ObtenerTodos()
    {
        return Ok(_contactoRepository.ObtenerTodos());
    }

    // GET: api/Contactos/5
    [HttpGet("{id:int}")]
    public ActionResult<Contacto> ObtenerPorId(int id)
    {
        var contacto = _contactoRepository.ObtenerPorId(id);
        return contacto != null ? Ok(contacto) : NotFound("No existe contacto");
    }

    [HttpPatch("{id:int}")]
    public ActionResult<Contacto> Modificar(int id, [FromBody] ContactoDto contactoDto)
    {
        var contactodb = _contactoRepository.ObtenerPorId(id);
        if (contactodb == null) return NotFound();

        contactodb.Nombre = contactoDto.Nombre;
        contactodb.Apellido = contactoDto.Apellido;
        contactodb.Telefono = contactoDto.Telefono;
        contactodb.Email = contactoDto.Email;

        var estado = _contactoRepository.Actualizar(contactodb);
        return estado ? Ok(contactodb) : StatusCode(500, "Error al actualizar");
    }

    [HttpDelete("{id:int}")]
    public ActionResult Eliminar(int id)
    {
        if (!_contactoRepository.Existe(id)) return NoContent();
        var contactodb = _contactoRepository.ObtenerPorId(id);
        var estado = _contactoRepository.Eliminar(contactodb);
        return estado ? Ok("Contacto eliminado") : StatusCode(500, "Error al eliminar");
    }
}
