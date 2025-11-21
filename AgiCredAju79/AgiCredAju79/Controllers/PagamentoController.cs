using AgiCredAju79.Repositories.Models;
using AgiCredAju79.Services;
using Microsoft.AspNetCore.Mvc;

namespace AgiCredAju79.Controllers
{
    public class PagamentoController : Controller
    {
        private readonly PagamentoService _pagamentoService;

        public PagamentoController(PagamentoService pagamentoService)
        {
            _pagamentoService = pagamentoService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            long emprestimoId,
            string? tipo,
            DateTime? data,
            decimal valor,
            decimal? desconto,
            string? descontoDescricao)
        {
            try
            {
                await _pagamentoService.Create(emprestimoId, "pago", tipo, data, valor, desconto, descontoDescricao, null);
                return Json(new { result = true });
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao criar pagamento: {ex.Message}");
            }
        }

        public List<Pagamento> GetByEmprestimoId(long EmprestimoId)
        {
            try
            {
                return _pagamentoService.GetByEmprestimoId(EmprestimoId);
            }
            catch
            {
                return new List<Pagamento>();
            }
        }
    }
}
