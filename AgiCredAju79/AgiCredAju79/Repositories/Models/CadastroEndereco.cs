namespace AgiCredAju79.Repositories.Models
{
    public class CadastroEndereco
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
        public long CadastroId { get; set; }

        // # Brasil
        public string? NomeDeIdentificacao { get; set; }

        public string? CEP { get; set; }

        public string? Logradouro { get; set; } // (Rua, Avenida, Travessa, etc.)

        public string? Numero { get; set; }

        public string? Complemento { get; set; } // (Apto, Bloco, Sala, Casa, etc. – opcional)

        public string? BairroOuDistrito{ get; set; }

        public string? Cidade { get; set; }

        public string? Estado { get; set; }

        public string? Pais { get; set; }

        public string? LinkDoMapa { get; set; }

        public string? ComprovanteDeEnderecoPATH { get; set; }
    }
}
