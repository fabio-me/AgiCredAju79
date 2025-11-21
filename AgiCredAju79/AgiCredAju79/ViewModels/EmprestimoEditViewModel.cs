using AgiCredAju79.Repositories.Models;

namespace AgiCredAju79.ViewModels
{
    public class EmprestimoEditViewModel
    {
        public required Emprestimo Emprestimo { get; set; }

        public List<Pagamento>? PagamentoList { get; set; }
    }
}
