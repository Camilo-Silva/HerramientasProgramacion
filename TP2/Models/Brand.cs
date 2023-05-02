namespace TP2.Models;

// ENTIDAD PRINCIPAL DE ONE TO MANY (Brand and Car)
public class Brand
{
    public int Id { get; set; }
    public int Name { get; set; }
    // Navegacion de recopilacion hacia la Class Car
    public virtual ICollection<Car> Cars { get; } = new List<Car>();
}