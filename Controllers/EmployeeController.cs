using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_PRESTAMOS.Models;
//using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly DbsqlPrestamoContext BD;

public EmployeeController (DbsqlPrestamoContext context)
    {
        BD = context;
    }

    // GET: api/productos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Employee>>> GetEmpleado()
    {
        return await BD.Employees.ToListAsync();
    }

    // GET: api/productos/5
    [HttpGet("{id_card}")]
    public async Task<ActionResult<Employee>> GetEmpleadoIdCard(string id_card)
    {
        
      //  var Empleado = await _context.Employees.FindAsync(id_card);

       var Empleado = await  BD.Employees .Where(x=> x.IdCard == id_card).FirstAsync();

        if (Empleado == null)
        {
            return NotFound();
        }
        
        Console.Write(Empleado);

        return Empleado;
    }


    // POST: api/productos
    [HttpPost]
    public async Task<ActionResult<Employee>> PostEmpleado(Employee Empleado)
    {
        BD.Employees.Add(Empleado);
        await BD.SaveChangesAsync();
   ///Console.Write(x.ToString());
       return CreatedAtAction(nameof(GetEmpleado), new { id = Empleado.EmpleadoId}, Empleado);
       
    }



    // POST: api/productos
    [HttpPut]
    public async Task<ActionResult<Employee>> PutEmpleado(string id,Employee ep)
    {
        
      try
      {

       if (id.Length == 11 & )
       {
        
       }

        Employee empl = await BD.Employees.Where(x=> x.IdCard == id).FirstAsync();
    

      if (empl == null)
    {
        return NotFound($"Empleado con IdCard {id} no encontrado.");
    }

      // Verifica si hay cambios antes de actualizar
    if (empl.CompanyId != ep.CompanyId) empl.CompanyId = ep.CompanyId;
    if (empl.Name != ep.Name) empl.Name = ep.Name;
    if (empl.LastName != ep.LastName) empl.LastName = ep.LastName;
    if (empl.Email != ep.Email) empl.Email = ep.Email;
    if (empl.Contrasena != ep.Contrasena) empl.Contrasena = ep.Contrasena;
    if (empl.Rol != ep.Rol) empl.Rol = ep.Rol;
    if (empl.CreationDate != ep.CreationDate) empl.CreationDate = ep.CreationDate;
    if (empl.Passport != ep.Passport) empl.Passport = ep.Passport;
    if (empl.IdCard != ep.IdCard) empl.IdCard = ep.IdCard;
    if (empl.City != ep.City) empl.City = ep.City;
    if (empl.DateOfBirth != ep.DateOfBirth) empl.DateOfBirth = ep.DateOfBirth;
    if (empl.Address != ep.Address) empl.Address = ep.Address;
    if (empl.Phone != ep.Phone) empl.Phone = ep.Phone;

    // Guarda los cambios si hubo modificaciones
        
      BD.SaveChanges();

   
    return CreatedAtAction(nameof(GetEmpleado), new { id = ep.EmpleadoId}, ep);
         }
      catch (System.Exception)
      {
      return NotFound("ERROR");
        throw;
      }
    }


    
}
