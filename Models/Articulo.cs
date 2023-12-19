using System;
using System.Collections.Generic;

namespace Ventas.Models;

public partial class Articulo
{
    public int Idarticulo { get; set; }

    public int Idcategoria { get; set; }

    public string? Codigo { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal PrecioVenta { get; set; }

    public int Stock { get; set; }

    public string? Descripcion { get; set; }

    public ulong? Estado { get; set; }

    public virtual ICollection<Detalleingreso> Detalleingresos { get; } = new List<Detalleingreso>();

    public virtual ICollection<Detalleventa> Detalleventa { get; } = new List<Detalleventa>();

    public virtual Categoria IdcategoriaNavigation { get; set; } = null!;
}
