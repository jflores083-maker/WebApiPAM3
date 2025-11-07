using System;
using System.Collections.Generic;

namespace WebApiPAM3.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Rol { get; set; } = null!;
}
