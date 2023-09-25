using API.Dtos;
using AutoMapper;
using Dominio.Entities;

namespace API.profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        
        CreateMap<Ciudad,CiudadDto>().ReverseMap();
        CreateMap<Departamento, DepartamentoDto>().ReverseMap();
        CreateMap<DescripcionMedicamento, DescripcionMedicamentoDto>().ReverseMap();
        CreateMap<Pais,PaisDto>().ReverseMap();
        CreateMap<Direccion, DireccionDto>().ReverseMap();
        CreateMap<Email, EmailDto>().ReverseMap();
        CreateMap<FormaPago, FormaPagoDto>().ReverseMap();
        CreateMap<InventarioMedicamento, InventarioMedicamentoDto>().ReverseMap();
        CreateMap<Marca, MarcaDto>().ReverseMap();
        CreateMap<MedicamentoReceta, MedicamentoRecetaDto>().ReverseMap();
        CreateMap<MovimientoInventario, MovimientoInventarioDto>().ReverseMap();
        CreateMap<Pais, PaisDto>().ReverseMap();
        CreateMap<Persona, PersonaDto>().ReverseMap();
        CreateMap<Persona, ProveedorDto>().ReverseMap();
        CreateMap<Producto, ProductoDto>().ReverseMap();
        CreateMap<ProductoProveedor, ProductoProveedorDto>().ReverseMap();
        CreateMap<RecetaMedica, RecetaMedicaDto>().ReverseMap();
        CreateMap<Rol, RolDto>().ReverseMap();
        CreateMap<Telefono, TelefonoDto>().ReverseMap();
        CreateMap<TipoDocumento, TipoDocumentoDto>().ReverseMap();
        CreateMap<TipoEmail, TipoEmailDto>().ReverseMap();
        CreateMap<TipoMovimientoInventario, TipoMovimientoInventarioDto>().ReverseMap();
        CreateMap<TipoPersona, TipoPersonaDto>().ReverseMap();
        CreateMap<TipoPresentacion, TipoPresentacionDto>().ReverseMap();
        CreateMap<TipoTelefono, TipoTelefonoDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
    }
}
