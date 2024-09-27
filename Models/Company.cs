using System;
using System.Collections.Generic;

namespace API_PRESTAMOS.Models;

public partial class Company
{
    public int CompanyId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Direccion { get; set; }

    public string? EmailContacto { get; set; }

    public string? TelefonoContacto { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
}
