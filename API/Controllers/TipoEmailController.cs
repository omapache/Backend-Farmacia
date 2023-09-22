using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Dominio.Interfaces;
using API.Dtos;
using Dominio.Entities;

namespace API.Controllers;

public class TipoEmailController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly  IMapper mapper;

    public TipoEmailController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<TipoEmailDto>>> Get()
    {
        var tipoEmail = await unitofwork.TipoEmails.GetAllAsync();
        return mapper.Map<List<TipoEmailDto>>(tipoEmail);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<TipoEmailDto>> Get(int id)
    {
        var tipoEmail = await unitofwork.TipoEmails.GetByIdAsync(id);
        if (tipoEmail == null){
            return NotFound();
        }
        return this.mapper.Map<TipoEmailDto>(tipoEmail);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<TipoEmail>> Post(TipoEmailDto tipoEmailDto)
    {
        var tipoEmail = this.mapper.Map<TipoEmail>(tipoEmailDto);
        this.unitofwork.TipoEmails.Add(tipoEmail);
        await unitofwork.SaveAsync();
        if(tipoEmail == null)
        {
            return BadRequest();
        }
        tipoEmailDto.Id = tipoEmail.Id;
        return CreatedAtAction(nameof(Post), new {id = tipoEmailDto.Id}, tipoEmailDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<TipoEmailDto>> Put(int id, [FromBody]TipoEmailDto tipoEmailDto){
        if(tipoEmailDto == null)
        {
            return NotFound();
        }
        var tipoEmail = this.mapper.Map<TipoEmail>(tipoEmailDto);
        unitofwork.TipoEmails.Update(tipoEmail);
        await unitofwork.SaveAsync();
        return tipoEmailDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(int id){
        var tipoEmail = await unitofwork.TipoEmails.GetByIdAsync(id);
        if(tipoEmail == null)
        {
            return NotFound();
        }
        unitofwork.TipoEmails.Remove(tipoEmail);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}