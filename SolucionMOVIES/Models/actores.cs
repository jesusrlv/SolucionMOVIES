using System.ComponentModel.DataAnnotations;
namespace SolucionMOVIES.Models
{
    public class actores
    {
        public int idActores { get; set; }
        [Required(ErrorMessage ="El campo nombre es obligatorio")]
        public string? nombre { get; set; }
    }

    public class genero
    {
        public int idGenero { get; set; }
        public string? nombre { get; set; }
    }

    public class participaciones
    {
        public int idParticipaciones { get; set; }
        public int peli { get; set; }
        public int actor { get; set; }
        public int genero { get; set; }
    }
    
    public class peliculas
    {
        public int idPelicula { get; set; }
        public string? pelicula { get; set; }
        public int genero { get; set; }
    }

    public class ListadoCompleto
    {
        public string? ACTOR { get; set; }
        public string? PELICULA { get; set; }
        public string? GENERO { get; set; }
    }




}