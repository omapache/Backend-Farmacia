using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Dominio.Interfaces;
using API.Dtos;
using Dominio.Entities;

namespace API.Controllers;

public class EmailController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly  IMapper mapper;

    public EmailController(IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<EmailDto>>> Get()
    {
        var email = await unitofwork.Emails.GetAllAsync();
        return mapper.Map<List<EmailDto>>(email);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<EmailDto>> Get(int id)
    {
        var email = await unitofwork.Emails.GetByIdAsync(id);
        if (email == null){
            return NotFound();
        }
        return this.mapper.Map<EmailDto>(email);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Email>> Post(EmailDto emailDto)
    {
        var email = this.mapper.Map<Email>(emailDto);
        this.unitofwork.Emails.Add(email);
        await unitofwork.SaveAsync();
        if(email == null)
        {
            return BadRequest();
        }
        emailDto.Id = email.Id;
        return CreatedAtAction(nameof(Post), new {id = emailDto.Id}, emailDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<EmailDto>> Put(int id, [FromBody]EmailDto emailDto){
        if(emailDto == null)
        {
            return NotFound();
        }
        var email = this.mapper.Map<Email>(emailDto);
        unitofwork.Emails.Update(email);
        await unitofwork.SaveAsync();
        return emailDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(int id){
        var email = await unitofwork.Emails.GetByIdAsync(id);
        if(email == null)
        {
            return NotFound();
        }
        unitofwork.Emails.Remove(email);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}