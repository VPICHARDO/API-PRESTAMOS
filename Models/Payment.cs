using System;
using System.Collections.Generic;

namespace API_PRESTAMOS.Models;

public partial class Payment
{
    public int PagoId { get; set; }

    public int PrestamoId { get; set; }

    public DateTime FechaPago { get; set; }

    public double Monto { get; set; }

    public bool? ATiempo { get; set; }

    public double? Mora { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Loan Prestamo { get; set; } = null!;
}
