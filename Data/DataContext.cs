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
                new Usuario(){ Id = 1, Nome = "Pedro Silva", Email = "PedroS@gmail.com", Senha = "pedrinho123", Endereco = null, tipoEnum=TipoEnum.Fisica, generoEnum=GeneroEnum.Masculino},
                new Usuario(){ Id = 2, Nome = "Gustavo Henrique", Email = "gHenrique@gmail.com", Senha = "henrique123", Endereco = null, tipoEnum=TipoEnum.Fisica, generoEnum=GeneroEnum.Masculino}
            );
        }
    }
}