// Son necesarios para modelar nuestras vistas - Views
// Se personaliza con los datos que le queramos mostrar al usuario
using Class6.Models;

namespace Class6.ViewModels;

public class MenuViewModel
{
    public List<Menu> Menus { get; set; } = new List<Menu>();
    
    public string? NameFilter { get; set; }    
}