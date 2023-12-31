using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Dominio.Interfaces;
using API.Dtos;
using Dominio.Entities;

namespace API.Controllers;
public class DetalleMovimientoController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly  IMapper mapper;

    public DetalleMovimientoController( IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<DetalleMovimientoDto>>> Get()
    {
        var entidad = await unitofwork.DetalleMovimientos.GetAllAsync();
        return mapper.Map<List<DetalleMovimientoDto>>(entidad);
    }


    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<DetalleMovimientoDto>> Get(int id)
    {
        var entidad = await unitofwork.DetalleMovimientos.GetByIdAsync(id);
        if (entidad == null){
            return NotFound();
        }
        return this.mapper.Map<DetalleMovimientoDto>(entidad);
    }
    [HttpGet("consulta24/{Año}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<string>> ObtenerProveedorMasSuministrosAsync(int Año)
    {
        var entidad = await unitofwork.DetalleMovimientos.ObtenerProveedorMasSuministrosAsync(Año);
        var dto = mapper.Map<string>(entidad);
        return Ok(dto);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DetalleMovimiento>> Post(DetalleMovimientoDto entidadDto)
    {
        var entidad = this.mapper.Map<DetalleMovimiento>(entidadDto);
        this.unitofwork.DetalleMovimientos.Add(entidad);
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

    public async Task<ActionResult<DetalleMovimientoDto>> Put(int id, [FromBody]DetalleMovimientoDto entidadDto){
        if(entidadDto == null)
        {
            return NotFound();
        }
        var entidad = this.mapper.Map<DetalleMovimiento>(entidadDto);
        unitofwork.DetalleMovimientos.Update(entidad);
        await unitofwork.SaveAsync();
        return entidadDto;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var entidad = await unitofwork.DetalleMovimientos.GetByIdAsync(id);
        if(entidad == null)
        {
            return NotFound();
        }
        unitofwork.DetalleMovimientos.Remove(entidad);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}