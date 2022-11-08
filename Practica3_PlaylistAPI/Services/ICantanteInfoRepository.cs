using Practica3_PlaylistAPI.Entities;

namespace Practica3_PlaylistAPI.Services
{
    public interface ICantanteInfoRepository
    {
        Task<IEnumerable<Cantante>> GetCantantesAsync();
        Task<IEnumerable<Cantante>> GetCantantesAsync(string? name, string? searchQuery, int pageNumber, int pageSize);
        Task<Cantante?> GetCantanteAsync(int cantanteId, bool includeCanciones);
        Task<bool> CantanteExistsAsync(int cantanteId);
        Task<IEnumerable<Cancion>> GetCancionesForCantanteAsync(int cantanteId);
        Task<Cancion?> GetCancionForCantanteAsync(int cantanteId, int cancionId);
        Task AddCancionForCantanteAsync(int cantanteId, Cancion cancion);
        void DeleteCancion(Cancion cancion);
        Task<bool> SaveChangesAsync();
    }
}
