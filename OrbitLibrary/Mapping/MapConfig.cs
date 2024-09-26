using AutoMapper;
using AutoMapper.Configuration;
using OrbitLibrary.Data.Entities;
using OrbitLibrary.Dto.BookDto;

namespace OrbitLibrary.Mapping
{
    public class MapConfig : Profile
    {
        public MapConfig()
        {
            CreateMap<BookInput, Book>();
        }
    }
}
