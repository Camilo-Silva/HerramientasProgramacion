// Son necesarios para modelar nuestras vistas - Views
// Se personaliza con los datos que le queramos mostrar al usuario
using System.ComponentModel.DataAnnotations;
using Class6.Models;

namespace Class6.ViewModels;

public class MenuDetailViewModel
{
    public int Id { get; set; }   
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Type { get; set; }
    [Display(Name="Es Vegetariano")]
    public bool IsVegetarianType { get; set; } = false;

    public int Calories { get; set; }
    // Relacionamos la lista de Restaurantes con el Menu
    public virtual List<Restaurant> Restaurants { get; set; } 
}