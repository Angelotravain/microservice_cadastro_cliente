using AutoMapper;
using ClienteService.DTOs;
using ClienteService.Models;

namespace ClienteService.Ioc
{
    public class MapConfigProfile : Profile
    {
        public MapConfigProfile()
        {
            CreateMap<ClienteModel, ClienteDTO>().ReverseMap();
        }
    }
}
