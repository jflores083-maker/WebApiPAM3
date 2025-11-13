using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

public class AuthService
{
    private readonly IUsuarioRepository _usuarioRepository;

    // Usuarios hardcodeados para Swagger o pruebas
    private readonly List<Usuario> _usuariosHardcodeados = new()
    {
        new Usuario { UserName = "julio", Password = "julio123", Rol = "Administrador" },
        new Usuario { UserName = "diego", Password = "diego123", Rol = "Usuario" }
    };

    private readonly string _secretKey = "#_Nuestra_clave_proyecto_moviles_3_$";

    public AuthService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public string? Login(string nombreUsuario, string password)
    {
        // Primero buscar en la base de datos
        var usuario = _usuarioRepository.ObtenerPorUserName(nombreUsuario);

        // Si no está en la base, buscar en los hardcodeados
        if (usuario == null)
        {
            usuario = _usuariosHardcodeados.FirstOrDefault(u =>
                u.UserName == nombreUsuario && u.Password == password);
        }
        else
        {
            // Verificar contraseña de la base
            if (usuario.Password != password)
                return null;
        }

        if (usuario == null)
            return null; // No se encontró usuario válido

        // Generar token JWT
        return GenerarToken(usuario);
    }

    private string GenerarToken(Usuario usuario)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_secretKey);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, usuario.UserName),
                new Claim(ClaimTypes.Role, usuario.Rol)
            }),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
