using System;
using System.Collections.Generic;

namespace DevelopmentAS.Models;

public partial class Permiso
{
    public int IdPermiso { get; set; }

    public string NombrePermiso { get; set; } = null!;

    public virtual ICollection<PermisosRole> PermisosRoles { get; set; } = new List<PermisosRole>();

    public virtual ICollection<PrivegioPermiso> PrivegioPermisos { get; set; } = new List<PrivegioPermiso>();
}
