using System;
using System.Collections.Generic;

namespace DevelopmentAS.Models;

public partial class DetalleOrdenProduccion
{
    public int IdDetalleOrdenProduccion { get; set; }

    public int NroOrdenProduccion { get; set; }

    public string Tallas { get; set; } = null!;

    public string Productos { get; set; } = null!;

    public int Cantidad { get; set; }

    public virtual OrdenProduccion NroOrdenProduccionNavigation { get; set; } = null!;
}
