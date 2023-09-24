using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpalaAPIPam.Data;
using OpalaAPIPam.Models;
using OpalaAPIPam.Models.Enuns;

namespace OpalaAPIPam.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly DataContext _context;

        public UsuariosController(DataContext context)
        {
            _context = context;
        }


        //Chama todos
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Usuario> lista = await _context.Usuarios.ToListAsync();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //GetById
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Usuario u = await _context.Usuarios.FirstOrDefaultAsync(uBusca => uBusca.Id == id);
                return Ok(u);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //Cria um novo usuario
        [HttpPost]
        public async Task<IActionResult> AddUsuario(Usuario novoUsuario)
        {
            try
            {
                var email = new MailAddress(novoUsuario.Email);
                
                try
                {
                    await _context.Usuarios.AddAsync(novoUsuario);
                    await _context.SaveChangesAsync();

                    return Ok(novoUsuario.Id);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }
            catch
            {
                return BadRequest("Email Invalido");
            }

        }


        //Edita
        [HttpPut]
        public async Task<IActionResult> UpdateUsuario(Usuario u)
        {
            try{
                var email = new MailAddress(u.Email);
                try
                {
                    _context.Usuarios.Update(u);
                    int linhasAfetadas = await _context.SaveChangesAsync();

                    return Ok(linhasAfetadas);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            catch{
                return BadRequest("Email Invalido");
            }
        }


        //deleta o id digitado
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try{
                Usuario uRemover = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);

                _context.Usuarios.Remove(uRemover);
                int linhasAfetadas = await _context.SaveChangesAsync();
                return Ok(linhasAfetadas);
            }
            catch(System.Exception ex){
                return BadRequest(ex.Message);
            }
        }


        /*Ordena de acordo com a avaliacao, na teoria, porem não sei como fazer, voce tem q pegar todas as notas registradas para 1 usuario, 
         e dps disso fazer a média, seria algo do tipo List<Avaliacao> notas = (a => a.Usuario.Id == id)
                                                       int avaliacao.count
                                                       notaMed =
         eu não consegui, mas acho que tu faz um count pra começar 1 método for e vai armazenando num +=, e isso na teoria, pra dps fazer a média e exibir de acordo com essa nota*/
        /*  [HttpGet("GetOrdenado")]
          public async Task<IActionResult> GetOrdem()
          {
            try{
                List<Usuario> lista = await _context.Usuarios.ToListAsync();
                return Ok(lista); CARA AQUI EU NÃO SEI OQ FAZER REAL
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
              List<Usuario> listaFinal = usuarios.OrderBy(u => u.avaliacoes).ToList();
              return Ok(listaFinal);
          }*/


        //Conta a quantidade de usuarios registrado no sistema
        [HttpGet("GetContagem")]
        public async Task<IActionResult> GetQuantidade()
        {
            try
            {
               int quantidade = _context.Usuarios.Count();
               return Ok(quantidade);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }


        //Vai procurar nomes parecidos com o solicitado tambem
        /*[HttpGet("GetByNome/{nome}")]
        public IActionResult GetByNome(string nome)
        {
            List<Usuario> listaBusca = _context.Usuarios.ToListAsync(_context.Usuarios.Contains(nome));
            return Ok(listaBusca);
        }*/

        /*
                //Get a partir da nota pedida
                [HttpGet("GetByAvaliacao/{nota}")]
                public IActionResult Get(int nota)
                {
                    List<Usuario> listaFinal = usuarios.FindAll(u => u.avaliacoes.Contains(nota))
                    return Ok(listaFinal);
                }*/

        //Filtra de acordo com a enum (tipoEnum)
        [HttpGet("GetByTipo/{enumId}")]
        public async Task<IActionResult> GetByTipo(int enumId)
        {
            try
            {
                //Usuario u = await _context.Usuarios.FirstOrDefaultAsync(uBusca => uBusca.Id == id);
                //Usuario u = await _context.Usuarios.All(uBusca => uBusca.tipoEnum.Equals == enumId);
                Usuario u = await _context.Usuarios.Find(uBusca => uBusca.tipoEnum.Equals == enumId);
                return Ok(u);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
    }
}