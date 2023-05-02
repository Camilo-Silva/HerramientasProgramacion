namespace TP2.Models;

public class Accessory
{
    public int Id { get; set; }
    public int Name { get; set; }
    public decimal Price { get; set; }
    public List<Car> Cars { get; } = new List<Car>();
}