$(function () {
    estableceEventosChange();
    cargaDropdownListCliente();
});

function estableceEventosChange() {
    $("#Cliente").change(function () {
        var Cliente = $("#Cliente").val();
        cargaTabalaCliente(Cliente);
    });
}

function cargaDropdownListCliente() {

    var url = '/Home/RetornaClientes';
    var parametros = {
    };
    $.ajax({
        url: url,
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(parametros),
        success: function (data, textStatus, jQxhr) {
            procesarResultadoCliente(data)
        },
        error: function (jQxhr, textStatus, errorThrown) {
            alert(errorThrown);
        },
    });
}
function procesarResultadoCliente(data) {
    var ddlCliente = $("#Cliente");
    ddlCliente.empty();
    var nuevaOpcion = "<option value=''>Seleccione un Cliente</option>";
    ddlCliente.append(nuevaOpcion);
    $(data).each(function () {
        var ClienteActual = this;
        nuevaOpcion = "<option value='" + ClienteActual.CodigoCliente + "'>" + ClienteActual.NombreCliente + "</option>";
        ddlCliente.append(nuevaOpcion);
    });
}

$(document).on('change', '#Cliente', function (event) {
    $('#ID').val($("#Cliente option:selected").val());
});

///////////////////////////
function cargaTabalaCliente(pCliente) {

    var url = '/Home/RetornaFactura';
    var parametros = {
        CodigoCliente: pCliente
    };
    $.ajax({
        url: url,
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(parametros),
        success: function (data, textStatus, jQxhr) {
            procesarResultadoFactura(data)
        },
        error: function (jQxhr, textStatus, errorThrown) {
            alert(errorThrown);
        },
    });
}
function eliminar(correlativo) {
    $('#fila' + correlativo).remove();

}
var correlativo = 0;
function procesarResultadoFactura(data) {
    var ddlFactura = $("#Contenido");
    ddlFactura.empty();
    var nuevaOpcion = "";
    ddlFactura.append(nuevaOpcion);
    $(data).each(function () {
        correlativo++;
        var FacturaActual = this;
        nuevaOpcion = "<tr><td id='fila" + correlativo + "'>" + FacturaActual.NumeroFactura + "</td><td>" + FacturaActual.CodigoCliente + "</td><td>" + FacturaActual.FechaFactura + "</td><td>" + FacturaActual.MontoOriginal + "</td><td>" + FacturaActual.MontoAbonos + "</td><td><input id='Dato" + correlativo + "'/></td></tr>"
        ddlFactura.append(nuevaOpcion);
    });
}

if ('#Dato1' != " ") {
    $(document).on('change', '#Dato1', function (event) {
        $("#IDs").show();
        $('#IDs').val($("#Dato1").val());
        var MyRows = $('table#conten').find('tbody').find('tr');
        for (var i = 0; i < 2; i++) {
            var MyIndexValue = $(MyRows[i]).find('td:eq(0)').html();
        }
        $('#IDc').val(MyIndexValue)
    });


} if ('#Dato2' != " ") {
    $(document).on('change', '#Dato2', function (event) {
        $("#ID1").show();
        $('#ID1').val($("#Dato2").val());
        var MyRows = $('table#conten').find('tbody').find('tr');
        for (var i = 0; i < 3; i++) {
            var MyIndexValue = $(MyRows[i]).find('td:eq(0)').html();
        }
        console.log(MyIndexValue)
        $('#ID2').val(MyIndexValue)
    });




} if ('#Dato3' != " ") {
    $(document).on('change', '#Dato3', function (event) {
        $(".ID3").show();
        $('#ID3').val($("#Dato3").val());
        var MyRows = $('table#conten').find('tbody').find('tr');
        for (var i = 0; i < 4; i++) {
            var MyIndexValue = $(MyRows[i]).find('td:eq(0)').html();
        }
        console.log(MyIndexValue)
        $('#ID4').val(MyIndexValue)
    });
 
}

///////////////////////////
