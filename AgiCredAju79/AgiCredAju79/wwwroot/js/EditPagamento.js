function checkboxAreaPagamentoDesconto() {
    let checkboxAreaPagamento = document.querySelector("#checkbox-area-pagamento-desconto").checked;

    if (checkboxAreaPagamento) {
        document.querySelector("#area-pagamento-desconto").style.display = "block";
        return;
    }
    document.querySelector("#area-pagamento-desconto").style.display = "none";
}

function isNumber(n) {
    return !isNaN(parseFloat(n)) && isFinite(n);
}

function isDate(valor) {
    const data = new Date(valor);
    return !isNaN(data);
}

function submitAnimationPagamentoDivBtn(name) {
    if (name == null || name  == "") return;
    document.querySelector("#pagamentoDivBtn").innerHTML = `<a class="btn btn-primary" style="background-color: #949494;border-color: #ffffff;">${name}</a>`;
}

function setPagamento() {
    let emprestimoId  = document.querySelector("#Id").value;
    let pagamentoTipo  = document.querySelector("#pagamento-tipo").value;
    let pagamentoData  = document.querySelector("#pagamento-data").value;
    let pagamentoValor = document.querySelector("#pagamentoValor").value;
    let pagamentoDesconto = document.querySelector("#pagamentoDesconto").value;
    let pagamentoDescontoDescricao = document.querySelector("#pagamentoDescontoDescricao").value;


    // EMPRESTMO ID
   try {
        if (emprestimoId.length <= 0) return;
    } catch (error) {
        return;
    }

   // TIPO DO PAGAMENTO
   try {
        if (pagamentoTipo.length <= 0) return;
   } catch (error) {
        return;
   }

    // DATA
    if (!isDate(pagamentoData)) return;

   // VALOR DO PAGAMENTO
   if( !isNumber(pagamentoValor) || pagamentoValor <= 0) return;

   // DESCONTO
   checkboxAreaPagamento = document.querySelector("#checkbox-area-pagamento-desconto").checked;
   if (checkboxAreaPagamento) {
        if (!isNumber(pagamentoDesconto)) return;
        if (pagamentoDesconto <= 0) return;
   } else {
        pagamentoDesconto = null;
        pagamentoDescontoDescricao = null;
   }

   submitAnimationPagamentoDivBtn("Aguarde");

    console.log(pagamentoValor);
    console.log(`${emprestimoId} | ${pagamentoTipo} | ${pagamentoData} | ${pagamentoDesconto} | ${pagamentoValor} | ${pagamentoDescontoDescricao}`);

    try {
        $.ajax({
            url: "../../Pagamento/Create",
            type: "POST",
            data:({
                emprestimoId: 1,
                tipo: pagamentoTipo,
                data: pagamentoData,
                valor: pagamentoValor,
                desconto: pagamentoDesconto,
                descontoDescricao: pagamentoDescontoDescricao,
            }),
            success: function (resposta) {
              //console.log(resposta);
              submitAnimationPagamentoDivBtn("Sucesso");
              setTimeout(x => {
                //window.location.reload();
                window.location.href = window.location.pathname + "?pg=true";
              }, 3000);
            },
            error: function (erro) {
              //console.error("Erro:", erro);
              submitAnimationPagamentoDivBtn("Erro");
            }
        });
    } catch (error) {
        //console.error("Erro:", erro);
        submitAnimationPagamentoDivBtn("Erro");
    }
}

window.addEventListener("DOMContentLoaded", () => {
    const params = new URLSearchParams(location.search);
    if (params.get("pg") === "true") {
        const collapse = new bootstrap.Collapse('#flush-collapseOne', {
            toggle: true
        });
        // animation destaque do ultomo pagamento
    }
});


// testes
/* render no backend vou precisa de qualquer forma para
fazer os calculos
try {
    $.ajax({
        url: "../../Pagamento/GetByEmprestimoId",
        type: "GET",
        data:({EmprestimoId: 1}),
        success: function (resposta) {
          console.log(resposta);
        },
        error: function (erro) {
          console.error("Erro:", erro);
        }
    });
} catch (error) {
    console.error("Erro:", erro);
}
*/