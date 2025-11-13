using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public ActionResult Login([FromBody] LoginRequest request)
    {
        var token = _authService.Login(request.UserName, request.Password);

        if (token == null)
            return Unauthorized(new { mensaje = "Credenciales inválidas" });

        return Ok(new { token });
    }
}

// Clase auxiliar para recibir las credenciales
public class LoginRequest
{
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}