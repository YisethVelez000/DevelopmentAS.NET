using System;
using System.Collections.Generic;

namespace DevelopmentAS.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string NombreCompleto { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public string ConfirmarContrasena { get; set; } = null!;

    public int IdRol { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    public virtual Role IdRolNavigation { get; set; } = null!;
}
