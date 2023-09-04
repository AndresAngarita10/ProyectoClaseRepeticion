using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Dominio.Entities;

namespace API.Controllers
{
    public class CiudadController : BaseApiController
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CiudadController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CiudadDto>>> Get()
        {
            var ciudad = await this.unitOfWork.Ciudades.GetAllAsync();
            return mapper.Map<List<CiudadDto>>(ciudad);
        }

        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<CiudadDto>> Get(int id)
        {
            var ciudad = await this.unitOfWork.Ciudades.GetByIdAsync(id);
            if (ciudad == null){
                return NotFound();
            }
            return this.mapper.Map<CiudadDto>(ciudad);
        }

            
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Ciudad>> Post(CiudadDto ciudadDto)
        {
            var ciudad = this.mapper.Map<Ciudad>(ciudadDto);
            this.unitOfWork.Ciudades.Add(ciudad);
            await this.unitOfWork.SaveAsync();
            if(ciudad == null)
            {
                return BadRequest();
            }
            ciudadDto.Id = ciudad.Id;
            return CreatedAtAction(nameof(Post), new {id = ciudadDto.Id}, ciudadDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<CiudadDto>> Put(int id, [FromBody]CiudadDto ciudadDto){
            if(ciudadDto == null)
            {
                return NotFound();
            }
            var ciudad = this.mapper.Map<Ciudad>(ciudadDto);
            this.unitOfWork.Ciudades.Update(ciudad);
            await this.unitOfWork.SaveAsync();
            return ciudadDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Delete(int id){
            var ciudad = await this.unitOfWork.Ciudades.GetByIdAsync(id);
            if(ciudad == null)
            {
                return NotFound();
            }
            this.unitOfWork.Ciudades.Remove(ciudad);
            await this.unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}