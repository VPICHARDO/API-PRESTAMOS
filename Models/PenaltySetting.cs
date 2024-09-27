using System;
using System.Collections.Generic;

namespace API_PRESTAMOS.Models;

public partial class PenaltySetting
{
    public int MoraId { get; set; }

    public int PrestamoId { get; set; }

    public double? MontoMora { get; set; }

    public bool? Activa { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Loan Prestamo { get; set; } = null!;
}
