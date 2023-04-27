jQuery(function ($) {
    $("input[name='cep']").change(function () {

        var cep_code = $(this).val();
        if (cep_code.length <= 0) return;

        $.getJSON("https://viacep.com.br/ws/" + cep_code + "/json/?callback?", function (result) {
            if (result.erro == true) {
                alert(result.message || "CEP não existe");
                return;
            }

            $("input[name='cep']").val(result.cep);
            $("input[name='estado']").val(result.uf);
            $("input[name='cidade']").val(result.localidade);
            $("input[name='bairro']").val(result.bairro);
            $("input[name='endereco']").val(result.logradouro);
        });
    });
});