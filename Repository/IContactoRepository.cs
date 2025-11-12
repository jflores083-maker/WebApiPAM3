using WebApiPAM3;

public interface IContactoRepository
{
    List<Contacto> ObtenerTodos();
    bool Existe(int Id);
    Contacto? ObtenerPorId(int Id);

    bool Agregar(Contacto contacto);

    bool Actualizar(Contacto contacto);

    bool Eliminar(Contacto contacto);

    bool Guardar();
}