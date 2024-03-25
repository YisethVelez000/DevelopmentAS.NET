using System;
using System.Collections.Generic;

namespace DevelopmentAS.Models;

public partial class Estampado
{
    public int IdEstampado { get; set; }

    public string NombreEstampado { get; set; } = null!;

    public string DescripcionEstampado { get; set; } = null!;

    public bool EstadoEstampado { get; set; }
}
