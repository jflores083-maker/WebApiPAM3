using System;
using System.Collections.Generic;

namespace WebApiPAM3.Models;

public partial class Producto
{
    public int ProductoId { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Precio { get; set; }

    public bool Activo { get; set; }

    public int CategoriaId { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string? Icono { get; set; }

    public virtual Categorium Categoria { get; set; } = null!;
}
