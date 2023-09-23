namespace OpalaAPIPam.Models
{
    public class Banda
    {
        public int Id { get; set; }
        public String nomeBanda { get; set; }
        public String estilo { get; set; }
        public Usuario usuario { get; set; }
    }
}