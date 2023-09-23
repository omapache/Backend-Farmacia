using Aplicacion.Repository;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApiContext _context;
    private CiudadRepository _ciudades;
    private DepartamentoRepository _departamentos;
    private DetalleMovimientoRepository _detalleMovimientos;
    private DireccionRepository _direcciones;
    private EmailRepository _emails;
    private FormaPagoRepository _formaPagos;
    private InventarioMedicamentoRepository _inventarioMedicamentos;
    private MarcaRepository _marcas;
    private MedicamentoRecetaRepository _medicamentoReceta;
    private MovimientoInventarioRepository _movimientoInventario;
    private PaisRepository _paises;
    private PersonaRepository _personas;
    private ProductoRepository _productos;
    private RecetaMedicaRepository _recetaMedicas;
    private RolRepository _roles;
    private TelefonoRepository _telefonos;
    private TipoDocumentoRepository _tipoDocumentos;
    private TipoEmailRepository _tipoEmails;
    private TipoMovimientoInventarioRepository _tipoMovimientoInventarios;
    private TipoPersonaRepository _tipoPersonas;
    private DescripcionMedicamentoRepository _descripcionMedicamentos;
    private TipoPresentacionRepository _tipoPresentacionRepository;
    private TipoTelefonoRepository _tipoTelefonoRepository;
    private UserRepository _users;
    public UnitOfWork(ApiContext context)
    {
        _context = context;
    }
    public ICiudad Ciudades
    {
        get
        {
            if (_ciudades == null)
            {
                _ciudades = new CiudadRepository(_context);
            }
            return _ciudades;
        }
    }
    public IDepartamento Departamentos
    {
        get
        {
            if (_departamentos == null)
            {
                _departamentos = new DepartamentoRepository(_context);
            }
            return _departamentos;
        }
    }
    public IDetalleMovimiento DetalleMovimientos
    {
        get
        {
            if (_detalleMovimientos == null)
            {
                _detalleMovimientos = new DetalleMovimientoRepository(_context);
            }
            return _detalleMovimientos;
        }
    }
    public IDireccion Direcciones
    {
        get
        {
            if (_direcciones == null)
            {
                _direcciones = new DireccionRepository(_context);
            }
            return _direcciones;
        }
    }
    public IEmail Emails
    {
        get
        {
            if (_emails == null)
            {
                _emails = new EmailRepository(_context);
            }
            return _emails;
        }
    }
    public IFormaPago FormaPagos
    {
        get
        {
            if (_formaPagos == null)
            {
                _formaPagos = new FormaPagoRepository(_context);
            }
            return _formaPagos;
        }
    }
    
    public IInventarioMedicamento InventarioMedicamentos
    {
        get
        {
            if (_inventarioMedicamentos == null)
            {
                _inventarioMedicamentos = new InventarioMedicamentoRepository(_context);
            }
            return _inventarioMedicamentos;
        }
    }
    public IMarca Marcas
    {
        get
        {
            if (_marcas == null)
            {
                _marcas = new MarcaRepository(_context);
            }
            return _marcas;
        }
    }
    public IMedicamentoReceta MedicamentoRecetas
    {
        get
        {
            if (_medicamentoReceta == null)
            {
                _medicamentoReceta = new MedicamentoRecetaRepository(_context);
            }
            return _medicamentoReceta;
        }
    }
    public IMovimientoInventario MovimientoInventarios
    {
        get
        {
            if (_movimientoInventario == null)
            {
                _movimientoInventario = new MovimientoInventarioRepository(_context);
            }
            return _movimientoInventario;
        }
    }
    public IPais Paises
    {
        get
        {
            if (_paises == null)
            {
                _paises = new PaisRepository(_context);
            }
            return _paises;
        }
    }
    public IPersona Personas
    {
        get
        {
            if (_personas == null)
            {
                _personas = new PersonaRepository(_context);
            }
            return _personas;
        }
    }
    public IProducto Productos
    {
        get
        {
            if (_productos == null)
            {
                _productos = new ProductoRepository(_context);
            }
            return _productos;
        }
    }
    public IRecetaMedica RecetaMedicas
    {
        get
        {
            if (_recetaMedicas == null)
            {
                _recetaMedicas = new RecetaMedicaRepository(_context);
            }
            return _recetaMedicas;
        }
    }
    public IRol Rols
    {
        get
        {
            if (_roles == null)
            {
                _roles = new RolRepository(_context);
            }
            return _roles;
        }
    }
    public ITelefono Telefonos
    {
        get
        {
            if (_telefonos == null)
            {
                _telefonos = new TelefonoRepository(_context);
            }
            return _telefonos;
        }
    }
    public ITipoDocumento TipoDocumentos
    {
        get
        {
            if (_tipoDocumentos == null)
            {
                _tipoDocumentos = new TipoDocumentoRepository(_context);
            }
            return _tipoDocumentos;
        }
    }
    public ITipoEmail TipoEmails
    {
        get
        {
            if (_tipoEmails == null)
            {
                _tipoEmails = new TipoEmailRepository(_context);
            }
            return _tipoEmails;
        }
    }
    public ITipoMovimientoInventario TipoMovimientoInventarios
    {
        get
        {
            if (_tipoMovimientoInventarios == null)
            {
                _tipoMovimientoInventarios = new TipoMovimientoInventarioRepository(_context);
            }
            return _tipoMovimientoInventarios;
        }
    }
    public ITipoPersona TipoPersonas
    {
        get
        {
            if (_tipoPersonas == null)
            {
                _tipoPersonas = new TipoPersonaRepository(_context);
            }
            return _tipoPersonas;
        }
    }
    public IDescripcionMedicamento DescripcionMedicamentos    
    {
        get
        {
            if (_descripcionMedicamentos == null)
            {
                _descripcionMedicamentos = new DescripcionMedicamentoRepository(_context);
            }
            return _descripcionMedicamentos;
        }
    }
    public ITipoTelefono TipoTelefonos
    {
        get
        {
            if (_tipoTelefonoRepository == null)
            {
                _tipoTelefonoRepository = new TipoTelefonoRepository(_context);
            }
            return _tipoTelefonoRepository;
        }
    }
    public ITipoPresentacion TipoPresentaciones
    {
        get
        {
            if (_tipoPresentacionRepository == null)
            {
                _tipoPresentacionRepository = new TipoPresentacionRepository(_context);
            }
            return _tipoPresentacionRepository;
        }
    }
    
    public IUser Users
    {
        get
        {
            if (_users == null)
            {
                _users = new UserRepository(_context);
            }
            return _users;
        }
    }
    public void Dispose()
    {
        _context.Dispose();
    }
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}