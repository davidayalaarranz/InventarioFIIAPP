using System.ComponentModel.DataAnnotations;

namespace InventarioFIIAPP.Models;

public class Usuario {
    [Key]
    public int IdUsuario { get; set; }
    public string? Nombre { get; set; }
    public string? Apellidos { get; set; }
    public string? Email { get; set; }
}