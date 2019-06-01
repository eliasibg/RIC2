
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
                            loadDatosResp();

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

function loadDatosResp() {

    

        var strcadParametrs = location.search.substring(1, location.search.length);
        var strcadParametrs = strcadParametrs.replace("parameters=", "");
        var strArrVariables = strcadParametrs.split("|");

        var strIdResp = 0;
        if (strcadParametrs.length > 0) {


            strIdResp = strArrVariables[0];
        }


        

        $.ajax({
            url: '/Respuestas/93ee7b71-464f-470e-b247-7aac3e511c61/'
            , method: 'GET'
            , dataType: 'JSON'
            , data: "strParameters=" + strIdResp
            , success: function (source) {
                //Se valida el estatus de la peticion JSON.
                if (source !== "" || source !== undefined || source !== null) {
                    if (parseInt(source.data.iIdPeticion) === 200) {
                        if (parseInt(source.data.iIdEstatus) !== 202) {
                            returnMessage(2, 1, "Surgió un problema al guardar los datos.");
                        } else {
                            if (source.data.data !== null) {


                                $("#txtRespuesta").val(source.data.data[0].strRespuesta);
                                $("#cmbMotivo").val(source.data.data[0].strMotivo);

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

    var strcadParametrs = location.search.substring(1, location.search.length);
    var strcadParametrs = strcadParametrs.replace("parameters=", "");
    var strArrVariables = strcadParametrs.split("|");
    var strIdResp = strArrVariables[0];

    var strMotivo = $("#cmbMotivo").val();
    var strRespuesta = $("#txtRespuesta").val();
     

    $.ajax({
        url: '/Respuestas/0b61f612-1089-4047-9b3c-c2d6dc2882fc/'
        , method: 'GET'
        , dataType: 'JSON'
        , data: "strParameters=" + strMotivo + "|" + strRespuesta + "|" + strIdResp
        , success: function (source) {
            //Se valida el estatus de la peticion JSON.
            if (source !== "" || source !== undefined || source !== null) {
                if (parseInt(source.data.iIdPeticion) === 200) {
                    if (parseInt(source.data.iIdEstatus) !== 202) {
                        returnMessage(2, 1, "Surgió un problema al modificar los datos.");
                    } else {
                        if (source.data.data !== null) {
                            returnMessage(1, 1, "Exito al modificar la respuesta.");

                            setTimeout(regresar, 3000);

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

function regresar() {

    redirectPageMVC("Respuestas", "Listar");

}