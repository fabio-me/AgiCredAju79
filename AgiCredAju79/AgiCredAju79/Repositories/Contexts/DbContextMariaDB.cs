using AgiCredAju79.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace AgiCredAju79.Repositories.Contexts
{
    public class DbContextMariaDB : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // String de conexão
                var connectionString = "server=localhost;user=root;password=123;database=agi_credAju_79_filipe";
                var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));

                // Configurar o provedor do MySQL
                optionsBuilder.UseMySql(connectionString, serverVersion)
                    //.LogTo(Console.WriteLine, LogLevel.Information) // Log para depuração
                    //.EnableSensitiveDataLogging() // Log de dados sensíveis (apenas para desenvolvimento)
                    .EnableDetailedErrors(); // Erros detalhados (apenas para desenvolvimento)
            }
        }

        public DbSet<Cadastro> Cadastro { get; set; }
        public DbSet<CadastroNumeroDeContato> CadastroNumeroDeContato { get; set; }
        public DbSet<CadastroEndereco> CadastroEndereco { get; set; }

        public DbSet<NotaEmprestimo> NotaEmprestimo { get; set; }
        public DbSet<Emprestimo> Emprestimo { get; set; }
        public DbSet<Pagamento> Pagamento { get; set; }
    }
}
