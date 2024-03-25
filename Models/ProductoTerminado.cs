using System;
using System.Collections.Generic;

namespace DevelopmentAS.Models;

public partial class ProductoTerminado
{
    public int IdProductoTerminado { get; set; }

    public int IdFichaTec { get; set; }

    public int? IdEstampado { get; set; }

    public string TipoEstampado { get; set; } = null!;

    public virtual FichasTecnica IdFichaTecNavigation { get; set; } = null!;
}
