using API_PRESTAMOS.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

///ESTE CODIGO LO COLOCAMOS NOSOTROS 

// Agrega el servicio de DbContext y SQLite
builder.Services.AddDbContext<DbsqlPrestamoContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("CONE")));



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
