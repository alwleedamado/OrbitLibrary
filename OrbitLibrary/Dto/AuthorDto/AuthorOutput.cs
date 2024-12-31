using OrbitLibrary.Mapping;

namespace OrbitLibrary.Dto.AuthorDto
{
    public class AuthorOutput : DtoBase
    {
        public string Name { get; set; }
        public string? WebUrl { get; set; }
    }
}
