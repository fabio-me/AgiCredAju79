namespace AgiCredAju79.Repositories.Models
{
    public class Pagamento
    {
        public long Id { get; set; }
        public long EmprestimoId { get; set; }
        public string? Status { get; set; }
        public string? Tipo { get; set; }
        public DateTime? Data { get; set; }
        public decimal Valor { get; set; }
        public decimal? Desconto { get; set; }
        public string? DescontoDescricao { get; set; }
        public string? Comprovante { get; set; }
    }
}
