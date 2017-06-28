function GetZip(controller) {
    var cep = $("#CEP").val();
    $.ajax({
        //url: '/portalsoshml/' + controller + '/GetZip',  /* URL que será chamada */
        url: '/' + controller + '/GetZip',  /* URL que será chamada */
        type: 'GET', /* Tipo da requisição */
        data: 'cep=' + cep, /* dado que será enviado via POST */
        dataType: 'json', /* Tipo de transmissão */
        success: function (data) {
            var resultado = $.parseJSON(data.Data);
            $("#Rua").val(resultado.Logradouro);
            $("#Bairro").val(resultado.Bairro);
            $("#Cidade").val(resultado.Cidade);
            $("#Numero").focus();
            $("#Complemento").val('');
            $("#UF").val(resultado.Uf);
        }
    });
}