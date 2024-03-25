using System;
using System.Collections.Generic;

namespace DevelopmentAS.Models;

public partial class Proveedore
{
    public int IdProveedor { get; set; }

    public string NombreProv { get; set; } = null!;

    public string NombreContac { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public long? Telefono { get; set; }

    public bool EstadoProv { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();
}
