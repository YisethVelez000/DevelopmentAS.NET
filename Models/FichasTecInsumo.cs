using System;
using System.Collections.Generic;

namespace DevelopmentAS.Models;

public partial class FichasTecInsumo
{
    public int IdFichaTecIns { get; set; }

    public int IdFicha { get; set; }

    public int IdInsumo { get; set; }

    public int Cantidad { get; set; }

    public virtual FichasTecnica IdFichaNavigation { get; set; } = null!;

    public virtual Insumo IdInsumoNavigation { get; set; } = null!;
}
