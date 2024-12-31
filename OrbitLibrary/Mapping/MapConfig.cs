using AutoMapper;
using AutoMapper.Configuration;
using OrbitLibrary.Data.Entities;
using OrbitLibrary.Dto.AuthorDto;
using OrbitLibrary.Dto.BookDto;

namespace OrbitLibrary.Mapping
{
    public class MapConfig : Profile
    {
        public MapConfig()
        {
            CreateMap<BookInput, Book>();
            CreateMap<AuthorInput, Author>();
            CreateMap<Author, AuthorOutput>();
            CreateMap<Book, BookOutput>()
                .ForMember((BookOutput b) => b.Authors,
                op => op.MapFrom((Book b, BookOutput o) =>
                b.Authors.Select(x => x.Author.Name)));
        }
    }
}
