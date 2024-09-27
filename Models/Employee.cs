using System;
using System.Collections.Generic;

namespace API_PRESTAMOS.Models;

public partial class Employee
{
    public int EmpleadoId { get; set; }

    public int CompanyId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public string? Rol { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? Passport { get; set; }

    public string? IdCard { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
}
