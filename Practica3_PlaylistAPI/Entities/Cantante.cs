using Practica3_PlaylistAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practica3_PlaylistAPI.Entities
{
    public class Cantante
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; } = string.Empty;

        
        public ICollection<Cancion> Canciones { get; set; }
            = new List<Cancion>();

        public Cantante(string name)
        {
            Name = name;
        }
    }
}

