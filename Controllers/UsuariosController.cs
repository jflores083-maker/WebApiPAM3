using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuariosController(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    
    [HttpPost("register")]
    public ActionResult<Usuario> Register(UsuarioDto usuarioDto)
    {
        
        if (_usuarioRepository.ExisteUsuario(usuarioDto.UserName))
        {
            return BadRequest("El usuario ya existe.");
        }

        var usuario = new Usuario
        {
            UserName = usuarioDto.UserName,
            Password = usuarioDto.Password,
            Rol = usuarioDto.Rol
        };

        var estado = _usuarioRepository.Agregar(usuario);

        return estado ? Ok(usuario) : StatusCode(500, "Error al registrar usuario.");
    }


    [HttpPost("login")]
    public ActionResult<Usuario> Login(UsuarioDto usuarioDto)
    {
        var usuario = _usuarioRepository.ObtenerPorUserName(usuarioDto.UserName);

        if (usuario == null || usuario.Password != usuarioDto.Password)
        {
            return Unauthorized("Usuario o contraseña incorrectos.");
        }

        return Ok(usuario);
    }
    
    [HttpGet]
public ActionResult<List<UsuarioDto>> ObtenerTodos()
{
    var usuarios = _usuarioRepository.ObtenerTodos();
    return Ok(usuarios);
}
}
