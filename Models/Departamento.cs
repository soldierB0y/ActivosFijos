using System;
using System.Collections.Generic;

namespace ActivosFijos.Models;

public partial class Departamento
{
    public int Iddepartamentos { get; set; }

    public string? Descripcion { get; set; }

    public bool Estado { get; set; }

    public virtual ICollection<ActivosFijo> ActivosFijos { get; set; } = new List<ActivosFijo>();

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
