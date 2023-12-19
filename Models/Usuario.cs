using System;
using System.Collections.Generic;

namespace Ventas.Models;

public partial class Usuario
{
    public int Idusuario { get; set; }

    public int Idrol { get; set; }

    public string Nombre { get; set; } = null!;

    public string? TipoDocumento { get; set; }

    public string? NumDocumento { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string Email { get; set; } = null!;

    public string? Password { get; set; }

    public ulong? Estado { get; set; }

    public virtual Rol IdrolNavigation { get; set; } = null!;

    public virtual ICollection<Ingreso> Ingresos { get; } = new List<Ingreso>();

    public virtual ICollection<Venta> Venta { get; } = new List<Venta>();
}
