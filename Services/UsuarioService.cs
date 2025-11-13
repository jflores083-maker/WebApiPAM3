public class UsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    
    public bool Registrar(Usuario usuario)
    {
        if (_usuarioRepository.ObtenerPorUserName(usuario.UserName) != null)
            return false; 

        return _usuarioRepository.Agregar(usuario);
    }

    
    public Usuario? Login(string userName, string password)
    {
        var usuario = _usuarioRepository.ObtenerPorUserName(userName);
        if (usuario == null) return null;
        if (usuario.Password != password) return null;
        return usuario;
    }

    // Opcional: obtener todos los usuarios
    public List<Usuario> ObtenerTodos()
    {
        return _usuarioRepository.ObtenerTodos();
    }
}
