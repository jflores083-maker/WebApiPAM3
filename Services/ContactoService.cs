using WebApiPAM3.Models;

namespace WebApiPAM3.Services;

public class ContactoService
{
    public readonly List<Contacto> _contacts = new List<Contacto>();
    private int id = 0;

    public List<Contacto> ObtenerTodo() => _contacts;

    public Contacto Crear(Contacto contacto)
    {
        contacto.Id = id++;
        _contacts.Add(contacto);
        return contacto;
    }

    public Contacto? ObtenerPorId(int id) => _contacts.FirstOrDefault(x => x.Id == id);

    public Contacto? Modificar(Contacto contacto)
    {
        var existe = _contacts.FirstOrDefault(x => x.Id == contacto.Id);
        if (existe == null) return null;
        
        existe.Nombre = contacto.Nombre;
        existe.Telefono = contacto.Telefono;
        existe.Apellido = contacto.Apellido;
        existe.Email = contacto.Email;
        
        return existe;
    }
}