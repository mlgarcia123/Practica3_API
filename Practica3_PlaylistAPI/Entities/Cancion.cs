using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Practica3_PlaylistAPI.Entities
{
    public class Cancion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        public int Estreno { get; set; }
        
        [ForeignKey("CantanteId")]
        public Cantante? Cantante { get; set; }
        public int CantanteId { get; set; }
       
        public Cancion(string name)
        {
            Name = name;
        }
    }
}
