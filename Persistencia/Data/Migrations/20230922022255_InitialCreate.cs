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
                name: "pais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombrePais = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pais", x => x.Id);
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
                name: "tipoEmail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descripcion = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoEmail", x => x.Id);
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
                name: "tipoPersona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descripcion = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoPersona", x => x.Id);
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
                name: "tipoTelefono",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descripcion = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoTelefono", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "departamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombreDepartamento = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PaisIdFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_departamento_pais_PaisIdFk",
                        column: x => x.PaisIdFk,
                        principalTable: "pais",
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
                    numeroDocumento = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RolIdFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persona", x => x.Id);
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
                    table.ForeignKey(
                        name: "FK_persona_tipoPersona_TipoPersonaIdFk",
                        column: x => x.TipoPersonaIdFk,
                        principalTable: "tipoPersona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ciudad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombreCiudad = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DepartamentoIdFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ciudad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ciudad_departamento_DepartamentoIdFk",
                        column: x => x.DepartamentoIdFk,
                        principalTable: "departamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "email",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    direccion = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoEmailIdFk = table.Column<int>(type: "int", nullable: false),
                    PersonaIdFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_email", x => x.Id);
                    table.ForeignKey(
                        name: "FK_email_persona_PersonaIdFk",
                        column: x => x.PersonaIdFk,
                        principalTable: "persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_email_tipoEmail_TipoEmailIdFk",
                        column: x => x.TipoEmailIdFk,
                        principalTable: "tipoEmail",
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
                        name: "FK_inventarioMedicamento_persona_PersonaIdFk",
                        column: x => x.PersonaIdFk,
                        principalTable: "persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inventarioMedicamento_tipoPresentacion_TipoPresentacionIdFk",
                        column: x => x.TipoPresentacionIdFk,
                        principalTable: "tipoPresentacion",
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
                name: "telefono",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    numero = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoTelefonoIdFk = table.Column<int>(type: "int", nullable: false),
                    PersonaIdFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_telefono", x => x.Id);
                    table.ForeignKey(
                        name: "FK_telefono_persona_PersonaIdFk",
                        column: x => x.PersonaIdFk,
                        principalTable: "persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_telefono_tipoTelefono_TipoTelefonoIdFk",
                        column: x => x.TipoTelefonoIdFk,
                        principalTable: "tipoTelefono",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    PersonaIdFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_persona_PersonaIdFk",
                        column: x => x.PersonaIdFk,
                        principalTable: "persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "direccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    callePrincipal = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    calleSecundaria = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    numero = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    descripcion = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CiudadIdFk = table.Column<int>(type: "int", nullable: false),
                    PersonaIdFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_direccion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_direccion_ciudad_CiudadIdFk",
                        column: x => x.CiudadIdFk,
                        principalTable: "ciudad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_direccion_persona_PersonaIdFk",
                        column: x => x.PersonaIdFk,
                        principalTable: "persona",
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
                    table.ForeignKey(
                        name: "FK_medicamentoReceta_recetaMedica_RecetaMedicaId",
                        column: x => x.RecetaMedicaId,
                        principalTable: "recetaMedica",
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
                        name: "FK_movimientoInventario_persona_ReceptorIdFk",
                        column: x => x.ReceptorIdFk,
                        principalTable: "persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_movimientoInventario_persona_ResponsableIdFk",
                        column: x => x.ResponsableIdFk,
                        principalTable: "persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_movimientoInventario_recetaMedica_RecetaMedicaIdFk",
                        column: x => x.RecetaMedicaIdFk,
                        principalTable: "recetaMedica",
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
                    table.ForeignKey(
                        name: "FK_detalleMovimiento_inventarioMedicamento_InventMedicamentoIdFk",
                        column: x => x.InventMedicamentoIdFk,
                        principalTable: "inventarioMedicamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalleMovimiento_movimientoInventario_MovInventarioIdFk",
                        column: x => x.MovInventarioIdFk,
                        principalTable: "movimientoInventario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ciudad_DepartamentoIdFk",
                table: "ciudad",
                column: "DepartamentoIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_departamento_PaisIdFk",
                table: "departamento",
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
                name: "IX_direccion_CiudadIdFk",
                table: "direccion",
                column: "CiudadIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_direccion_PersonaIdFk",
                table: "direccion",
                column: "PersonaIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_email_PersonaIdFk",
                table: "email",
                column: "PersonaIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_email_TipoEmailIdFk",
                table: "email",
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
                name: "IX_persona_RolIdFk",
                table: "persona",
                column: "RolIdFk");

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
                name: "IX_telefono_PersonaIdFk",
                table: "telefono",
                column: "PersonaIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_telefono_TipoTelefonoIdFk",
                table: "telefono",
                column: "TipoTelefonoIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_user_PersonaIdFk",
                table: "user",
                column: "PersonaIdFk",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_userRol_RolIdFk",
                table: "userRol",
                column: "RolIdFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detalleMovimiento");

            migrationBuilder.DropTable(
                name: "direccion");

            migrationBuilder.DropTable(
                name: "email");

            migrationBuilder.DropTable(
                name: "medicamentoReceta");

            migrationBuilder.DropTable(
                name: "ProductoProveedores");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "telefono");

            migrationBuilder.DropTable(
                name: "userRol");

            migrationBuilder.DropTable(
                name: "movimientoInventario");

            migrationBuilder.DropTable(
                name: "ciudad");

            migrationBuilder.DropTable(
                name: "tipoEmail");

            migrationBuilder.DropTable(
                name: "producto");

            migrationBuilder.DropTable(
                name: "tipoTelefono");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "formapago");

            migrationBuilder.DropTable(
                name: "recetaMedica");

            migrationBuilder.DropTable(
                name: "tipoMovimientoInventario");

            migrationBuilder.DropTable(
                name: "departamento");

            migrationBuilder.DropTable(
                name: "inventarioMedicamento");

            migrationBuilder.DropTable(
                name: "marca");

            migrationBuilder.DropTable(
                name: "pais");

            migrationBuilder.DropTable(
                name: "persona");

            migrationBuilder.DropTable(
                name: "tipoPresentacion");

            migrationBuilder.DropTable(
                name: "rol");

            migrationBuilder.DropTable(
                name: "tipoDocumento");

            migrationBuilder.DropTable(
                name: "tipoPersona");
        }
    }
}
