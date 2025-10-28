using AutoMapper;
using MinhaApp.Application.DTOs;
using MinhaApp.Domain.Entities;

namespace MinhaApp.Application.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ExemploEntity, ExemploDto>().ReverseMap();
        }
    }
}