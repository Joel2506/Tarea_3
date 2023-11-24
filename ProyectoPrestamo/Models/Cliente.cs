using System;
using System.Collections.Generic;

namespace ProyectoPrestamo.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? Cedula { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public virtual ICollection<CuentaBanco> CuentaBancos { get; } = new List<CuentaBanco>();

    public virtual ICollection<Prestamo> Prestamos { get; } = new List<Prestamo>();
}
