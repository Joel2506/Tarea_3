using System;
using System.Collections.Generic;

namespace ProyectoPrestamo.Models;

public partial class Prestamo
{
    public int IdPrestamo { get; set; }

    public int? IdFiador { get; set; }

    public int? IdCliente { get; set; }

    public double? Monto { get; set; }

    public double? Periodo { get; set; }

    public decimal? Interes { get; set; }

    public virtual ICollection<CuotaPrestamo> CuotaPrestamos { get; } = new List<CuotaPrestamo>();

    public virtual ICollection<Garantium> Garantia { get; } = new List<Garantium>();

    public virtual Cliente? IdClienteNavigation { get; set; }
}
