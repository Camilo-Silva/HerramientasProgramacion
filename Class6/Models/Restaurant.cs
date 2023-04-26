using Class6.Utils;

namespace Class6.Models;

public class Restaurant
{
    public int Id { get; set; }
    public string Name { get; set; }    
    public string Address { get; set; }
    public string Mail { get; set; }
    public string Phone { get; set; }
    // MenuId es el foreignkey
    public int MenuId { get; set; }
    // Propiedad virtual para usarse en el entityFramework para traer el menu del restaurante
    public virtual Menu Menu { get; set; }
}