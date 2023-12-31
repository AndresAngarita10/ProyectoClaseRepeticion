

using API.Dtos;
using AutoMapper;
using Dominio.Entities;

namespace API.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pais,PaisDto>().ReverseMap().ForMember(o => o.Departamentos, d => d.Ignore());
            
            CreateMap<Departamento,DepartamentoDto>().ReverseMap().ForMember(o => o.Ciudades, d => d.Ignore());

            CreateMap<Ciudad,CiudadDto>().ReverseMap().ForMember(o => o.Personas, d => d.Ignore());
            CreateMap<Pais,PaisxDepDto>().ReverseMap();
        }
    }
}