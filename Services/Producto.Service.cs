public class ProdcutoService {
    public  readonly List <Producto> _products = new List<Producto>();

    // public void Add (Producto producto)

    private int id=0;

    public List<Producto> ObtenerTodo ()=> _products;

    public Producto Crear (Producto producto){

        producto.id = id++;
        _products.Add(producto);
        return producto;
    }

    public Producto? ObtenerPorId (int id)=> _products.FirstOrDefault(x => x.id == id);

    public Producto Modificar (Producto producto) {

        var existe = _products.FirstOrDefault ( x => x.id == producto.id);
        if (existe == null) return null;
        existe.Nombre = producto.Nombre;
        existe.Precio = producto.Precio;
        return existe;
    }
}