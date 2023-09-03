using BookStore.Models.Repositories;
using BookStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookStore.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBaseRepo<Book> _repo;
        private readonly IBaseRepo<Author> _repoAuthor;
        private readonly IMapper _mapper;

        public BooksController(IBaseRepo<Book> repo, IBaseRepo<Author> repoAuthor, IMapper mapper)
        {
            _repo = repo;
            _repoAuthor = repoAuthor;
            _mapper= mapper;
        }   
        [HttpPost]
        public async Task<IActionResult> Add(BookDto dto)
        {
            var author = _repoAuthor.GetById(dto.AuthorId);
            if (author is null) return BadRequest();
            var Book = new Book { Title = dto.Title ,AuthorId=dto.AuthorId,author=author };
            var result= _repo.Add(Book);
            var data = _mapper.Map<BookDetailsDto>(result);
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = _repo.GetAll();
            var data = _mapper.Map<IEnumerable<BookDetailsDto>>(result);
            return Ok(data);
        }
        [HttpGet("GetById{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = _repo.GetById(id);
            if (result is null) return NotFound();
            var data = _mapper.Map<BookDetailsDto>(result);
            return Ok(data);
        }
        [HttpPut("update{id}")]
        public async Task<IActionResult> Update(int id, BookDto dto)
        {
            var result = _repo.GetById(id);
            if (result is null) return NotFound();

            var author = _repoAuthor.GetById(dto.AuthorId);
            if (author is null) return BadRequest();
            result.Title= dto.Title;
            result.AuthorId= dto.AuthorId;
            //var book = new Book { Title = dto.Title ,AuthorId=dto.AuthorId};
            result = _repo.Update(result);
            var data = _mapper.Map<BookDetailsDto>(result);
            return Ok(data);
        }
        [HttpDelete("Delete{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = _repo.GetById(id);
            if (result is null) return NotFound();
            _repo.Delete(result);
            return Ok(result);
        }
        [HttpGet("Search")]
        public async Task<IActionResult> Search(string term)
        {
            var result = _repo.Search(term);
            var data = _mapper.Map<IEnumerable<BookDetailsDto>>(result);
            return Ok(data);
        }
    }
}
