using System.Globalization;
using System.Reflection;
using CsvHelper;
using Dominio.Entities;
using Microsoft.Extensions.Logging;

namespace Persistencia;

public class ApiContextSeed
{
    public static async Task SeedAsync(ApiContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            var ruta = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (!context.TipoPersonas.Any())
            {
                using (var readerTipoPersonas = new StreamReader(ruta + @"/Data/Csvs/TipoPersona.csv"))
                {
                    using (var csv = new CsvReader(readerTipoPersonas, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<TipoPersona>();
                        context.TipoPersonas.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.TipoPresentaciones.Any())
            {
                using (var readerTipoPersonas = new StreamReader(ruta + @"/Data/Csvs/TipoPresentacion.csv"))
                {
                    using (var csv = new CsvReader(readerTipoPersonas, CultureInfo.InvariantCulture))
                    {
                        var tipos = csv.GetRecords<TipoPresentacion>();
                        context.TipoPresentaciones.AddRange(tipos);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.TiposEmails.Any())
            {
                using (var reader = new StreamReader(ruta + @"/Data/Csvs/TipoEmail.csv"))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var tipos = csv.GetRecords<TipoEmail>();
                        context.TiposEmails.AddRange(tipos);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.TiposTelefonos.Any())
            {
                using (var reader = new StreamReader(ruta + @"/Data/Csvs/TipoTelefono.csv"))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var tipos = csv.GetRecords<TipoTelefono>();
                        context.TiposTelefonos.AddRange(tipos);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.TipoDocumentos.Any())
            {
                using (var reader = new StreamReader(ruta + @"/Data/Csvs/TipoPresentaciones.csv"))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var tipos = csv.GetRecords<TipoDocumento>();
                        context.TipoDocumentos.AddRange(tipos);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.FormaPagos.Any())
            {
                using (var readerTipoPersonas = new StreamReader(ruta + @"/Data/Csvs/FormaPago.csv"))
                {
                    using (var csv = new CsvReader(readerTipoPersonas, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<FormaPago>();
                        context.FormaPagos.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Marcas.Any())
            {
                using (var readerTipoPersonas = new StreamReader(ruta + @"/Data/Csvs/Marca.csv"))
                {
                    using (var csv = new CsvReader(readerTipoPersonas, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<Marca>();
                        context.Marcas.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Paises.Any())
            {
                using (var readerTipoPersonas = new StreamReader(ruta + @"/Data/Csvs/Pais.csv"))
                {
                    using (var csv = new CsvReader(readerTipoPersonas, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<Pais>();
                        context.Paises.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.TiposEmails.Any())
            {
                using (var readerTipoPersonas = new StreamReader(ruta + @"/Data/Csvs/TipoEmail.csv"))
                {
                    using (var csv = new CsvReader(readerTipoPersonas, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<TipoEmail>();
                        context.TiposEmails.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.TipoPersonas.Any())
            {
                using (var readerTipoPersonas = new StreamReader(ruta + @"/Data/Csvs/TipoPersona.csv"))
                {
                    using (var csv = new CsvReader(readerTipoPersonas, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<TipoPersona>();
                        context.TipoPersonas.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.TipoPresentaciones.Any())
            {
                using (var readerTipoPersonas = new StreamReader(ruta + @"/Data/Csvs/TipoPresentacion.csv"))
                {
                    using (var csv = new CsvReader(readerTipoPersonas, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<TipoPresentacion>();
                        context.TipoPresentaciones.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.TiposTelefonos.Any())
            {
                using (var readerTipoPersonas = new StreamReader(ruta + @"/Data/Csvs/TipoTelefono.csv"))
                {
                    using (var csv = new CsvReader(readerTipoPersonas, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<TipoTelefono>();
                        context.TiposTelefonos.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Personas.Any())
            {
                using (var reader = new StreamReader(ruta + @"/Data/Csvs/Persona.csv"))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<Persona>();

                        List<Persona> personas = new List<Persona>();
                        foreach (var item in list)
                        {
                            personas.Add(new Persona
                            {
                                Id = item.Id,
                                Nombre = item.Nombre,
                                TipoPersonaIdFk = item.TipoPersonaIdFk,
                                TipoDocumentoIdFk = item.TipoDocumentoIdFk,
                            });
                        }

                        context.Personas.AddRange(personas);
                        await context.SaveChangesAsync();
                    }
                }
            }
            /* if (!context.Compras.Any())
            {
                using (var readerCompras = new StreamReader(ruta + @"/Data/Csvs/Compra.csv"))
                {
                    using (var csvCompras = new CsvReader(readerCompras, CultureInfo.InvariantCulture))
                    {
                        var listComprascsv = csvCompras.GetRecords<Compra>();

                        List<Compra> compras = new List<Compra>();
                        foreach (var item in listComprascsv)
                        {
                            compras.Add(new Compra
                            {
                                Id = item.Id,
                                FechaCompra = item.FechaCompra,
                                PersonaIdFk = item.PersonaIdFk,
                                ProveedorIdFk = item.ProveedorIdFk,
                            });
                        }

                        context.Compras.AddRange(compras);
                        await context.SaveChangesAsync();
                    }
                }
            } */
            /* if (!context.Ventas.Any())
            {
                using (var readerVentas = new StreamReader(ruta + @"/Data/Csvs/Venta.csv"))
                {
                    using (var csvVentas = new CsvReader(readerVentas, CultureInfo.InvariantCulture))
                    {
                        var listVentasscv = csvVentas.GetRecords<Venta>();

                        List<Venta> ventas = new List<Venta>();
                        foreach (var item in listVentasscv)
                        {
                            ventas.Add(new Venta
                            {
                                Id = item.Id,
                                FechaVenta = item.FechaVenta,
                                PacienteIdFk = item.PacienteIdFk,
                                EmpleadoIdFk = item.EmpleadoIdFk,
                            });
                        }

                        context.Ventas.AddRange(ventas);
                        await context.SaveChangesAsync();
                    }
                }
            } */
            if (!context.Ciudades.Any())
            {
                using (var reader = new StreamReader(ruta + @"/Data/Csvs/Ciudad.csv"))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<Ciudad>();

                        List<Ciudad> entidad = new List<Ciudad>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Ciudad
                            {
                                Id = item.Id,
                                NombreCiudad = item.NombreCiudad,
                                DepartamentoIdFk = item.DepartamentoIdFk,
                            });
                        }

                        context.Ciudades.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Ciudades.Any())
            {
                using (var reader = new StreamReader(ruta + @"/Data/Csvs/Ciudad.csv"))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<Ciudad>();

                        List<Ciudad> entidad = new List<Ciudad>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Ciudad
                            {
                                Id = item.Id,
                                NombreCiudad = item.NombreCiudad,
                                DepartamentoIdFk = item.DepartamentoIdFk,
                            });
                        }

                        context.Ciudades.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Departamentos.Any())
            {
                using (var reader = new StreamReader(ruta + @"/Data/Csvs/Departamento.csv"))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<Departamento>();

                        List<Departamento> entidad = new List<Departamento>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Departamento
                            {
                                Id = item.Id,
                                NombreDepartamento = item.NombreDepartamento,
                                PaisIdFk = item.PaisIdFk,
                            });
                        }

                        context.Departamentos.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Departamentos.Any())
            {
                using (var reader = new StreamReader(ruta + @"/Data/Csvs/Departamento.csv"))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<Departamento>();

                        List<Departamento> entidad = new List<Departamento>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Departamento
                            {
                                Id = item.Id,
                                NombreDepartamento = item.NombreDepartamento,
                                PaisIdFk = item.PaisIdFk,
                            });
                        }

                        context.Departamentos.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            /*  if (!context.DetalleCompras.Any())
             {
                 using (var reader = new StreamReader(ruta + @"/Data/Csvs/DetalleCompra.csv"))
                 {
                     using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                     {
                         var list = csv.GetRecords<DetalleCompra>();

                         List<DetalleCompra> entidad = new List<DetalleCompra>();
                         foreach (var item in list)
                         {
                             entidad.Add(new DetalleCompra
                             {
                                 Id = item.Id,
                                 CompraIdFk = item.CompraIdFk,
                                 InventMedicamentoIdFk = item.InventMedicamentoIdFk,
                                 CantComprada = item.CantComprada,
                                 PrecioCompra = item.PrecioCompra,
                             });
                         }

                         context.DetalleCompras.AddRange(entidad);
                         await context.SaveChangesAsync();
                     }
                 }
             } */
            /* if (!context.DetalleVentas.Any())
            {
                using (var reader = new StreamReader(ruta + @"/Data/Csvs/DetalleVenta.csv"))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<DetalleVenta>();

                        List<DetalleVenta> entidad = new List<DetalleVenta>();
                        foreach (var item in list)
                        {
                            entidad.Add(new DetalleVenta
                            {
                                Id = item.Id,
                                VentaIdFk = item.VentaIdFk,
                                ProductoIdFk = item.ProductoIdFk,
                                CantVendida = item.CantVendida,
                                PrecioVenta = item.PrecioVenta,
                            });
                        }

                        context.DetalleVentas.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }  */
            if (!context.Direcciones.Any())
            {
                using (var reader = new StreamReader(ruta + @"/Data/Csvs/Direccion.csv"))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<Direccion>();

                        List<Direccion> entidad = new List<Direccion>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Direccion
                            {
                                Id = item.Id,
                                CiudadIdFk = item.CiudadIdFk,
                                CallePrincipal = item.CallePrincipal,
                                CalleSecundaria = item.CalleSecundaria,
                                Numero = item.Numero,
                                Descripcion = item.Descripcion,
                                PersonaIdFk = item.PersonaIdFk,
                            });
                        }

                        context.Direcciones.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Emails.Any())
            {
                using (var reader = new StreamReader(ruta + @"/Data/Csvs/Email.csv"))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<Email>();

                        List<Email> entidad = new List<Email>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Email
                            {
                                Id = item.Id,
                                Direccion = item.Direccion,
                                TipoEmailIdFk = item.TipoEmailIdFk,
                                PersonaIdFk = item.PersonaIdFk,
                            });
                        }

                        context.Emails.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            /*  if (!context.InventarioMedicamentos.Any())
             {
                 using (var reader = new StreamReader(ruta + @"/Data/Csvs/InventarioMedicamento.csv"))
                 {
                     using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                     {
                         var list = csv.GetRecords<InventarioMedicamento>();

                         List<InventarioMedicamento> entidad = new List<InventarioMedicamento>();
                         foreach (var item in list)
                         {
                             entidad.Add(new InventarioMedicamento
                             {
                                 Id = item.Id,
                                 Nombre = item.Nombre,
                                 Stock = item.Stock,
                                 FechaExpiracion = item.FechaExpiracion,
                                 PersonaIdFk = item.PersonaIdFk,
                                 TipoPresentacionIdFk = item.TipoPresentacionIdFk,
                             });
                         }

                         context.InventarioMedicamentos.AddRange(entidad);
                         await context.SaveChangesAsync();
                     }
                 }
             }*/
            if (!context.MedicamentoRecetas.Any())
            {
                using (var reader = new StreamReader(ruta + @"/Data/Csvs/MedicamentoReceta.csv"))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<MedicamentoReceta>();

                        List<MedicamentoReceta> entidad = new List<MedicamentoReceta>();
                        foreach (var item in list)
                        {
                            entidad.Add(new MedicamentoReceta
                            {
                                Id = item.Id,
                                RecetaIdFk = item.RecetaIdFk,
                                IventMedicamentoIdFk = item.IventMedicamentoIdFk,
                                Descripcion = item.Descripcion,
                            });
                        }

                        context.MedicamentoRecetas.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Personas.Any())
            {
                using (var reader = new StreamReader(ruta + @"/Data/Csvs/Persona.csv"))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<Persona>();

                        List<Persona> entidad = new List<Persona>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Persona
                            {
                                Id = item.Id,
                                Nombre = item.Nombre,
                                TipoPersonaIdFk = item.TipoPersonaIdFk,
                                TipoDocumentoIdFk = item.TipoDocumentoIdFk,
                            });
                        }

                        context.Personas.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            /* if (!context.Productos.Any())
            {
                using (var reader = new StreamReader(ruta + @"/Data/Csvs/Producto.csv"))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<Producto>();

                        List<Producto> entidad = new List<Producto>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Producto
                            {
                                Id = item.Id,
                                Precio = item.Precio,
                                Cantidad = item.Cantidad,
                                InventMedicamentoIdFk = item.InventMedicamentoIdFk,
                                MarcaIdFk = item.MarcaIdFk,
                            });
                        }

                        context.Productos.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            } */
            /* if (!context.ProductoProveedores.Any())
            {
                using (var reader = new StreamReader(ruta + @"/Data/Csvs/ProductoProveedor.csv"))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<ProductoProveedor>();

                        List<ProductoProveedor> entidad = new List<ProductoProveedor>();
                        foreach (var item in list)
                        {
                            entidad.Add(new ProductoProveedor
                            {
                                Id = item.Id,
                                ProductoIdFk = item.ProductoIdFk,
                                ProveedorIdFk = item.ProveedorIdFk,
                            });
                        }

                        context.ProductoProveedores.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            } */
            if (!context.RecetaMedicas.Any())
            {
                using (var reader = new StreamReader(ruta + @"/Data/Csvs/RecetaMedica.csv"))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<RecetaMedica>();

                        List<RecetaMedica> entidad = new List<RecetaMedica>();
                        foreach (var item in list)
                        {
                            entidad.Add(new RecetaMedica
                            {
                                Id = item.Id,
                                DoctorIdFk = item.DoctorIdFk,
                                PacienteIdFk = item.PacienteIdFk,
                                FechaCaducidad = item.FechaCaducidad,
                                Descripcion = item.Descripcion,
                                FechaCreacion = item.FechaCreacion,
                            });
                        }

                        context.RecetaMedicas.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Telefonos.Any())
            {
                using (var reader = new StreamReader(ruta + @"/Data/Csvs/Telefono.csv"))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<Telefono>();

                        List<Telefono> entidad = new List<Telefono>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Telefono
                            {
                                Id = item.Id,
                                Numero = item.Numero,
                                TipoTelefonoIdFk = item.TipoTelefonoIdFk,
                                PersonaIdFk = item.PersonaIdFk,
                            });
                        }

                        context.Telefonos.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Users.Any())
            {
                using (var reader = new StreamReader(ruta + @"/Data/Csvs/User.csv"))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<User>();

                        List<User> entidad = new List<User>();
                        foreach (var item in list)
                        {
                            entidad.Add(new User
                            {
                                Id = item.Id,
                                Username = item.Username,
                                Password = item.Password,
                                PersonaIdFk = item.PersonaIdFk,
                            });
                        }

                        context.Users.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.UsersRols.Any())
            {
                using (var reader = new StreamReader(ruta + @"/Data/Csvs/UserRol.csv"))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<UserRol>();

                        List<UserRol> entidad = new List<UserRol>();
                        foreach (var item in list)
                        {
                            entidad.Add(new UserRol
                            {
                                UsuarioIdFk = item.UsuarioIdFk,
                                RolIdFk = item.RolIdFk,
                            });
                        }

                        context.UsersRols.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }

        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<ApiContext>();
            logger.LogError(ex.Message);
        }
    }

    public static async Task SeedRolesAsync(ApiContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            if (!context.Rols.Any())
            {
                var roles = new List<Rol>()
                        {
                            new Rol{Id=1, Nombre="Administrador"},
                            new Rol{Id=2, Nombre="Empleado"},
                            new Rol{Id=3, Nombre="Cliente"},
                        };
                context.Rols.AddRange(roles);
                await context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<ApiContext>();
            logger.LogError(ex.Message);
        }
    }
}