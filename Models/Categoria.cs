using System;
using System.Collections.Generic;

namespace Ventas.Models;

public partial class Categoria
{
    public int Idcategoria { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public ulong? Estado { get; set; }

    public virtual ICollection<Articulo> Articulos { get; } = new List<Articulo>();
}
