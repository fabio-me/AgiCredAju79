namespace AgiCredAju79.Repositories.Models
{
    public class NotaEmprestimo
    {
        public long Id { get; set; }
        public string? Categoria { get; set; }
        public DateTime? DataDoAcordo { get; set; }
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public string? Celular { get; set; }
        public string? Indicacao { get; set; }
        public string? TipoDeEmprestimo { get; set; }
        public DateTime? DataDoPagamento { get; set; }
        public decimal ValorDoEmprestimo { get; set; }
        public DateTime? DataDoEmprestimo { get; set; }
        public int? JuroMensalPorcentagem { get; set; }
        public decimal Armotizado { get; set; }
        public decimal JurosPagosTotal { get; set; }
        public string? ListaParcelasPagas { get; set; }
        public DateTime? DataDoUltimoPagamento { get; set; }
        public DateTime? DataDePromessaDePagamento { get; set; }
        public string? Observacao { get; set; }
    }
}
