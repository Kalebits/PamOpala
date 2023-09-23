using OpalaAPIPam.Models.Enuns;

namespace OpalaAPIPam.Models{

    public class Usuario{
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Senha { get; set; }
        public long? Telefone { get; set; }
        public String Endereco { get; set; }
        public TipoEnum tipoEnum { get; set; }
        public GeneroEnum generoEnum { get; set; }
        public Instrumento? instrumento { get; set; }
        public Banda? banda { get; set; }
        public Contrato? contrato { get; set; }
        public Avaliacao? avaliacao { get; set; }
        
    }
}