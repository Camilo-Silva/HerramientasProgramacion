// Se usa para tener la logica de negocio y nos brinde acceso a datos con clases y metodos.
using Class4.Models;
namespace Class4.Services;

// Clase estatica para que las propiedades sean estaticas a usar para el CRUD
public static class MovieService
{
    static List<Movie> Movies { get; set; }
    static MovieService()
    {
        Movies = new List<Movie>
        {
            new Movie{ Name = "Back to the future", Code = "BTF", Category = "Sci fi", Minutes = 110},
            new Movie{ Name = "Avatar", Code = "AVT", Category = "Sci fi", Minutes = 500, Review = "Buenos efectos, pero muy larga"},
            new Movie{ Name = "Hannibal", Code = "HNL", Category = "Terror", Minutes = 500},
            new Movie{ Name = "Super man", Code = "SPM", Category = "Accion", Minutes = 110},
            new Movie{ Name = "Esperando La Carroza", Code = "ELC", Category = "Comedy", Minutes = 500},
            new Movie{ Name = "Argentina 1985", Code = "ARG", Category = "Drama", Minutes = 210},
            new Movie{ Name = "El Padrino", Code = "ELP", Category = "Drama", Minutes = 310}
        };
    }
    // Metodos
    public static List<Movie> GetAll() => Movies;
    public static void Add(Movie obj)
    {
        if (obj == null)
        {
            return;
        }
        Movies.Add(obj);
    }
    public static void Delete(string code)
    {
        var movieToDelete = Get(code);

        if (movieToDelete != null)
        {
            Movies.Remove(movieToDelete);
        }
    }
    // firstOrDefaul para buscar en una lista, es como si fuera un foreach
    // Metodo para buscar el codigo de las peliculas
    public static Movie? Get(string code) => Movies.FirstOrDefault(x => x.Code.ToLower() == code.ToLower());
    // ADD
    // Delete
    // Update
}
