/* using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Dominio.Interfaces;
using API.Dtos;
using Dominio.Entities;
using API.Helpers.Errors;

namespace API.Controllers;

public class ProductoProveedorController: BaseApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly  IMapper mapper;

    public ProductoProveedorController( IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProductoProveedorDto>>> Get()
    {
        var entidad = await unitofwork.Personas.GetAllAsync();
        return mapper.Map<List<ProductoProveedorDto>>(entidad);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<ProductoProveedorDto>> Get(int id)
    {
        var entidad = await unitofwork.Personas.GetByIdAsync(id);
        if (entidad == null){
            return NotFound();
        }
        return this.mapper.Map<ProductoProveedorDto>(entidad);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Persona>> Post(ProductoProveedorDto entidadDto)
    {
        var entidad = this.mapper.Map<Persona>(entidadDto);
        this.unitofwork.Personas.Add(entidad);
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

    public async Task<ActionResult<ProductoProveedorDto>> Put(int id, [FromBody]ProductoProveedorDto entidadDto){
        if(entidadDto == null)
        {
            return NotFound();
        }
        var entidad = this.mapper.Map<Persona>(entidadDto);
        unitofwork.Personas.Update(entidad);
        await unitofwork.SaveAsync();
        return entidadDto;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var entidad = await unitofwork.Personas.GetByIdAsync(id);
        if(entidad == null)
        {
            return NotFound();
        }
        unitofwork.Personas.Remove(entidad);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}
 */