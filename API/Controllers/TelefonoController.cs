using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Dominio.Interfaces;
using API.Dtos;
using Dominio.Entities;

namespace API.Controllers;

public class TelefonoController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly  IMapper mapper;

    public TelefonoController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<TelefonoDto>>> Get()
    {
        var telefono = await unitofwork.Telefonos.GetAllAsync();
        return mapper.Map<List<TelefonoDto>>(telefono);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<TelefonoDto>> Get(int id)
    {
        var telefono = await unitofwork.Telefonos.GetByIdAsync(id);
        if (telefono == null){
            return NotFound();
        }
        return this.mapper.Map<TelefonoDto>(telefono);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Telefono>> Post(TelefonoDto telefonoDto)
    {
        var telefono = this.mapper.Map<Telefono>(telefonoDto);
        this.unitofwork.Telefonos.Add(telefono);
        await unitofwork.SaveAsync();
        if(telefono == null)
        {
            return BadRequest();
        }
        telefonoDto.Id = telefono.Id;
        return CreatedAtAction(nameof(Post), new {id = telefonoDto.Id}, telefonoDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<TelefonoDto>> Put(int id, [FromBody]TelefonoDto telefonoDto){
        if(telefonoDto == null)
        {
            return NotFound();
        }
        var telefono = this.mapper.Map<Telefono>(telefonoDto);
        unitofwork.Telefonos.Update(telefono);
        await unitofwork.SaveAsync();
        return telefonoDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(int id){
        var telefono = await unitofwork.Telefonos.GetByIdAsync(id);
        if(telefono == null)
        {
            return NotFound();
        }
        unitofwork.Telefonos.Remove(telefono);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}