using System;
using System.Collections.Generic;

namespace DevelopmentAS.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public int IdUsuario { get; set; }

    public string NombreCliente { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public long Telefono { get; set; }

    public bool EstadoClientes { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
