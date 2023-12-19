using System;
using System.Collections.Generic;

namespace Ventas.Models;

public partial class Rol
{
    public int Idrol { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public ulong? Estado { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>();
}
