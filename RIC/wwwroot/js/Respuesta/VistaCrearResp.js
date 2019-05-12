
$(document).ready(function () {

    loadComboMotivo();

    $("#btnGuardar").click(function () {
        guardarRespuesta();
    });

    
});







function loadComboMotivo() {

    $.ajax({
        url: '/Respuestas/fb537461-dad4-491e-a46a-7f1048ea62c5/'
        , method: 'GET'
        , dataType: 'JSON'
        //, data: "parameters=" + strOrden + "|" + blIsOrden
        , success: function (source) {
            //Se valida el estatus de la peticion JSON.
            if (source !== "" || source !== undefined || source !== null) {
                if (parseInt(source.data.iIdPeticion) === 200) {
                    if (parseInt(source.data.iIdEstatus) !== 202) {
                        returnMessage(2, 1, "Surgió un problema al obtener los datos.");
                    } else {
                        if (source.data.data !== null) {
                            loadControl("cbo", $("#cmbMotivo"), source.data.data, false);
                        

                        }
                    }
                }
                else {
                    returnMessage(3, 1, source.strMensaje);
                }
            }
        }
    });

}

function guardarRespuesta() {


    var strMotivo = $("#cmbMotivo").val();
    var strRespuesta = $("#txtRespuesta").val();

    $.ajax({
        url: '/Respuestas/c9ef64e1-39b3-4aa7-a24b-47b107562783/'
        , method: 'GET'
        , dataType: 'JSON'
        , data: "strParameters=" + strMotivo + "|" + strRespuesta
        , success: function (source) {
            //Se valida el estatus de la peticion JSON.
            if (source !== "" || source !== undefined || source !== null) {
                if (parseInt(source.data.iIdPeticion) === 200) {
                    if (parseInt(source.data.iIdEstatus) !== 202) {
                        returnMessage(2, 1, "Surgió un problema al guardar los datos.");
                    } else {
                        if (source.data.data !== null) {
                            returnMessage(1, 1, "Exito al guardar la respuesta.");

                        }
                    }
                }
                else {
                    returnMessage(3, 1, source.strMensaje);
                }
            }
        }
    });

}