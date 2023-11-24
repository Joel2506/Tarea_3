using System;
using System.Collections.Generic;

namespace ProyectoPrestamo.Models;

public partial class CuentaBanco
{
    public int IdBanco { get; set; }

    public string? Nombre { get; set; }

    public string? Numero { get; set; }

    public string? Tipo { get; set; }

    public int? IdCliente { get; set; }

    public int? IdInversion { get; set; }

    public virtual ICollection<CuotaInversion> CuotaInversions { get; } = new List<CuotaInversion>();

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Inversion? IdInversionNavigation { get; set; }
}
