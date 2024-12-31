using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrbitLibrary.Data.Entities;
using OrbitLibrary.Data.IReposorities;
using OrbitLibrary.Mapping;
using System.Formats.Asn1;
using System.Text.Json.Serialization;

namespace OrbitLibrary.Controllers
{
    [ApiController]
    public class ControllerBase<TEntity, InputDto, OutDto> : Controller where TEntity : Entity
        where InputDto : class
        where OutDto : DtoBase
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        public ControllerBase(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _repository.GetAll();
            return Ok(entities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await _repository.GetOne(id);
            if (entity == null)
            {
                return NotFound();
            }
            var output = _mapper.Map<OutDto>(entity);
            return Ok(output);
        }

        [HttpPost()]
        public async Task<IActionResult> AddOne([FromBody] InputDto input)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var mapped = _mapper.Map<TEntity>(input);
            await _repository.AddOne(mapped);
            await _repository.SaveChangesAsync();
            return Ok(mapped);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOne(int id)
        {
            var ecisting = await _repository.GetOne(id);
            if(ecisting == null)
                return NotFound();

            await _repository.DeleteOne(ecisting);
            await _repository.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOne(int id, [FromBody] InputDto entity)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var entityInDb = await _repository.GetOne(id);
            if(entityInDb is null) { return BadRequest(ModelState); }
            var mapped = _mapper.Map(entity, entityInDb);
            await _repository.SaveChangesAsync();
            return Ok(mapped);
        }
    }
}
