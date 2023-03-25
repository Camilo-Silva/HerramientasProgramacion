// Creamos models
using System.ComponentModel.DataAnnotations;
// importamos using System
public class Form
{
    // Generamos propiedades
    [Required]
    [Display(Name = "Email")]
    public string Mail { get; set; }

    [Required]
    [Display(Name = "Contraseña")]
    public string Password { get; set; }
}