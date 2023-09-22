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