using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_PRESTAMOS.Migrations
{
    /// <inheritdoc />
    public partial class CambioCambioTablaEmploEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    company_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nombre = table.Column<string>(type: "TEXT", nullable: false),
                    direccion = table.Column<string>(type: "TEXT", nullable: true),
                    email_contacto = table.Column<string>(type: "TEXT", nullable: true),
                    telefono_contacto = table.Column<string>(type: "TEXT", nullable: true),
                    fecha_creacion = table.Column<DateTime>(type: "DATETIME", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.company_id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    cliente_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    company_id = table.Column<int>(type: "INTEGER", nullable: false),
                    nombre = table.Column<string>(type: "TEXT", nullable: false),
                    apellido = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: true),
                    telefono = table.Column<string>(type: "TEXT", nullable: true),
                    direccion = table.Column<string>(type: "TEXT", nullable: true),
                    puntaje_credito = table.Column<int>(type: "INTEGER", nullable: true),
                    fecha_creacion = table.Column<DateTime>(type: "DATETIME", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    id_card = table.Column<string>(type: "TEXT", nullable: true),
                    passport = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.cliente_id);
                    table.ForeignKey(
                        name: "FK_Clients_Companies_company_id",
                        column: x => x.company_id,
                        principalTable: "Companies",
                        principalColumn: "company_id");
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    empleado_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    company_id = table.Column<int>(type: "INTEGER", nullable: false),
                    nombre = table.Column<string>(type: "TEXT", nullable: false),
                    apellido = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    contrasena = table.Column<string>(type: "TEXT", nullable: false),
                    rol = table.Column<string>(type: "TEXT", nullable: true),
                    fecha_creacion = table.Column<DateTime>(type: "DATETIME", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    passport = table.Column<string>(type: "TEXT", nullable: true),
                    id_card = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.empleado_id);
                    table.ForeignKey(
                        name: "FK_Employees_Companies_company_id",
                        column: x => x.company_id,
                        principalTable: "Companies",
                        principalColumn: "company_id");
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    prestamo_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    cliente_id = table.Column<int>(type: "INTEGER", nullable: false),
                    empleado_id = table.Column<int>(type: "INTEGER", nullable: false),
                    company_id = table.Column<int>(type: "INTEGER", nullable: false),
                    monto = table.Column<double>(type: "REAL", nullable: false),
                    tasa_interes = table.Column<double>(type: "REAL", nullable: false),
                    plazo_meses = table.Column<int>(type: "INTEGER", nullable: false),
                    fecha_inicio = table.Column<DateTime>(type: "DATE", nullable: false),
                    fecha_fin = table.Column<DateTime>(type: "DATE", nullable: false),
                    monto_restante = table.Column<double>(type: "REAL", nullable: false),
                    activo = table.Column<bool>(type: "BOOLEAN", nullable: true, defaultValue: true),
                    mora_activa = table.Column<bool>(type: "BOOLEAN", nullable: true, defaultValue: false),
                    fecha_creacion = table.Column<DateTime>(type: "DATETIME", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.prestamo_id);
                    table.ForeignKey(
                        name: "FK_Loans_Clients_cliente_id",
                        column: x => x.cliente_id,
                        principalTable: "Clients",
                        principalColumn: "cliente_id");
                    table.ForeignKey(
                        name: "FK_Loans_Companies_company_id",
                        column: x => x.company_id,
                        principalTable: "Companies",
                        principalColumn: "company_id");
                    table.ForeignKey(
                        name: "FK_Loans_Employees_empleado_id",
                        column: x => x.empleado_id,
                        principalTable: "Employees",
                        principalColumn: "empleado_id");
                });

            migrationBuilder.CreateTable(
                name: "ClientHistory",
                columns: table => new
                {
                    historial_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    cliente_id = table.Column<int>(type: "INTEGER", nullable: false),
                    prestamo_id = table.Column<int>(type: "INTEGER", nullable: true),
                    accion = table.Column<string>(type: "TEXT", nullable: true),
                    timestamp = table.Column<DateTime>(type: "DATETIME", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientHistory", x => x.historial_id);
                    table.ForeignKey(
                        name: "FK_ClientHistory_Clients_cliente_id",
                        column: x => x.cliente_id,
                        principalTable: "Clients",
                        principalColumn: "cliente_id");
                    table.ForeignKey(
                        name: "FK_ClientHistory_Loans_prestamo_id",
                        column: x => x.prestamo_id,
                        principalTable: "Loans",
                        principalColumn: "prestamo_id");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    pago_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    prestamo_id = table.Column<int>(type: "INTEGER", nullable: false),
                    fecha_pago = table.Column<DateTime>(type: "DATE", nullable: false),
                    monto = table.Column<double>(type: "REAL", nullable: false),
                    a_tiempo = table.Column<bool>(type: "BOOLEAN", nullable: true, defaultValue: true),
                    mora = table.Column<double>(type: "REAL", nullable: true, defaultValue: 0.0),
                    fecha_creacion = table.Column<DateTime>(type: "DATETIME", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.pago_id);
                    table.ForeignKey(
                        name: "FK_Payments_Loans_prestamo_id",
                        column: x => x.prestamo_id,
                        principalTable: "Loans",
                        principalColumn: "prestamo_id");
                });

            migrationBuilder.CreateTable(
                name: "PenaltySettings",
                columns: table => new
                {
                    mora_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    prestamo_id = table.Column<int>(type: "INTEGER", nullable: false),
                    monto_mora = table.Column<double>(type: "REAL", nullable: true, defaultValue: 100.0),
                    activa = table.Column<bool>(type: "BOOLEAN", nullable: true, defaultValue: true),
                    fecha_creacion = table.Column<DateTime>(type: "DATETIME", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PenaltySettings", x => x.mora_id);
                    table.ForeignKey(
                        name: "FK_PenaltySettings_Loans_prestamo_id",
                        column: x => x.prestamo_id,
                        principalTable: "Loans",
                        principalColumn: "prestamo_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientHistory_cliente_id",
                table: "ClientHistory",
                column: "cliente_id");

            migrationBuilder.CreateIndex(
                name: "IX_ClientHistory_prestamo_id",
                table: "ClientHistory",
                column: "prestamo_id");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_company_id",
                table: "Clients",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_email",
                table: "Clients",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_company_id",
                table: "Employees",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_email",
                table: "Employees",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Loans_cliente_id",
                table: "Loans",
                column: "cliente_id");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_company_id",
                table: "Loans",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_empleado_id",
                table: "Loans",
                column: "empleado_id");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_prestamo_id",
                table: "Payments",
                column: "prestamo_id");

            migrationBuilder.CreateIndex(
                name: "IX_PenaltySettings_prestamo_id",
                table: "PenaltySettings",
                column: "prestamo_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientHistory");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "PenaltySettings");

            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
