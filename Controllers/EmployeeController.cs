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


    
}
