using System;
using System.Collections.Generic;

namespace DevelopmentAS.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public int IdUsuario { get; set; }

    public string NombreEmpleado { get; set; } = null!;

    public long Cedula { get; set; }

    public DateOnly FechaNac { get; set; }

    public long? Telefono { get; set; }

    public DateOnly? FechaInicio { get; set; }

    public DateOnly FechaFinalizacion { get; set; }

    public bool? EstadoEmple { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
