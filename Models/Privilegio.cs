using System;
using System.Collections.Generic;

namespace DevelopmentAS.Models;

public partial class Privilegio
{
    public int IdPrivilegio { get; set; }

    public string NombrePrivilegio { get; set; } = null!;

    public virtual ICollection<PrivegioPermiso> PrivegioPermisos { get; set; } = new List<PrivegioPermiso>();
}
