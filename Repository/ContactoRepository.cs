public class ContactoRepository : IContactoRepository
{
    private readonly ContactosContext _db;

    public ContactoRepository(ContactosContext contactosContext)
    {
        _db = contactosContext;
    }

    public bool Actualizar(Contacto contacto)
    {
        _db.Contactos.Update(contacto);
        return Guardar();
    }

    public bool Agregar(Contacto contacto)
    {
        _db.Contactos.Add(contacto);
        return Guardar();
    }

    public bool Eliminar(Contacto contacto)
    {
        _db.Contactos.Remove(contacto);
        return Guardar();
    }

    public bool Existe(int id)
    {
        return _db.Contactos.Any(c => c.id == id);
    }

    public Contacto? ObtenerPorId(int id)
    {
        return _db.Contactos.FirstOrDefault(c => c.id == id);
    }

    public List<Contacto> ObtenerTodos()
    {
        return _db.Contactos.ToList();
    }

    public bool Guardar()
    {
        return _db.SaveChanges() >= 0;
    }
}
