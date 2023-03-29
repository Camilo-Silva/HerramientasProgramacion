// Para modelar el proyecto

using System.ComponentModel.DataAnnotations;

namespace Class3.Models;

public class Movie{
    // Prop + Tab genera una propiedad
    public string Code { get; set; }

    [Display(Name="Nombre")]
    [Required]
    public string Name { get; set; }
    [Range(5,600)]
    public int Minutes { get; set; }
    public string Category { get; set; }
    public string Review { get; set; }    
}