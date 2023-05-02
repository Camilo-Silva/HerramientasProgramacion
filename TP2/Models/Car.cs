using System.ComponentModel.DataAnnotations;
using TP2.Utils;

namespace TP2.Models;

public class Car
{
    public int Id { get; set; }
    public int MotorId { get; set; }
    // Referencia one to one Motor Motor - Un Auto solo puede tener un motor y Visceversa
    // Un Motor solo puede tener un Auto
    public Motor Motor { get; set; }
    // ForeignKey de Brand
    public int BrandId { get; set; }
    // Navegacion de referencia Brand, en este caso la Class Car es la dependiente (child)
    public Brand Brand { get; set; }
    
    public List<Accessory> Accessories { get; } = new List<Accessory>();
    
}