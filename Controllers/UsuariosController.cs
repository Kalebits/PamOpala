using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using OpalaAPIPam.Models;
using OpalaAPIPam.Models.Enuns;

namespace OpalaAPIPam.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuariosController : ControllerBase
    {
        private static List<Usuario> usuarios = new List<Usuario>(){
        new Usuario(){ Id = 1, Nome = "Pedro Silva", Email = "PedroS@gmail.com", Senha = "pedrinho123", Endereco = null, tipoEnum=TipoEnum.Fisica, generoEnum=GeneroEnum.Masculino},
        new Usuario(){ Id = 2, Nome = "Gustavo Henrique", Email = "gHenrique@gmail.com", Senha = "henrique123", Endereco = null, tipoEnum=TipoEnum.Fisica, generoEnum=GeneroEnum.Masculino}
       };


        //Chama todos
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(usuarios);
        }

        //Chama o primeiro, se quiser deletar pode deletar n sei
        [HttpGet("Get")]
        public IActionResult GetFirst()
        {
            Usuario u = usuarios[0];
            return Ok(u);
        }


        //GetById
        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            return Ok(usuarios.FirstOrDefault(u => u.Id == id));
        }


        //Cria um novo usuario
        [HttpPost]
        public IActionResult AddUsuario(Usuario novoUsuario)
        {
            try
            {
                var email = new MailAddress(novoUsuario.Email);
                usuarios.Add(novoUsuario);
                return Ok(usuarios);
            }
            catch
            {
                return BadRequest("Email Invalido");
            }

        }


        //Edita
        [HttpPut]
        public IActionResult UpdateUsuario(Usuario u)
        {
            Usuario uAlterado = usuarios.Find(usu => usu.Id == u.Id);
            uAlterado.Nome = u.Nome;
            uAlterado.Email = u.Email;
            uAlterado.Senha = u.Senha;
            uAlterado.Endereco = u.Endereco;

            return Ok(usuarios);
        }


        //deleta o id digitado
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            usuarios.RemoveAll(u => u.Id == id);

            return Ok(usuarios);
        }


        //Ordena de acordo com a avaliacao, na teoria, porem não sei como fazer, voce tem q pegar todas as notas registradas para 1 usuario, 
        // e dps disso fazer a média, seria algo do tipo List<Avaliacao> notas = (a => a.Usuario.Id == id)
        //                                               int avaliacao.count
        //                                               notaMed =
        // eu não consegui, mas acho que tu faz um count pra começar 1 método for e vai armazenando num +=, e isso na teoria, pra dps fazer a média e exibir de acordo com essa nota
        [HttpGet("GetOrdenado")]
        public IActionResult GetOrdem()
        {
            List<Usuario> listaFinal = usuarios.OrderBy(u => u.avaliacao.Nota).ToList();
            return Ok(listaFinal);
        }


        //Conta a quantidade de usuarios registrado no sistema
        [HttpGet("GetContagem")]
        public IActionResult GetQuantidade()
        {
            return Ok("Quantidade de usuarios: " + usuarios.Count);
        }


        //Vai procurar nomes parecidos com o solicitado tambem
        [HttpGet("GetByNome/{nome}")]
        public IActionResult GetByNome(string nome)
        {
            List<Usuario> listaBusca = usuarios.FindAll(u => u.Nome.Contains(nome));
            return Ok(listaBusca);
        }


        //Get a partir da nota pedida
        [HttpGet("GetByAvaliacao/{nota}")]
        public IActionResult Get(int nota)
        {
            List<Usuario> listaFinal = usuarios.FindAll(u => u.avaliacao.Nota >= nota);
            return Ok(listaFinal);
        }

        //Filtra de acordo com a enum (tipoEnum)
        [HttpGet("GetByTipo/{enumId}")]
        public IActionResult GetByTipo(int enumId)
        {
            TipoEnum enumDigitado = (TipoEnum)enumId;
            List<Usuario> listaBusca = usuarios.FindAll(u => u.tipoEnum == enumDigitado);
            return Ok(listaBusca);
        }
    }
}