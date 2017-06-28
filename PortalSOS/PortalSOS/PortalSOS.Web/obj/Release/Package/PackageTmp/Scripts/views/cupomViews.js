$(document).ready(function () {
    $("#example").DataTable({
        "processing": true,
        "serverSide": true,
        "paging": true,
        "serverSide": true,
        "filter": true,
        "orderMulti": true,
        "bDeferRender": true,
        "language": {
            "zeroRecords": "Nenhum registro encontrado"
        },
        "ajax": {
            "url": "/cupom/getdate",
            "type": "POST",
            "datatype": "json"
        },
        "columns": [
                { "data": "Membro.PrimeiroNome", "name": "Membro.PrimeiroNome", "autoWidth": true },
                { "data": "Codigo", "name": "Codigo", "autoWidth": true },
                { "data": "DescricaoStatus", "name": "DescricaoStatus", "autoWidth": true },
                { "data": "TituloCupom", "name": "TituloCupom", "autoWidth": true },
                { "data": "SubTituloCupom", "name": "SubTituloCupom", "autoWidth": true },
                { "data": "ValorCupomReais", "name": "ValorCupomReais", "autoWidth": true }
        ]
    });
});