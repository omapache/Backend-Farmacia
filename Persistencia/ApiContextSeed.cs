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
                    using (var csvTipoPersona = new CsvReader(readerTipoPersonas, CultureInfo.InvariantCulture))
                    {
                        var TipoPersonas = csvTipoPersona.GetRecords<TipoPersona>();
                        context.TipoPersonas.AddRange(TipoPersonas);
                        await context.SaveChangesAsync();
                    }
                }
            }

            if (!context.Personas.Any())
            {
                using (var readerPersonas = new StreamReader(ruta + @"/Data/Csvs/Persona.csv"))
                {
                    using (var csvPersonas = new CsvReader(readerPersonas, CultureInfo.InvariantCulture))
                    {
                        var listPersonascsv = csvPersonas.GetRecords<Persona>();

                        List<Persona> personas = new List<Persona>();
                        foreach (var item in listPersonascsv)
                        {
                            personas.Add(new Persona
                            {
                                Id = item.Id,
                                Nombre = item.Nombre,
                                Contacto = item.Contacto,
                                Direccion = item.Direccion,
                                TipoPersonaIdFk = item.TipoPersonaIdFk,
                            });
                        }

                        context.Personas.AddRange(personas);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Compras.Any())
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
                                ProveedorIdFk = item.ProveedorIdFk,
                            });
                        }

                        context.Compras.AddRange(compras);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Medicamentos.Any())
            {
                using (var readerMedicamentos = new StreamReader(ruta + @"/Data/Csvs/Medicamento.csv"))
                {
                    using (var csvMedicamentos = new CsvReader(readerMedicamentos, CultureInfo.InvariantCulture))
                    {
                        var listMedicamentoscsv = csvMedicamentos.GetRecords<Medicamento>();

                        List<Medicamento> medicamentos = new List<Medicamento>();
                        foreach (var item in listMedicamentoscsv)
                        {
                            medicamentos.Add(new Medicamento
                            {
                                Id = item.Id,
                                Nombre = item.Nombre,
                                Precio = item.Precio,
                                Stock = item.Stock,
                                FechaExpiracion = item.FechaExpiracion,
                                PersonaIdFk = item.PersonaIdFk,
                            });
                        }

                        context.Medicamentos.AddRange(medicamentos);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Ventas.Any())
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
                            new Rol{Id=1, Nombre="Aministrator"},
                            new Rol{Id=2, Nombre="Customer"},
                            new Rol{Id=3, Nombre="Empleado"},
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