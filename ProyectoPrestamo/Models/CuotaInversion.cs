using System;
using System.Collections.Generic;

namespace ProyectoPrestamo.Models;

public partial class CuotaInversion
{
    public int IdCuotaIn { get; set; }

    public double? Monto { get; set; }

    public string? Tipo { get; set; }

    public DateTime? FechaRealizado { get; set; }

    public int? CodigoComprobante { get; set; }

    public int? IdInversion { get; set; }

    public int? IdBanco { get; set; }

    public virtual CuentaBanco? IdBancoNavigation { get; set; }

    public virtual Inversion? IdInversionNavigation { get; set; }
}
