using System;
using System.Collections.Generic;

namespace API_PRESTAMOS.Models;

public partial class ClientHistory
{
    public int HistorialId { get; set; }

    public int ClienteId { get; set; }

    public int? PrestamoId { get; set; }

    public string? Accion { get; set; }

    public DateTime? Timestamp { get; set; }

    public virtual Client Cliente { get; set; } = null!;

    public virtual Loan? Prestamo { get; set; }
}
