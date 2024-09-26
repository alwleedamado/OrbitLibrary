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
        public BookController(IBookRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
