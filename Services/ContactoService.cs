public class ContactoService {
    public  readonly List <Contacto> _contacts = new List<Contacto>();

    // public void Add (Contacto Contacto)

    private int id=0;

    public List<Contacto> ObtenerTodo ()=> _contacts;

    public Contacto Crear (Contacto contacto){

        contacto.id = id++;
        _contacts.Add(contacto);
        return contacto;
    }

    public Contacto? ObtenerPorId (int id)=> _contacts.FirstOrDefault(x => x.id == id);

    public Contacto Modificar (Contacto contacto) {

        var existe = _contacts.FirstOrDefault ( x => x.id == contacto.id);
        if (existe == null) return null;
        existe.Nombre = contacto.Nombre;
        existe.Numero = contacto.Numero;
        existe.Apellido = contacto.Apellido;
        existe.Email = contacto.Email;
        return existe;
    }
}