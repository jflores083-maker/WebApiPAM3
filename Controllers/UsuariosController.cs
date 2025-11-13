using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly AuthService _authService;

    public UsuariosController(IUsuarioRepository usuarioRepository, AuthService authService)
    {
        _usuarioRepository = usuarioRepository;
        _authService = authService;
    }

    [HttpPost("login")]
    public ActionResult<LoginResponseDto> Login([FromBody] UsuarioDto usuarioDto)
    {
        var token = _authService.Login(usuarioDto.UserName, usuarioDto.Password);

        if (token == null)
            return Unauthorized("Usuario o contraseña incorrectos.");

        return Ok(new LoginResponseDto
        {
            UserName = usuarioDto.UserName,
            Token = token
        });
    }

    [HttpPost("register")]
    public ActionResult<Usuario> Register([FromBody] UsuarioDto usuarioDto)
    {
        if (_usuarioRepository.ExisteUsuario(usuarioDto.UserName))
            return BadRequest("El usuario ya existe.");

        var usuario = new Usuario
        {
            UserName = usuarioDto.UserName,
            Password = usuarioDto.Password,
            Rol = usuarioDto.Rol
        };

        var estado = _usuarioRepository.Agregar(usuario);

        return estado ? Ok(usuario) : StatusCode(500, "Error al registrar usuario.");
    }

    [HttpGet]
    public ActionResult<List<UsuarioDto>> ObtenerTodos()
    {
        var usuarios = _usuarioRepository.ObtenerTodos();
        return Ok(usuarios);
    }
}
