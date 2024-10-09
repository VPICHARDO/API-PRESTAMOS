using System;
using System.Collections.Generic;

namespace API_PRESTAMOS.Models;

public partial class Employee
{
    public int EmpleadoId { get; set; }

    public int CompanyId { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public string? Rol { get; set; }

    public DateTime? CreationDate { get; set; }

    public string? Passport { get; set; }

    public string? IdCard { get; set; }

    public string? City { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

   public virtual Company? Company { get; set; } = null!;

    public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
}
