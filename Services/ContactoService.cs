using System.Collections.Generic;
using System.Linq;

public class ContactoService
{
    private readonly ContactosContext _db;

    public ContactoService(ContactosContext db)
    {
        _db = db;
    }

    public List<Contacto> ObtenerTodo()
    {
        return _db.Contactos.ToList();
    }

    public Contacto Crear(Contacto contacto)
    {
        _db.Contactos.Add(contacto);
        _db.SaveChanges();
        return contacto;
    }

    public Contacto? ObtenerPorId(int id)
    {
        return _db.Contactos.FirstOrDefault(x => x.id == id);
    }

    public Contacto? Modificar(Contacto contacto)
    {
        var existe = _db.Contactos.FirstOrDefault(x => x.id == contacto.id);
        if (existe == null) return null;

        existe.Nombre = contacto.Nombre;
        existe.Apellido = contacto.Apellido;
        existe.Telefono = contacto.Telefono;
        existe.Email = contacto.Email;

        _db.SaveChanges();
        return existe;
    }
}
