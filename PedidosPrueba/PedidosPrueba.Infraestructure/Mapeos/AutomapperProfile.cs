using AutoMapper;
using PedidosPrueba.Core.Dtos;
using PedidosPrueba.Core.Entidades;

namespace PedidosPrueba.Infraestructure.Mapeos
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Usuarios, LoginDto>().ReverseMap();

            CreateMap<Usuarios, UsuariosDto>().ReverseMap();

            CreateMap<Pedidos, PedidosDto>().ReverseMap();

            CreateMap<Respuesta, RespuestaDto>().ReverseMap();
        }
    }
}