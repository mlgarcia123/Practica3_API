using AutoMapper;

namespace Practica3_PlaylistAPI.Profiles
{
    public class CantanteProfile : Profile
    {
        public CantanteProfile()
        {
            CreateMap<Entities.Cantante, Models.CantanteWithoutCancionesDto>();
            CreateMap<Entities.Cantante, Models.CantanteDto>();
        }
    }
}
