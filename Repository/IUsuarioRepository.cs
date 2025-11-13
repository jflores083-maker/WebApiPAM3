
public interface IUsuarioRepository
{
    Usuario? ObtenerPorId(int id);
    Usuario? ObtenerPorUserName(string userName);
    List<Usuario> ObtenerTodos();
    
    bool Agregar(Usuario usuario);
    bool Actualizar(Usuario usuario);
    bool Eliminar(Usuario usuario);
bool ExisteUsuario(string userName);
    bool Guardar();
}
