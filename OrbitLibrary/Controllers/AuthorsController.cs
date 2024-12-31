using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrbitLibrary.Data.Entities;
using OrbitLibrary.Data.IReposorities;
using OrbitLibrary.Data.Repositories;
using OrbitLibrary.Dto.AuthorDto;

namespace OrbitLibrary.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorsController : ControllerBase<Author, AuthorInput, AuthorOutput>
    {
        public AuthorsController(IAuthorRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
