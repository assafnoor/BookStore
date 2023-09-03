using AutoMapper;
using BookStore.Dto;
using BookStore.Models;

namespace BookStore.Helpers
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {

            CreateMap<Book, BookDetailsDto>()
             .ForMember(dest => dest.author, opt => opt.MapFrom(src => src.author.Name));
            CreateMap<Author, AuthorDetailsDto>()
              .ForMember(dest => dest.books, opt => opt.MapFrom(src => src.books.Select(b => b.Title).ToList()));

            //  CreateMap<Book, BookDetailsDto>();
            //   CreateMap<MovieDto, Movie>().ForMember(src => src.Poster, opt => opt.Ignore());
        }
    }
}
