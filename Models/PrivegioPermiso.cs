using System;
using System.Collections.Generic;

namespace DevelopmentAS.Models;

public partial class PrivegioPermiso
{
    public int IdPriPer { get; set; }

    public int IdPermiso { get; set; }

    public int IdPrivilegio { get; set; }

    public virtual Permiso IdPermisoNavigation { get; set; } = null!;

    public virtual Privilegio IdPrivilegioNavigation { get; set; } = null!;
}
