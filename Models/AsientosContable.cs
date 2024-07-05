using System;
using System.Collections.Generic;

namespace ActivosFijos.Models;

public partial class AsientosContable
{
    public int Idasiento { get; set; }

    public string? Descripcion { get; set; }

    public int? IdtipoInventario { get; set; }

    public double? CuentaContable { get; set; }

    public string? TipoMovimiento { get; set; }

    public DateTime? FechaAsiento { get; set; }

    public double? MontoAsiento { get; set; }

    public bool? Estado { get; set; }
}
