using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

public class AuthService
{
    // Usuarios hardcodeados para prueba
    private readonly List<Usuario> _usuarios = new()
    {
        new Usuario { NombreUsuario = "julio", Password = "julio123", Rol = "Administrador" },
        new Usuario { NombreUsuario = "diego", Password = "diego123", Rol = "Usuario" }
    };

    private readonly string _secretKey = "#_Nuestra_clave_proyecto_moviles_3_$";

    public string? Login(string nombreUsuario, string password)
    {
        // Validar credenciales
        var usuario = _usuarios.FirstOrDefault(u => 
            u.NombreUsuario == nombreUsuario && u.Password == password);

        if (usuario == null)
            return null; // Credenciales inválidas

        // Generar el token JWT
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
                new Claim(ClaimTypes.Name, usuario.NombreUsuario),
                new Claim(ClaimTypes.Role, usuario.Rol)
            }),
            Expires = DateTime.UtcNow.AddHours(2), // Token válido por 2 horas
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}