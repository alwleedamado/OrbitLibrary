using OrbitLibrary.Mapping;

namespace OrbitLibrary.Dto.BookDto
{
    public class BookOutput : DtoBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> Authors { get; set; }
    }
}
