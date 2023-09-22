using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Dominio.Interfaces;
using API.Dtos;
using Dominio.Entities;

namespace API.Controllers;

public class DireccionController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly  IMapper mapper;

    public DireccionController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<DireccionDto>>> Get()
    {
        var direccion = await unitofwork.Direcciones.GetAllAsync();
        return mapper.Map<List<DireccionDto>>(direccion);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<DireccionDto>> Get(int id)
    {
        var direccion = await unitofwork.Direcciones.GetByIdAsync(id);
        if (direccion == null){
            return NotFound();
        }
        return this.mapper.Map<DireccionDto>(direccion);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Direccion>> Post(DireccionDto direccionDto)
    {
        var direccion = this.mapper.Map<Direccion>(direccionDto);
        this.unitofwork.Direcciones.Add(direccion);
        await unitofwork.SaveAsync();
        if(direccion == null)
        {
            return BadRequest();
        }
        direccionDto.Id = direccion.Id;
        return CreatedAtAction(nameof(Post), new {id = direccionDto.Id}, direccionDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<DireccionDto>> Put(int id, [FromBody]DireccionDto direccionDto){
        if(direccionDto == null)
        {
            return NotFound();
        }
        var direccion = this.mapper.Map<Direccion>(direccionDto);
        unitofwork.Direcciones.Update(direccion);
        await unitofwork.SaveAsync();
        return direccionDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(int id){
        var direccion = await unitofwork.Direcciones.GetByIdAsync(id);
        if(direccion == null)
        {
            return NotFound();
        }
        unitofwork.Direcciones.Remove(direccion);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}