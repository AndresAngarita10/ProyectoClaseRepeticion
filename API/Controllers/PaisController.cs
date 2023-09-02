
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class PaisController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;

    public PaisController(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Pais>>> Get()
    {
        var paises = await unitOfWork.Paises.GetAllAsync();
        return Ok(paises);
    }

    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var paises = await unitOfWork.Paises.GetByIdAsync(id);
        return Ok(paises);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pais>> Post(Pais pais)
    {
        this.unitOfWork.Paises.Add(pais);
        await unitOfWork.SaveAsync();
        if(pais == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new{id = pais.Id}, pais);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pais>> Put(int id,[FromBody]Pais pais)
    {
        if(pais == null){
            return NotFound();
        }
        this.unitOfWork.Paises.Update(pais);
        await this.unitOfWork.SaveAsync();
        return pais;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var pais = await this.unitOfWork.Paises.GetByIdAsync(id);
        if(pais == null){
            return NotFound();
        }
        this.unitOfWork.Paises.Remove(pais);
        await this.unitOfWork.SaveAsync();
        return NoContent();
    }
}
