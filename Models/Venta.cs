using System;
using System.Collections.Generic;

namespace DevelopmentAS.Models;

public partial class Venta
{
    public int IdVenta { get; set; }

    public int IdCliente { get; set; }

    public int IdPedido { get; set; }

    public DateOnly FechaPedido { get; set; }

    public DateOnly FechaVenta { get; set; }

    public bool EstadoVenta { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;
}
