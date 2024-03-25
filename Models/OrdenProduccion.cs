using System;
using System.Collections.Generic;

namespace DevelopmentAS.Models;

public partial class OrdenProduccion
{
    public int NroOrdenProduccion { get; set; }

    public DateOnly FechaEstimada { get; set; }

    public string Estado { get; set; } = null!;

    public virtual ICollection<DetalleOrdenProduccion> DetalleOrdenProduccions { get; set; } = new List<DetalleOrdenProduccion>();
}
