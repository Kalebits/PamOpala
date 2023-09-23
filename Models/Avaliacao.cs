namespace OpalaAPIPam.Models
{
    public class Avaliacao
    {
        public int Id { get; set; }
        public String Comentario { get; set; }
        public double Nota { get; set; }
        public Usuario usuario { get; set; }
    }
}