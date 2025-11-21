using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgiCredAju79.Models;
using AgiCredAju79.Repositories.Contexts;
using AgiCredAju79.Repositories.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing;

namespace AgiCredAju79.Controllers
{
    public class NotaEmprestimoesController : Controller
    {
        private readonly DbContextMariaDB _context;

    
        public NotaEmprestimoesController(DbContextMariaDB context)
        {
            _context = context;
        }

        // GET: NotaEmprestimoes
        public async Task<IActionResult> Index()
        {
            string? login = Convert.ToString(HttpContext.Session.GetString("KEY-EEW-55D"));
            if (login != "true")
            {
                return Redirect("../Login");
            }

            return View(await _context.NotaEmprestimo.Where(e => e.Categoria == "EmDia").ToListAsync());
        }

        public async Task<IActionResult> NaoPagos()
        {
            string? login = Convert.ToString(HttpContext.Session.GetString("KEY-EEW-55D"));
            if (login != "true")
            {
                return Redirect("../Login");
            }

            return View(await _context.NotaEmprestimo.Where(e => e.Categoria == "NaoPago").ToListAsync());
        }
        
        public async Task<IActionResult> PromessasPAG()
        {
            string? login = Convert.ToString(HttpContext.Session.GetString("KEY-EEW-55D"));
            if (login != "true")
            {
                return Redirect("../Login");
            }

            return View(await _context.NotaEmprestimo.Where(e => e.Categoria == "PromessaPAG").ToListAsync());
        }

        public async Task<IActionResult> Perdidos()
        {
            string? login = Convert.ToString(HttpContext.Session.GetString("KEY-EEW-55D"));
            if (login != "true")
            {
                return Redirect("../Login");
            }

            return View(await _context.NotaEmprestimo.Where(e => e.Categoria == "Perdido").ToListAsync());
        }

        // GET: NotaEmprestimoes/Create
        public IActionResult Create()
        {
            string? login = Convert.ToString(HttpContext.Session.GetString("KEY-EEW-55D"));
            if (login != "true")
            {
                return Redirect("../Login");
            }

            return View();
        }

        // POST: NotaEmprestimoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Categoria,DataDoAcordo,Nome, CPF,Celular,Indicacao,TipoDeEmprestimo,DataDoPagamento,ValorDoEmprestimo,JuroMensalPorcentagem,Armotizado,JurosPagosTotal,ListaParcelasPagas,DataDoUltimoPagamento,DataDePromessaDePagamento,Observacao")] NotaEmprestimo notaEmprestimo)
        {
            string? login = Convert.ToString(HttpContext.Session.GetString("KEY-EEW-55D"));
            if (login != "true")
            {
                return Redirect("../Login");
            }

            if (ModelState.IsValid)
            {
                notaEmprestimo.Categoria = "EmDia";
                _context.Add(notaEmprestimo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(notaEmprestimo);
        }

        // GET: NotaEmprestimoes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            string? login = Convert.ToString(HttpContext.Session.GetString("KEY-EEW-55D"));
            if (login != "true")
            {
                //return Redirect("../Login");
            }

            if (id == null)
            {
                return NotFound();
            }

            var notaEmprestimo = await _context.NotaEmprestimo.FindAsync(id);
            if (notaEmprestimo == null)
            {
                return NotFound();
            }

            decimal? valorEmAberto = notaEmprestimo.ValorDoEmprestimo - notaEmprestimo.Armotizado;
            ViewBag.valorEmAberto = valorEmAberto;

            ViewBag.valorAPagarHoje = (valorEmAberto * notaEmprestimo.JuroMensalPorcentagem) / 100;

            return View(notaEmprestimo);
        }

        // POST: NotaEmprestimoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, decimal? valorPago, [Bind("Id,Categoria,DataDoAcordo,Nome, CPF,Celular,Indicacao,TipoDeEmprestimo,DataDoPagamento,ValorDoEmprestimo,DataDoEmprestimo,JuroMensalPorcentagem,Armotizado,JurosPagosTotal,ListaParcelasPagas,DataDoUltimoPagamento,DataDePromessaDePagamento,Observacao")] NotaEmprestimo notaEmprestimo)
        {
            string? login = Convert.ToString(HttpContext.Session.GetString("KEY-EEW-55D"));
            if (login != "true")
            {
                return Redirect("../Login");
            }

            if (id != notaEmprestimo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (valorPago >= 0.01m)
                    {
                        decimal? valorEmAberto = notaEmprestimo.ValorDoEmprestimo - notaEmprestimo.Armotizado;
                        decimal? valorAPagarHoje = (valorEmAberto * notaEmprestimo.JuroMensalPorcentagem) / 100;

                        if (valorPago > valorAPagarHoje)
                        {
                            decimal? diferenca = valorPago - valorAPagarHoje;
                            notaEmprestimo.Armotizado += diferenca ?? notaEmprestimo.Armotizado;
                        }
                        notaEmprestimo.JurosPagosTotal += valorPago ?? notaEmprestimo.JurosPagosTotal;
                    }

                    _context.Update(notaEmprestimo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotaEmprestimoExists(notaEmprestimo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                if (notaEmprestimo.Categoria == "NaoPago") return RedirectToAction("NaoPagos");
                if (notaEmprestimo.Categoria == "PromessaPAG") return RedirectToAction("PromessasPAG");
                if (notaEmprestimo.Categoria == "Perdido") return RedirectToAction("Perdidos");
                return RedirectToAction(nameof(Index));
            }
            return View(notaEmprestimo);
        }

        private bool NotaEmprestimoExists(long id)
        {
            return _context.NotaEmprestimo.Any(e => e.Id == id);
        }
    }
}
