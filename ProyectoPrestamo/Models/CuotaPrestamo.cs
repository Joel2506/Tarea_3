using System;
using System.Collections.Generic;

namespace ProyectoPrestamo.Models;

public partial class CuotaPrestamo
{
    public int IdCuotaPre { get; set; }

    public double? Monto { get; set; }

    public string? Tipo { get; set; }

    public DateTime? FechaRealizado { get; set; }

    public int? CodigoComprobante { get; set; }

    public int? IdPrestamo { get; set; }

    public virtual Prestamo? IdPrestamoNavigation { get; set; }
}
