namespace AgiCredAju79.Repositories.Models
{
    public class CadastroNumeroDeContato
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
        public long CadastroId { get; set; }
        public string? NomeDeIdentificacao { get; set; }
        public string? Numero {  get; set; }
    }
}
