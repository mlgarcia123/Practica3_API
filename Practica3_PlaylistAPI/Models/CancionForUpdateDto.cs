using System.ComponentModel.DataAnnotations;

namespace Practica3_PlaylistAPI.Models
{
    public class CancionForUpdateDto
    {
        [Required(ErrorMessage = "Debes introducir un nombre")]
        [MaxLength(30)]
        public string Name { get; set; } = string.Empty;

        public int Estreno { get; set; }
    }
       
}
