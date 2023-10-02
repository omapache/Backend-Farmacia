using API.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class InventarioMedicamentoController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly  IMapper mapper;

    public InventarioMedicamentoController( IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<InventarioMedicamentoDto>>> Get()
    {
        var entidad = await unitofwork.InventarioMedicamentos.GetAllAsync();
        return mapper.Map<List<InventarioMedicamentoDto>>(entidad);
    } 
    [HttpGet("consulta1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<InventarioMedicamentoDto>>> Get11()
    {
        var entidad = await unitofwork.InventarioMedicamentos.GetMedicamentosConMenosDe50Unidades(50);
        return mapper.Map<List<InventarioMedicamentoDto>>(entidad);
    }
    [HttpGet("consulta3/{Nombre}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> ObtenerMedicamentosVendidoEspecificoAsync(string Nombre)
    {
        var entidad = await unitofwork.InventarioMedicamentos.ObtenerMedicamentosVendidoEspecificoAsync(Nombre);
        var dto = mapper.Map<IEnumerable<object>>(entidad);
        return Ok(dto);
    }
    [HttpGet("consulta5/{NombreMedicamento}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> TotalVentasMedicamento(string NombreMedicamento)
    {
        var entidad = await unitofwork.InventarioMedicamentos.TotalVentasMedicamento(NombreMedicamento);
        var dto = mapper.Map<int>(entidad);
        return Ok(dto);
    }

    [HttpGet("consulta6/{fechaLimite}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> ObtenerMedicamentosCaducados(DateOnly fechaLimite)
    {
        var entidad = await unitofwork.InventarioMedicamentos.ObtenerMedicamentosCaducadosAsync(fechaLimite);
        var dto = mapper.Map<IEnumerable<object>>(entidad);
        return Ok(dto);
    }
    [HttpGet("consulta9/{Año}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> ObtenerMedicamentosSinVentaAñoAsync(int Año)
    {
        var entidad = await unitofwork.InventarioMedicamentos.ObtenerMedicamentosSinVentaAñoAsync(Año);
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

    [HttpGet("consulta12/{medicina}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> ObtenerPacienteCompradoEspecificoAsync(string medicina)
    {
        var entidad = await unitofwork.InventarioMedicamentos.ObtenerPacienteCompradoEspecificoAsync(medicina);
        var dto = mapper.Map<IEnumerable<object>>(entidad);
        return Ok(dto);
    }
    [HttpGet("consulta15/{Año}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> ObtenerMedicamentoMenosVendidoAsync(int Año)
    {
        var entidad = await unitofwork.InventarioMedicamentos.ObtenerMedicamentoMenosVendidoAsync(Año);
        var dto = mapper.Map<object>(entidad);
        return Ok(dto);
    }
    [HttpGet("consulta21")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> ObtenerMedicamentosSinVentaNuncaAsync()
    {
        var entidad = await unitofwork.InventarioMedicamentos.ObtenerMedicamentosSinVentaNuncaAsync();
        var dto = mapper.Map<IEnumerable<object>>(entidad);
        return Ok(dto);
    }

    [HttpGet("consulta38/medicamentos")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> GetMedicamentosEspecificos()
    {
        var entidad = await unitofwork.InventarioMedicamentos.GetMedicamentosEspecificos();
        var dto = mapper.Map<IEnumerable<object>>(entidad);
        return Ok(dto);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<InventarioMedicamentoDto>> Get(int id)
    {
        var entidad = await unitofwork.InventarioMedicamentos.GetByIdAsync(id);
        if (entidad == null){
            return NotFound();
        }
        return this.mapper.Map<InventarioMedicamentoDto>(entidad);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<InventarioMedicamento>> Post(InventarioMedicamentoDto entidadDto)
    {
        var entidad = this.mapper.Map<InventarioMedicamento>(entidadDto);
        this.unitofwork.InventarioMedicamentos.Add(entidad);
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

    public async Task<ActionResult<InventarioMedicamentoDto>> Put(int id, [FromBody]InventarioMedicamentoDto entidadDto){
        if(entidadDto == null)
        {
            return NotFound();
        }
        var entidad = this.mapper.Map<InventarioMedicamento>(entidadDto);
        unitofwork.InventarioMedicamentos.Update(entidad);
        await unitofwork.SaveAsync();
        return entidadDto;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var entidad = await unitofwork.InventarioMedicamentos.GetByIdAsync(id);
        if(entidad == null)
        {
            return NotFound();
        }
        unitofwork.InventarioMedicamentos.Remove(entidad);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}