using AutoMapper;
using EnderecoService.DTOs;
using EnderecoService.Models;

namespace EnderecoService.Ioc
{
    public class MapConfigProfile : Profile
    {
        public MapConfigProfile()
        {
            CreateMap<EnderecoModel, EnderecoDTO>().ReverseMap();
        }
    }
}
