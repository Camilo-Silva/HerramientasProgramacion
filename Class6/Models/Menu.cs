using System.ComponentModel.DataAnnotations;
using Class6.Utils;

namespace Class6.Models;

public class Menu
{
    public int Id { get; set; }
    [Display(Name = "Nombre")]
    public string Name { get; set; }
    [Display(Name = "Precio")]
    public decimal Price { get; set; }
    [Display(Name = "Tipo")]
    public MenuType Type { get; set; }

    [Display(Name = "Es Vegetariano")]
    public bool IsVegetarianType { get; set; } = false;
    [Display(Name = "Calorias")]
    public int Calories { get; set; }
    // Relacionamos la lista de Restaurantes con el Menu
    public virtual List<Restaurant> Restaurants { get; set; }
}