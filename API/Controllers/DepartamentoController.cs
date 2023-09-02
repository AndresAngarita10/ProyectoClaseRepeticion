
using API.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class DepartamentoController : BaseApiController
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public DepartamentoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DepartamentoDto>>> Get()
        {
            var Dep = await this.unitOfWork.Departamentos.GetAllAsync();
            return mapper.Map<List<DepartamentoDto>>(Dep);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DepartamentoDto>> Get(int id)
        {
            var dep = await this.unitOfWork.Departamentos.GetByIdAsync(id);
            if(dep == null){
                return NotFound();
            }
            return this.mapper.Map<DepartamentoDto>(dep);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Departamento>> Post(DepartamentoDto depDto)
        {
            var dep = this.mapper.Map<Departamento>(depDto);
            this.unitOfWork.Departamentos.Add(dep);
            await this.unitOfWork.SaveAsync();
            if(dep == null){
                return BadRequest();
            }
            depDto.Id = dep.Id;
            return CreatedAtAction(nameof(Post), new { id = depDto.Id }, depDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DepartamentoDto>> Put(int id, [FromBody]DepartamentoDto depDto)
        {
            if(depDto == null){
                return NotFound();
            }
            var dep = this.mapper.Map<Departamento>(depDto);
            this.unitOfWork.Departamentos.Update(dep);
            await this.unitOfWork.SaveAsync();
            return depDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var dep = await this.unitOfWork.Departamentos.GetByIdAsync(id);
            if(dep == null){
                return NotFound();
            }
            this.unitOfWork.Departamentos.Remove(dep);
            await this.unitOfWork.SaveAsync();
            return NoContent();
        }

    }
}