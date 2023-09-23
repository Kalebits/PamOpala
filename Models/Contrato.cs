namespace OpalaAPIPam.Models
{
    public class Contrato
    {
        public int Id { get; set; }
        public DateTime? Dt_Cont { get; set; }
        public int duracao { get; set; }
        public DateTime? Dt_Apresentacao { get; set; }
        public Usuario usuario { get; set; }
    }
}