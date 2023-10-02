using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Dominio.Interfaces;
using API.Dtos;
using Dominio.Entities;
namespace API.Controllers;

public class MovimientoInventarioController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly  IMapper mapper;

    public MovimientoInventarioController( IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MovimientoInventarioDto>>> Get()
    {
        var entidad = await unitofwork.MovimientoInventarios.GetAllAsync();
        return mapper.Map<List<MovimientoInventarioDto>>(entidad);
    }

    [HttpGet("consulta8/totalDinero")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> TotalDineroVentasMedicamentos()
    {
        var entidad = await unitofwork.MovimientoInventarios.TotalDineroVentasMedicamentos();
        var dto = mapper.Map<double>(entidad);
        return Ok(dto);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<MovimientoInventarioDto>> Get(int id)
    {
        var entidad = await unitofwork.MovimientoInventarios.GetByIdAsync(id);
        if (entidad == null){
            return NotFound();
        }
        return this.mapper.Map<MovimientoInventarioDto>(entidad);
    }
    [HttpGet("consulta18/{Año}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> ObtenerVentasPorEmpleadoEn2023Async(int Año)
    {
        var entidad = await unitofwork.MovimientoInventarios.ObtenerVentasPorEmpleadoEn2023Async(Año);
        var dto = mapper.Map<IEnumerable<object>>(entidad);
        return Ok(dto);
    }
    [HttpGet("consulta19/{year}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> MedExpiranXAñoAsync(int year)
    {
        var entidad = await unitofwork.InventarioMedicamentos.MedExpiranXAñoAsync(year);
        var dto = mapper.Map<IEnumerable<object>>(entidad);
        return Ok(dto);
    }

    /* [HttpGet("consulta13/{medicina}")] */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MovimientoInventario>> Post(MovimientoInventarioDto entidadDto)
    {
        var entidad = this.mapper.Map<MovimientoInventario>(entidadDto);
        this.unitofwork.MovimientoInventarios.Add(entidad);
        await unitofwork.SaveAsync();
        if(entidad == null)
        {
            return BadRequest();
        }
        entidadDto.Id = entidad.Id;
        return CreatedAtAction(nameof(Post), new {id = entidadDto.Id}, entidadDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<MovimientoInventarioDto>> Put(int id, [FromBody]MovimientoInventarioDto entidadDto){
        if(entidadDto == null)
        {
            return NotFound();
        }
        var entidad = this.mapper.Map<MovimientoInventario>(entidadDto);
        unitofwork.MovimientoInventarios.Update(entidad);
        await unitofwork.SaveAsync();
        return entidadDto;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var entidad = await unitofwork.MovimientoInventarios.GetByIdAsync(id);
        if(entidad == null)
        {
            return NotFound();
        }
        unitofwork.MovimientoInventarios.Remove(entidad);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    [HttpGet("consulta7")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> TotalVentasxProveedor()
    {
        var entidad = await unitofwork.MovimientoInventarios.TotalVentasxProveedor();
        var dto = mapper.Map<IEnumerable<object>>(entidad);
        return Ok(dto);
    }

    
    [HttpGet("consulta13")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> ProvSinVentasUltAño()
    {
        var entidad = await unitofwork.MovimientoInventarios.ProvSinVentasUltAño();
        var dto = mapper.Map<IEnumerable<object>>(entidad);
        return Ok(dto);
    }

    
    [HttpGet("consulta22/{year}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> PacienteMasDineroXAño(int year)
    {
        var entidad = await unitofwork.MovimientoInventarios.PacienteMasDineroXAño(year);
        var dto = mapper.Map<object>(entidad);
        return Ok(dto);
    }

    
    [HttpGet("consulta25/{year}/{medicamento}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> PacienteCompMedxAnio(int year, string medicamento)
    {
        var entidad = await unitofwork.MovimientoInventarios.PacienteCompMedxAnio(year, medicamento);
        var dto = mapper.Map<IEnumerable<object>>(entidad);
        return Ok(dto);
    }

    
    [HttpGet("consulta28/{year}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> TotalProvSuministraMedicamentosxAnio(int year)
    {
        var entidad = await unitofwork.MovimientoInventarios.TotalProvSuministraMedicamentosxAnio(year);
        var dto = mapper.Map<IEnumerable<object>>(entidad);
        return Ok(dto);
    }

    
    [HttpGet("consulta31/{year}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> MedicVendXMesYAnio(int year)
    {
        var entidad = await unitofwork.MovimientoInventarios.MedicVendXMesYAnio(year);
        var dto = mapper.Map<IEnumerable<object>>(entidad);
        return Ok(dto);
    }

    
    [HttpGet("consulta37/{year}/{mes}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> EmpleadoSinVentasMesYAnio(int year, int mes)
    {
        var entidad = await unitofwork.MovimientoInventarios.EmpleadoSinVentasMesYAnio(year, mes);
        var dto = mapper.Map<IEnumerable<object>>(entidad);
        return Ok(dto);
    }
    /* [HttpGet("consulta20")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Persona>>> Get11()
    {
        var entidad = await unitofwork.MovimientoInventarios.EmpleadoMas5Ventas();
        return mapper.Map<List<Persona>>(entidad);
    } */
}
