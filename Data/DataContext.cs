using Microsoft.EntityFrameworkCore;
using OpalaAPIPam.Models;
using OpalaAPIPam.Models.Enuns;

namespace OpalaAPIPam.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Usuario> Usuarios{get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasData
            (
                new Usuario(){ Id = 1, Nome = "Pedro Silva", Email = "PedroS@gmail.com", Senha = "pedrinho123", Endereco = string.Empty, tipoEnum=TipoEnum.Fisica, generoEnum=GeneroEnum.Masculino},
                new Usuario(){ Id = 2, Nome = "Gustavo Henrique", Email = "gHenrique@gmail.com", Senha = "henrique123", Endereco = string.Empty, tipoEnum=TipoEnum.Fisica, generoEnum=GeneroEnum.Masculino}
            );

            Banda banda = new Banda();
            banda.Id = 1;
            banda.nomeBanda = "Chitaozinho e Xororo";
            banda.estilo = "Brega Romantico";
            banda.usuario.Id = 1;
            
            modelBuilder.Entity<Banda>().HasData(banda);
        }
    }
}