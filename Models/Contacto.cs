public class Contacto {
    public int id {get;set;}

    public string Nombre {get;set;}

    public string Telefono {get; set;}

    public string Email {get; set;}

    public string Apellido { get; set; }

    public DateTime FechaCreacion { get; set; } = DateTime.Now;
    
}