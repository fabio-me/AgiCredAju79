namespace AgiCredAju79.Repositories.Models
{
    public class Emprestimo
    {
        public long Id { get; set; }
        public long CadastroId { get; set; }
        public long? CadastroResponsavelId { get; set; }
        public long? CadastroIndicacaoId { get; set; }


        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public string? CelularPrincipal { get; set; }

        public string? Categoria { get; set; }
        public string? TipoDeEmprestimo { get; set; }
        public decimal ValorDoEmprestimo { get; set; }
        public int? JuroMensalPorcentagem { get; set; }
        public DateTime? DataDoEmprestimo { get; set; }
        public int? DiaDoPagamento { get; set; }
        public DateTime? DataDoUltimoPagamento { get; set; }

        public DateTime? DataDoAcordo { get; set; }
        public DateTime? DataDePromessaDePagamento { get; set; }

        public string? Observacao { get; set; }
    }
}
