using AutoMapper;
using Movies.Models.Contracts;
using Movies.Models.Requests;

namespace Movies.WebAPI.Mapping
{
    public class MovieMappingProfile : Profile
    {
        public MovieMappingProfile()
        {
            CreateMap<AddMovieRequest, MoviesStructure>()
                .ForMember(
                    dest => dest.Director,
                    opt => opt.MapFrom(src => src.Director)
                )
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.Name)
                )
                .ForMember(
                    dest => dest.Actors,
                    opt => opt.MapFrom(src => src.Actors)
                );
        }
    }
}