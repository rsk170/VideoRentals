using AutoMapper;
using Vidly.Dtos;
using Vidly.Entities.Models;
using Vidly.Services.Dto;
using Vidly.ViewModels;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<CustomerViewModel, CustomerDto>();

            Mapper.CreateMap<Customer, CustomerViewModel>();
            Mapper.CreateMap<CustomerViewModel, Customer>();

            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>().ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<Genre, GenreDto>();
        }
    }
}