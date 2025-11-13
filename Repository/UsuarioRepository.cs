public class UsuarioRepository : IUsuarioRepository
{
    private readonly ContactosContext _db;

    public UsuarioRepository(ContactosContext dbContext)
    {
        _db = dbContext;
    }

    public Usuario? ObtenerPorId(int id)
    {
        return _db.Usuarios.FirstOrDefault(u => u.Id == id);
    }

    public Usuario? ObtenerPorUserName(string userName)
    {
        return _db.Usuarios.FirstOrDefault(u => u.UserName == userName);
    }

    public List<Usuario> ObtenerTodos()
    {
        return _db.Usuarios.ToList();
    }

    public bool Agregar(Usuario usuario)
    {
        _db.Usuarios.Add(usuario);
        return Guardar();
    }

    public bool Actualizar(Usuario usuario)
    {
        _db.Usuarios.Update(usuario);
        return Guardar();
    }

    public bool Eliminar(Usuario usuario)
    {
        _db.Usuarios.Remove(usuario);
        return Guardar();
    }

    public bool ExisteUsuario(string userName)
{
    return _db.Usuarios.Any(u => u.UserName == userName);
}


    public bool Guardar()
    {
        return _db.SaveChanges() >= 0;
    }
}
