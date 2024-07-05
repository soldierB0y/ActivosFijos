using System;
using System.Collections.Generic;

namespace ActivosFijos.Models;

public partial class ActivosFijo
{
    public int IdactivosFijos { get; set; }

    public int? Iddepartamento { get; set; }

    public string? Descripcion { get; set; }

    public string? TipoActivo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public double? ValorCompra { get; set; }

    public double? DepreciacionAcumulada { get; set; }

    public double? CuentaCompra { get; set; }

    public double? CuentaDepreciacion { get; set; }

    public virtual Departamento? IddepartamentoNavigation { get; set; }
}
