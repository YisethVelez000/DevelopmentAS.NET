using System;
using System.Collections.Generic;

namespace DevelopmentAS.Models;

public partial class Pedido
{
    public int NumeroPedido { get; set; }

    public int IdCliente { get; set; }

    public float TotalPedido { get; set; }

    public bool? EstadoPedido { get; set; }

    public string DireccionEnvio { get; set; } = null!;

    public DateOnly FechaPedido { get; set; }

    public DateOnly FechaEntrega { get; set; }

    public string FormaPago { get; set; } = null!;

    public virtual Cliente IdClienteNavigation { get; set; } = null!;
}
