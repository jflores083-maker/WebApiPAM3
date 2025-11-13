using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ContactosController : ControllerBase
{
    private readonly IContactoRepository _contactoRepository;

    private readonly IMapper _mapper;

    public ContactosController(IContactoRepository contactoRepository, IMapper mapper)
    {
        _contactoRepository = contactoRepository;
        _mapper = mapper;
    }

    [HttpPost]
    [HttpPost]
public ActionResult<ContactoDto> Crear(ContactoDto contactoDto)
{
    var contacto = _mapper.Map<Contacto>(contactoDto);
    var estado = _contactoRepository.Agregar(contacto);

    if (!estado) return StatusCode(500, "Error al insertar");

    var contactoResult = _mapper.Map<ContactoDto>(contacto);
    return Ok(contactoResult);
}


    // GET: api/Contactos
    [HttpGet]
public ActionResult<List<ContactoDto>> ObtenerTodos()
{
    var contactos = _contactoRepository.ObtenerTodos();
    var contactosDto = _mapper.Map<List<ContactoDto>>(contactos);
    return Ok(contactosDto);
}


    // GET: api/Contactos/5
    [HttpGet("{id}")]
public ActionResult<ContactoDto> ObtenerPorId(int id)
{
    var contacto = _contactoRepository.ObtenerPorId(id);
    if (contacto == null) return NotFound("No existe contacto");

    var contactoDto = _mapper.Map<ContactoDto>(contacto);
    return Ok(contactoDto);
}


    [HttpPatch("{id:int}")]
public ActionResult<ContactoDto> Modificar(int id, [FromBody] ContactoDto contactoDto)
{
    var contacto = _contactoRepository.ObtenerPorId(id);
    if (contacto == null) return NotFound();

    _mapper.Map(contactoDto, contacto); // Mapea los valores del DTO sobre la entidad existente

    var estado = _contactoRepository.Actualizar(contacto);
    if (!estado) return StatusCode(500, "Error al actualizar");

    var contactoResult = _mapper.Map<ContactoDto>(contacto);
    return Ok(contactoResult);
}


    [HttpDelete("{id}")]
public ActionResult Eliminar(int id)
{
    var contacto = _contactoRepository.ObtenerPorId(id);
    if (contacto == null) return NotFound("No existe contacto");

    var estado = _contactoRepository.Eliminar(contacto);
    return estado ? Ok("Contacto eliminado") : StatusCode(500, "Error al eliminar");
}

}
