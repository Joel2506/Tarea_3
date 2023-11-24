using System;
using System.Collections.Generic;

namespace ProyectoPrestamo.Models;

public partial class Garantium
{
    public int IdGarantia { get; set; }

    public string? Tipo { get; set; }

    public double? Valor { get; set; }

    public string? Ubicacion { get; set; }

    public int? IdPrestamo { get; set; }

    public virtual Prestamo? IdPrestamoNavigation { get; set; }
}
