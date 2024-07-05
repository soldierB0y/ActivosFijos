using System;
using System.Collections.Generic;

namespace ActivosFijos.Models;

public partial class Empleado
{
    public int Idempleados { get; set; }

    public int? Iddepartamento { get; set; }

    public string? Nombre { get; set; }

    public string? Cedula { get; set; }

    public string? TipoPersona { get; set; }

    public DateTime? FechaIngreso { get; set; }

    public bool Estado { get; set; }

    public virtual Departamento? IddepartamentoNavigation { get; set; }
}
