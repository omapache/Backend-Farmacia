using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "formapago",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descripcion = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_formapago", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "marca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marca", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombrePais = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    rolName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rol", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipoDocumento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descripcion = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoDocumento", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoEmail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descripcion = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEmail", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipoMovimientoInventario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoMovimientoInventario", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipoPresentacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descripcion = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoPresentacion", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoTelefono",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descripcion = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTelefono", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreDepartamento = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PaisIdFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departamento_Pais_PaisIdFk",
                        column: x => x.PaisIdFk,
                        principalTable: "Pais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ciudad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreCiudad = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DepartamentoIdFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ciudad_Departamento_DepartamentoIdFk",
                        column: x => x.DepartamentoIdFk,
                        principalTable: "Departamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "detalleMovimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cantidad = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    precio = table.Column<double>(type: "double", nullable: false),
                    InventMedicamentoIdFk = table.Column<int>(type: "int", nullable: false),
                    MovInventarioIdFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalleMovimiento", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Direccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CallePrincipal = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CalleSecundaria = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Numero = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CiudadIdFk = table.Column<int>(type: "int", nullable: false),
                    PersonaIdFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direccion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Direccion_Ciudad_CiudadIdFk",
                        column: x => x.CiudadIdFk,
                        principalTable: "Ciudad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Email",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Direccion = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoEmailIdFk = table.Column<int>(type: "int", nullable: false),
                    PersonaIdFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Email", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Email_TipoEmail_TipoEmailIdFk",
                        column: x => x.TipoEmailIdFk,
                        principalTable: "TipoEmail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "inventarioMedicamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    stock = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    fechaExpiracion = table.Column<DateOnly>(type: "date", maxLength: 256, nullable: false),
                    PersonaIdFk = table.Column<int>(type: "int", nullable: false),
                    TipoPresentacionIdFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventarioMedicamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_inventarioMedicamento_tipoPresentacion_TipoPresentacionIdFk",
                        column: x => x.TipoPresentacionIdFk,
                        principalTable: "tipoPresentacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "producto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    precio = table.Column<double>(type: "double", nullable: false),
                    cantidad = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    InventMedicamentoIdFk = table.Column<int>(type: "int", nullable: false),
                    MarcaIdFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_producto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_producto_inventarioMedicamento_InventMedicamentoIdFk",
                        column: x => x.InventMedicamentoIdFk,
                        principalTable: "inventarioMedicamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_producto_marca_MarcaIdFk",
                        column: x => x.MarcaIdFk,
                        principalTable: "marca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "medicamentoReceta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RecetaIdFk = table.Column<int>(type: "int", nullable: false),
                    RecetaMedicaId = table.Column<int>(type: "int", nullable: true),
                    IventMedicamentoIdFk = table.Column<int>(type: "int", nullable: false),
                    InventarioMedicamentoId = table.Column<int>(type: "int", nullable: true),
                    descripcion = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicamentoReceta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_medicamentoReceta_inventarioMedicamento_InventarioMedicament~",
                        column: x => x.InventarioMedicamentoId,
                        principalTable: "inventarioMedicamento",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "movimientoInventario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    fechaMovimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    fechaVencimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    FormaPagoIdFk = table.Column<int>(type: "int", nullable: false),
                    TipoMovInventIdFk = table.Column<int>(type: "int", nullable: false),
                    ResponsableIdFk = table.Column<int>(type: "int", nullable: false),
                    ReceptorIdFk = table.Column<int>(type: "int", nullable: false),
                    RecetaMedicaIdFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movimientoInventario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_movimientoInventario_formapago_FormaPagoIdFk",
                        column: x => x.FormaPagoIdFk,
                        principalTable: "formapago",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_movimientoInventario_tipoMovimientoInventario_TipoMovInventI~",
                        column: x => x.TipoMovInventIdFk,
                        principalTable: "tipoMovimientoInventario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "persona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoPersonaIdFk = table.Column<int>(type: "int", nullable: false),
                    TipoDocumentoIdFk = table.Column<int>(type: "int", nullable: false),
                    RolIdFk = table.Column<int>(type: "int", nullable: false),
                    DireccionId = table.Column<int>(type: "int", nullable: true),
                    EmailId = table.Column<int>(type: "int", nullable: true),
                    TelefonoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persona", x => x.Id);
                    table.ForeignKey(
                        name: "FK_persona_Direccion_DireccionId",
                        column: x => x.DireccionId,
                        principalTable: "Direccion",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_persona_Email_EmailId",
                        column: x => x.EmailId,
                        principalTable: "Email",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_persona_rol_RolIdFk",
                        column: x => x.RolIdFk,
                        principalTable: "rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_persona_tipoDocumento_TipoDocumentoIdFk",
                        column: x => x.TipoDocumentoIdFk,
                        principalTable: "tipoDocumento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductoProveedores",
                columns: table => new
                {
                    ProductoIdFk = table.Column<int>(type: "int", nullable: false),
                    ProveedorIdFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoProveedores", x => new { x.ProveedorIdFk, x.ProductoIdFk });
                    table.ForeignKey(
                        name: "FK_ProductoProveedores_persona_ProveedorIdFk",
                        column: x => x.ProveedorIdFk,
                        principalTable: "persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductoProveedores_producto_ProductoIdFk",
                        column: x => x.ProductoIdFk,
                        principalTable: "producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "recetaMedica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DoctorIdFk = table.Column<int>(type: "int", nullable: false),
                    PacienteIdFk = table.Column<int>(type: "int", nullable: false),
                    fechaCadudicad = table.Column<DateOnly>(type: "date", nullable: false),
                    fechaCreacion = table.Column<DateOnly>(type: "date", nullable: false),
                    descripcion = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recetaMedica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_recetaMedica_persona_DoctorIdFk",
                        column: x => x.DoctorIdFk,
                        principalTable: "persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_recetaMedica_persona_PacienteIdFk",
                        column: x => x.PacienteIdFk,
                        principalTable: "persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Telefono",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Numero = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoTelefonoIdFk = table.Column<int>(type: "int", nullable: false),
                    PersonaIdFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefono", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Telefono_TipoTelefono_TipoTelefonoIdFk",
                        column: x => x.TipoTelefonoIdFk,
                        principalTable: "TipoTelefono",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Telefono_persona_PersonaIdFk",
                        column: x => x.PersonaIdFk,
                        principalTable: "persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipoPersona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descripcion = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoPersona", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tipoPersona_persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "persona",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PersonaIdFk = table.Column<int>(type: "int", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "persona",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Expires = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Revoked = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "userRol",
                columns: table => new
                {
                    UsuarioIdFk = table.Column<int>(type: "int", nullable: false),
                    RolIdFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userRol", x => new { x.UsuarioIdFk, x.RolIdFk });
                    table.ForeignKey(
                        name: "FK_userRol_rol_RolIdFk",
                        column: x => x.RolIdFk,
                        principalTable: "rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userRol_user_UsuarioIdFk",
                        column: x => x.UsuarioIdFk,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudad_DepartamentoIdFk",
                table: "Ciudad",
                column: "DepartamentoIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Departamento_PaisIdFk",
                table: "Departamento",
                column: "PaisIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_detalleMovimiento_InventMedicamentoIdFk",
                table: "detalleMovimiento",
                column: "InventMedicamentoIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_detalleMovimiento_MovInventarioIdFk",
                table: "detalleMovimiento",
                column: "MovInventarioIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Direccion_CiudadIdFk",
                table: "Direccion",
                column: "CiudadIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Direccion_PersonaIdFk",
                table: "Direccion",
                column: "PersonaIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Email_PersonaIdFk",
                table: "Email",
                column: "PersonaIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Email_TipoEmailIdFk",
                table: "Email",
                column: "TipoEmailIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_inventarioMedicamento_PersonaIdFk",
                table: "inventarioMedicamento",
                column: "PersonaIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_inventarioMedicamento_TipoPresentacionIdFk",
                table: "inventarioMedicamento",
                column: "TipoPresentacionIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_medicamentoReceta_InventarioMedicamentoId",
                table: "medicamentoReceta",
                column: "InventarioMedicamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_medicamentoReceta_RecetaMedicaId",
                table: "medicamentoReceta",
                column: "RecetaMedicaId");

            migrationBuilder.CreateIndex(
                name: "IX_movimientoInventario_FormaPagoIdFk",
                table: "movimientoInventario",
                column: "FormaPagoIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_movimientoInventario_ReceptorIdFk",
                table: "movimientoInventario",
                column: "ReceptorIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_movimientoInventario_RecetaMedicaIdFk",
                table: "movimientoInventario",
                column: "RecetaMedicaIdFk",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_movimientoInventario_ResponsableIdFk",
                table: "movimientoInventario",
                column: "ResponsableIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_movimientoInventario_TipoMovInventIdFk",
                table: "movimientoInventario",
                column: "TipoMovInventIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_persona_DireccionId",
                table: "persona",
                column: "DireccionId");

            migrationBuilder.CreateIndex(
                name: "IX_persona_EmailId",
                table: "persona",
                column: "EmailId");

            migrationBuilder.CreateIndex(
                name: "IX_persona_RolIdFk",
                table: "persona",
                column: "RolIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_persona_TelefonoId",
                table: "persona",
                column: "TelefonoId");

            migrationBuilder.CreateIndex(
                name: "IX_persona_TipoDocumentoIdFk",
                table: "persona",
                column: "TipoDocumentoIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_persona_TipoPersonaIdFk",
                table: "persona",
                column: "TipoPersonaIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_producto_InventMedicamentoIdFk",
                table: "producto",
                column: "InventMedicamentoIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_producto_MarcaIdFk",
                table: "producto",
                column: "MarcaIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoProveedores_ProductoIdFk",
                table: "ProductoProveedores",
                column: "ProductoIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_recetaMedica_DoctorIdFk",
                table: "recetaMedica",
                column: "DoctorIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_recetaMedica_PacienteIdFk",
                table: "recetaMedica",
                column: "PacienteIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UserId",
                table: "RefreshToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Telefono_PersonaIdFk",
                table: "Telefono",
                column: "PersonaIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Telefono_TipoTelefonoIdFk",
                table: "Telefono",
                column: "TipoTelefonoIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_tipoPersona_PersonaId",
                table: "tipoPersona",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_user_PersonaId",
                table: "user",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_userRol_RolIdFk",
                table: "userRol",
                column: "RolIdFk");

            migrationBuilder.AddForeignKey(
                name: "FK_detalleMovimiento_inventarioMedicamento_InventMedicamentoIdFk",
                table: "detalleMovimiento",
                column: "InventMedicamentoIdFk",
                principalTable: "inventarioMedicamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_detalleMovimiento_movimientoInventario_MovInventarioIdFk",
                table: "detalleMovimiento",
                column: "MovInventarioIdFk",
                principalTable: "movimientoInventario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Direccion_persona_PersonaIdFk",
                table: "Direccion",
                column: "PersonaIdFk",
                principalTable: "persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Email_persona_PersonaIdFk",
                table: "Email",
                column: "PersonaIdFk",
                principalTable: "persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_inventarioMedicamento_persona_PersonaIdFk",
                table: "inventarioMedicamento",
                column: "PersonaIdFk",
                principalTable: "persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_medicamentoReceta_recetaMedica_RecetaMedicaId",
                table: "medicamentoReceta",
                column: "RecetaMedicaId",
                principalTable: "recetaMedica",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_movimientoInventario_persona_ReceptorIdFk",
                table: "movimientoInventario",
                column: "ReceptorIdFk",
                principalTable: "persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_movimientoInventario_persona_ResponsableIdFk",
                table: "movimientoInventario",
                column: "ResponsableIdFk",
                principalTable: "persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_movimientoInventario_recetaMedica_RecetaMedicaIdFk",
                table: "movimientoInventario",
                column: "RecetaMedicaIdFk",
                principalTable: "recetaMedica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_persona_Telefono_TelefonoId",
                table: "persona",
                column: "TelefonoId",
                principalTable: "Telefono",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_persona_tipoPersona_TipoPersonaIdFk",
                table: "persona",
                column: "TipoPersonaIdFk",
                principalTable: "tipoPersona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ciudad_Departamento_DepartamentoIdFk",
                table: "Ciudad");

            migrationBuilder.DropForeignKey(
                name: "FK_Direccion_Ciudad_CiudadIdFk",
                table: "Direccion");

            migrationBuilder.DropForeignKey(
                name: "FK_Direccion_persona_PersonaIdFk",
                table: "Direccion");

            migrationBuilder.DropForeignKey(
                name: "FK_Email_persona_PersonaIdFk",
                table: "Email");

            migrationBuilder.DropForeignKey(
                name: "FK_Telefono_persona_PersonaIdFk",
                table: "Telefono");

            migrationBuilder.DropForeignKey(
                name: "FK_tipoPersona_persona_PersonaId",
                table: "tipoPersona");

            migrationBuilder.DropTable(
                name: "detalleMovimiento");

            migrationBuilder.DropTable(
                name: "medicamentoReceta");

            migrationBuilder.DropTable(
                name: "ProductoProveedores");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "userRol");

            migrationBuilder.DropTable(
                name: "movimientoInventario");

            migrationBuilder.DropTable(
                name: "producto");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "formapago");

            migrationBuilder.DropTable(
                name: "recetaMedica");

            migrationBuilder.DropTable(
                name: "tipoMovimientoInventario");

            migrationBuilder.DropTable(
                name: "inventarioMedicamento");

            migrationBuilder.DropTable(
                name: "marca");

            migrationBuilder.DropTable(
                name: "tipoPresentacion");

            migrationBuilder.DropTable(
                name: "Departamento");

            migrationBuilder.DropTable(
                name: "Pais");

            migrationBuilder.DropTable(
                name: "Ciudad");

            migrationBuilder.DropTable(
                name: "persona");

            migrationBuilder.DropTable(
                name: "Direccion");

            migrationBuilder.DropTable(
                name: "Email");

            migrationBuilder.DropTable(
                name: "Telefono");

            migrationBuilder.DropTable(
                name: "rol");

            migrationBuilder.DropTable(
                name: "tipoDocumento");

            migrationBuilder.DropTable(
                name: "tipoPersona");

            migrationBuilder.DropTable(
                name: "TipoEmail");

            migrationBuilder.DropTable(
                name: "TipoTelefono");
        }
    }
}
