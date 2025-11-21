function formatCoin(nameId) {
    const valorPago = document.getElementById(`${nameId}`);
    valorPago.oninput = function (e) {
        let value = e.target.value.replace(/\D/g, '');
        if (value === '') {
            e.target.value = '';
            return;
        }

        value = Number(value) / 100;
        e.target.value = value.toLocaleString('en-US', {
            minimumFractionDigits: 2,
            maximumFractionDigits: 2,
            useGrouping: false
        });
    };
}