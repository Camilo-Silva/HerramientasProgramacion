namespace TP2.Models;

public class Motor
{
    public int Id { get; set; }
    public int Number { get; set; }
    public string Descripcion { get; set; }
    public int CarId { get; set; }
    // Referencia one to one Motor Motor - Un Auto solo puede tener un motor y Visceversa
    // Un Motor solo puede tener un Auto 
    public virtual Car Car { get; set; }
    public int BrandId { get; set; }
    public virtual Brand Brand { get; set; }
}
