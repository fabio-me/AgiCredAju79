namespace AgiCredAju79.Repositories.Models
{
    public class Cadastro
    {
        public long Id { get; set; }
        public string? Status { get; set; }

        public string? CPFStatus { get; set; }
        public string? CPF { get; set; }

        public string? NomeStatus { get; set; }
        public string? Nome { get; set; }

        public string? DataDeNascimentoStatus { get; set; }
        public DateTime? DataDeNascimento { get; set; }

        public string? EmailStatus { get; set; }
        public string? Email { get; set; }

        public decimal? LimiteDeSolicitacaoDeEmprestimoValor { get; set; }
        public long? CadastroIdIndicacao { get; set; }
        public long? CadastroIdIndicacaoAvalista { get; set; }

        public string? EnderecoStatus { get; set; }
        public string? EnderecoIdPrincipal { get; set; }
        public List<CadastroEndereco>? CadastroEndereco { get; set; }

        public string? CadastroNumeroDeContatoStatus { get; set; }
        public string? CadastroNumeroDeContatoIdPrincipal { get; set; }
        public List<CadastroNumeroDeContato>? CadastroNumeroDeContato { get; set; }
    }
}
