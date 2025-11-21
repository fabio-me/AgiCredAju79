using AgiCredAju79.Repositories.Contexts;
using AgiCredAju79.Repositories.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AgiCredAju79.Services
{
    public class PagamentoService
    {
        private readonly DbContextMariaDB _context;

        public PagamentoService(DbContextMariaDB context)
        {
            _context = context;
        }

        public async Task Create(
            long emprestimoId,
            string? status,
            string? tipo,
            DateTime? data,
            decimal valor,
            decimal? desconto,
            string? descontoDescricao,
            string? comprovante)
        {
            try
            {
                Pagamento pagamento = new Pagamento
                {
                    EmprestimoId = emprestimoId,
                    Status = status,
                    Tipo = tipo,
                    Data = data,
                    Valor = valor,
                    Desconto = desconto,
                    DescontoDescricao = descontoDescricao,
                    Comprovante = comprovante
                };
                await _context.Pagamento.AddAsync(pagamento);
                await _context.SaveChangesAsync();
            }
            catch
            {
                //add log (Exception ex)
            }
        }

        public List<Pagamento> GetByEmprestimoId(long EmprestimoId)
        {
            if (EmprestimoId <=0) return new List<Pagamento>();
            return _context.Pagamento.Where(p => p.EmprestimoId == EmprestimoId).ToList();
        }
    }
}