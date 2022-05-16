using AutoMapper;
using TP2_REST_Domain.Dtos;
using TP2_REST_Domain.Entities;

namespace TP2_REST_Damico_Claudio.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Libro, LibroDto>().ReverseMap();
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<Alquiler, AlquilerDto>().ReverseMap();
            CreateMap<Alquiler, ModifyAlquilerDto>().ReverseMap();
            CreateMap<Alquiler, GetLibrosByClienteDto>()
                .ForMember(dest => dest.Titulo, opt => 
                    opt.MapFrom(so => so.IsbnNavigation.Titulo))
                .ForMember(dest => dest.ISBN, opt =>
                    opt.MapFrom(so => so.IsbnNavigation.ISBN))
                .ForMember(dest => dest.Imagen, opt =>
                    opt.MapFrom(so => so.IsbnNavigation.Imagen))
                .ForMember(dest => dest.Autor, opt =>
                    opt.MapFrom(so => so.IsbnNavigation.Autor))
                .ForMember(dest => dest.Edicion, opt =>
                    opt.MapFrom(so => so.IsbnNavigation.Edicion))
                .ForMember(dest => dest.Editorial, opt =>
                    opt.MapFrom(so => so.IsbnNavigation.Editorial));
            CreateMap<Alquiler, GetAlquilerByEstadoIdDto>().ReverseMap();
        }
    }
}
