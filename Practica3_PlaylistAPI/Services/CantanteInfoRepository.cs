using Microsoft.EntityFrameworkCore;
using Practica3_PlaylistAPI.DbContexts;
using Practica3_PlaylistAPI.Entities;
using SQLitePCL;

namespace Practica3_PlaylistAPI.Services
{
    public class CantanteInfoRepository : ICantanteInfoRepository
    {
        private readonly CantanteInfoContext _context;
        public CantanteInfoRepository(CantanteInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Cantante>> GetCantantesAsync()
        {
            return await _context.Cantantes.OrderBy(c=>c.Name).ToListAsync();
        }

        public async Task<IEnumerable<Cantante>> GetCantantesAsync(string? name, string? searchQuery, int pageNumber, int pageSize)
        {
            
            var collection = _context.Cantantes as IQueryable<Cantante>;

            if (!string.IsNullOrWhiteSpace(name))
            {
                name = name.Trim();
                collection = collection.Where(c => c.Name == name); 
            }

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = searchQuery.Trim();
                collection.Where(c => c.Name.Contains(searchQuery));
            }
            
            return await collection.OrderBy(c => c.Name)
                .Skip(pageSize * (pageNumber-1))
                .Take(pageSize)
                .ToListAsync();
        }
        public async Task<Cantante?> GetCantanteAsync(int cantanteId, bool includeCanciones)
        {
            if (includeCanciones)
            {
                return await _context.Cantantes.Include(c => c.Canciones)
                    .Where(c => c.Id == cantanteId).FirstOrDefaultAsync();
            }
            return await _context.Cantantes
                    .Where(c => c.Id == cantanteId).FirstOrDefaultAsync();
        }
        public async Task<bool> CantanteExistsAsync(int cantanteId)
        {
            return await _context.Cantantes.AnyAsync(c => c.Id == cantanteId);
        }
        public async Task<Cancion?> GetCancionForCantanteAsync(int cantanteId, int cancionId)
        {
            return await _context.Canciones
                    .Where(d => d.CantanteId == cantanteId && d.Id == cancionId).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Cancion>> GetCancionesForCantanteAsync(int cantanteId)
        {
            return await _context.Canciones
                    .Where(d => d.CantanteId == cantanteId).ToListAsync();
        }

        public async Task AddCancionForCantanteAsync(int cantanteId, Cancion cancion)
        {
            var cantante = await GetCantanteAsync(cantanteId, false);
            if(cantante != null)
            {
                cantante.Canciones.Add(cancion);
            }
        }
        
        public void DeleteCancion(Cancion cancion)
        {
            _context.Canciones.Remove(cancion);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        
    }
}
