using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrbitLibrary.Data.Entities;
using OrbitLibrary.Data.IReposorities;
using OrbitLibrary.Dto.BookDto;

namespace OrbitLibrary.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase<Book, BookInput, BookOutput>
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _bookRepository = repository;
        }

        [HttpPost("{bookId:int}/Authors/{authorId:int}")]
        public async Task<IActionResult> AddAuthor(int bookId, int authorId)
        {
            await _bookRepository.AddAuthor(bookId, authorId);
            await _bookRepository.SaveChangesAsync();
            return NoContent();
        }

    }
}
