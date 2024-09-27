using System;
using System.Collections.Generic;

namespace API_PRESTAMOS.Models;

public partial class Loan
{
    public int PrestamoId { get; set; }

    public int ClienteId { get; set; }

    public int EmpleadoId { get; set; }

    public int CompanyId { get; set; }

    public double Monto { get; set; }

    public double TasaInteres { get; set; }

    public int PlazoMeses { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFin { get; set; }

    public double MontoRestante { get; set; }

    public bool? Activo { get; set; }

    public bool? MoraActiva { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<ClientHistory> ClientHistories { get; set; } = new List<ClientHistory>();

    public virtual Client Cliente { get; set; } = null!;

    public virtual Company Company { get; set; } = null!;

    public virtual Employee Empleado { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<PenaltySetting> PenaltySettings { get; set; } = new List<PenaltySetting>();
}
