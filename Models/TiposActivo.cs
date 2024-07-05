using System;
using System.Collections.Generic;

namespace ActivosFijos.Models;

public partial class TiposActivo
{
    public int IdtiposActivos { get; set; }

    public string? Descripicion { get; set; }

    public double? CuentaContableCompra { get; set; }

    public double? CuentaContableDepreciacion { get; set; }

    public bool Estado { get; set; }
}
