using System;
using System.Collections.Generic;

namespace API_PRESTAMOS.Models;

public partial class Login
{
    public string? User { get; set; }

    public string? Password { get; set; }

    public decimal? Active { get; set; }

    public int? EmpleadoId { get; set; }

    public int? CompanyId { get; set; }
}
