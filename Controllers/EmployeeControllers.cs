using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_PRESTAMOS.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
[ApiController]
[Route("api/[controller]")]
public class EmployeeControllers : ControllerBase
{
    private readonly DbsqlPrestamoContext _context;

    public EmployeeControllers(DbsqlPrestamoContext context)
    {
        _context = context;
    }

    // GET: api/productos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Employee>>> GetProductos()
    {
        return await _context.Employees.ToListAsync();
    }

    // GET: api/productos/5
    [HttpGet("{id_card}")]
    public async Task<ActionResult<Employee>> GetProducto(string id_card)
    {
         // Buscar el empleado por el número de identificación
    var employee = await _context.Employees
                                 .FirstOrDefaultAsync(p => p.IdCard == id_card);

    // Verificar si el empleado fue encontrado
    if (employee == null)
    {
        return NotFound();  // Retorna un 404 si no se encuentra
    }

    // Retornar el empleado encontrado
    return Ok(employee);  
        

    }

/*
    // POST: api/productos
    [HttpPost]
    public async Task<ActionResult<Employee>> PostProducto(Employee producto)
    {
        _context.Employees.Add(producto);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProducto), new { id = producto.id}, producto);
    }

    */
}
