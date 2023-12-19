using System;
using System.Collections.Generic;

namespace Ventas.Models;

public partial class Venta
{
    public int Idventa { get; set; }

    public int Idcliente { get; set; }

    public int Idusuario { get; set; }

    public string TipoComprobante { get; set; } = null!;

    public string? SerieComprobante { get; set; }

    public string NumComprobante { get; set; } = null!;

    public DateTime FechaHora { get; set; }

    public decimal Impuesto { get; set; }

    public decimal Total { get; set; }

    public string Estado { get; set; } = null!;

    public virtual ICollection<Detalleventa> Detalleventa { get; } = new List<Detalleventa>();

    public virtual Persona IdclienteNavigation { get; set; } = null!;

    public virtual Usuario IdusuarioNavigation { get; set; } = null!;
}
