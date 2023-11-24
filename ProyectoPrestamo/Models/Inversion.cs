using System;
using System.Collections.Generic;

namespace ProyectoPrestamo.Models;

public partial class Inversion
{
    public int IdInversion { get; set; }

    public int? IdCliente { get; set; }

    public double? Monto { get; set; }

    public double? Periodo { get; set; }

    public double? Interes { get; set; }

    public virtual ICollection<CuentaBanco> CuentaBancos { get; } = new List<CuentaBanco>();

    public virtual ICollection<CuotaInversion> CuotaInversions { get; } = new List<CuotaInversion>();
}
