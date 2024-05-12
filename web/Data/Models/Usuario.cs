using System.ComponentModel.DataAnnotations;

namespace InventarioFIIAPP.Data.Models;

public class Usuario {
    [Key]
    public int IdUsuario { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "Nombre es obligatorio")]
    public string Nombre { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "Apellidos es obligatorio")]
    public string Apellidos { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "Email es obligatorio")]
    public string Email { get; set; }
}