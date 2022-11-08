namespace Practica3_PlaylistAPI.Models
{
    public class CantanteDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        
        public int NumberOfCanciones
        {
            get
            {
                return Canciones.Count;
            }
        }
        public ICollection<CancionDto> Canciones { get; set; }
            = new List<CancionDto>();
    }
}
