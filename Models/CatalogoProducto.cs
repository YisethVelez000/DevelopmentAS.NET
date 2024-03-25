using System;
using System.Collections.Generic;

namespace DevelopmentAS.Models;

public partial class CatalogoProducto
{
    public int IdcatalogoProducto { get; set; }

    public string TipoCatalogo { get; set; } = null!;

    public string NombreProducto { get; set; } = null!;

    public int IdfichaTecnica { get; set; }

    public string TipoEstampado { get; set; } = null!;

    public string Color { get; set; } = null!;

    public int CantidadColor { get; set; }

    public decimal Total { get; set; }

    public virtual ICollection<EstampadoProducto> EstampadoProductos { get; set; } = new List<EstampadoProducto>();

    public virtual FichasTecnica IdfichaTecnicaNavigation { get; set; } = null!;
}
