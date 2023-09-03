using AutoMapper;
using BookStore.Dto;
using BookStore.Models;
using BookStore.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IBaseRepo<Author> _repo;
        private readonly IMapper _mapper;

        public AuthorsController(IBaseRepo<Author> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Add(AuthorDto dto)
        {
            var Author =new Author { Name= dto.Name };
            var result= _repo.Add(Author);

            var data = _mapper.Map<AuthorDetailsDto>(result);
            return Ok(data);
        
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = _repo.GetAll();
            var data = _mapper.Map<IEnumerable<AuthorDetailsDto>>(result);
            return Ok(data);

        }
        [HttpGet("GetById{id}")]
        public async Task<IActionResult> GetById(int id)
        {
           var result= _repo.GetById(id);

            if (result is null) return NotFound();

            var data = _mapper.Map<AuthorDetailsDto>(result);
            return Ok(data);
        }
        [HttpPut("update{id}")]
        public async Task<IActionResult> Update(int id,AuthorDto dto)
        {
            var result = _repo.GetById(id);
            if (result is null) return NotFound();
            result.Name = dto.Name;
            return Ok(_repo.Update(result));
        }
        [HttpDelete("Delete{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = _repo.GetById(id);
            if (result is null) return NotFound();
           return Ok( _repo.Delete(result));
        }
    }
}
