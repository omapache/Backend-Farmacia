using API.Dtos;
using API.Services;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class MedicamentoRecetaController : BaseApiController
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork unitofwork;
    private readonly  IMapper mapper;

    public MedicamentoRecetaController(IUserService userService, IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
        _userService = userService;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MedicamentoRecetaDto>>> Get()
    {
        var entidad = await unitofwork.MedicamentoRecetas.GetAllAsync();
        return mapper.Map<List<MedicamentoRecetaDto>>(entidad);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<MedicamentoRecetaDto>> Get(int id)
    {
        var entidad = await unitofwork.MedicamentoRecetas.GetByIdAsync(id);
        if (entidad == null){
            return NotFound();
        }
        return this.mapper.Map<MedicamentoRecetaDto>(entidad);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MedicamentoReceta>> Post(MedicamentoRecetaDto entidadDto)
    {
        var entidad = this.mapper.Map<MedicamentoReceta>(entidadDto);
        this.unitofwork.MedicamentoRecetas.Add(entidad);
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

    public async Task<ActionResult<MedicamentoRecetaDto>> Put(int id, [FromBody]MedicamentoRecetaDto entidadDto){
        if(entidadDto == null)
        {
            return NotFound();
        }
        var entidad = this.mapper.Map<MedicamentoReceta>(entidadDto);
        unitofwork.MedicamentoRecetas.Update(entidad);
        await unitofwork.SaveAsync();
        return entidadDto;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var entidad = await unitofwork.MedicamentoRecetas.GetByIdAsync(id);
        if(entidad == null)
        {
            return NotFound();
        }
        unitofwork.MedicamentoRecetas.Remove(entidad);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}