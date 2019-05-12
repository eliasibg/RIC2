$(document).ready(function () {
    /// <summary>Configuracion para los controles tipo calendario</summary>
    /*
    $('.date').datepicker({
        autoclose: true
        , todayHighlight: true
        , language: 'es'
        , format: "dd/mm/yyyy"
    });

    $(".time12-mask").inputmask('hh:mm t', {
        placeholder: 'hh:mm xm'
        , alias: 'time12'
        , hourFormat: '12'
    });

    $(":input").inputmask();
    */
});

function cleanControls(strControl) {
    /// <summary>Reestablece el valor del control / limpiar el valor del control.</summary>
    /// <param name="strControl" type="String">Nombre del control.</param>

    $(strControl).val('');
}

function cleanControlCheckbox(strControl) {
    /// <summary>Quita la seleccion de un control checkbox</summary>
    /// <param name="strControl" type="String">Nombre del control</param>

    $(strControl).prop("checked", false);
}

function showControls(strControl) {
    /// <summary>Muestra el control que se encuentra oculto.</summary>
    /// <param name="strControl" type="String">Nombre del control.</param>

    $(strControl).show();
}

function hideControls(strControl) {
    /// <summary>Oculta el control que se muestra.</summary>
    /// <param name="strControl" type="String">Nombre del control.</param>

    $(strControl).hide();
}

function isValidStringIsNullOrEmpty(strControl) {
    /// <summary>Valida si el control es diferente de vacio.</summary>
    /// <param name="strControl" type="String">Nombre del control.</param>

    var bIsResultado = false;

    if (strControl === 'undefined') {
        // empty
    }
    else {
        if (strControl !== 'undefined') {
            if (strControl !== "") {
                var strValor = strControl;
                if (strValor.toString().trim() !== "")
                    bIsResultado = true;
                else
                    bIsResultado = false;
            }
        }
    }

    return bIsResultado;
}

function redirectPageMVC(strController, strAccion, strParameter) {
    /// <summary>Genera el acceso / redireccionamiento a otros controladores web.</summary>
    /// <param name="strController" type="String">Nombre del controlador a acceder.</param>
    /// <param name="strAccion" type="String">Nombre de la accion a acceder.</param>
    /// <param name="strParameter" type="String">Parametros opcionales que se envian al controlador.</param>

    if (strParameter === undefined)
        window.location.href = '/' + strController + '/' + strAccion;
    else
        window.location.href = '/' + strController + '/' + strAccion + '?parameters=' + strParameter;
}

function returnMessage(iTipoMensaje, iTipoDialog, strMessage) {
    /// <summary>Genera mensajes y alertas predetermina que se puede personalizar.</summary>
    /// <param name="iTipoMensaje" type="Interger">Valor del tipo de mensaje a mostrar: 1) Mensaje de éxito. 2) Mensaje de validación. 3) Mensaje de error. 4) Validación.</param>
    /// <param name="iTipoDialog" type="Interger">Tipo de mensaje: 1) Aceptar. 2) Aceptar / Cancelar.</param>
    /// <param name="strMessage" type="String">Mensaje que se le mostrara al usuario.</param>

    var strTitle = "";
    var strType = "";

    switch (iTipoMensaje) {
        case 1:
            strTitle = "Mensaje de éxito";
            strType = "success";
            break;
        case 2:
            strTitle = "Mensaje de validación";
            strType = "warning";
            break;
        case 3:
            strTitle = "Mensaje de error";
            strType = "error";
            break;
        case 4:
            strTitle = "Validación";
            strType = "info";
            break;
    }

    if (iTipoDialog === 1) {
        swal({
            title: strTitle
            , type: strType
            , text: strMessage
            , showCloseButton: true
            , confirmButtonText: 'Aceptar'
            , confirmButtonClass: 'btn-primary'
        });
    } else if (iTipoDialog === 2) {
        swal({
            title: strTitle
            , type: strType
            , text: strMessage
            , showCloseButton: true
            , showCancelButton: true
            , confirmButtonText: 'Aceptar'
            , confirmButtonClass: 'btn-primary'
            , cancelButtonText: 'Cancelar'
            , cancelButtonClass: 'btn-default'
        });
    }
}

function returnMessageAjax(jqXHR, textStatus, errorThrown) {
    /// <summary>Indica el mensaje a mostrar por el error ocacionado en la comunicacion de ajax y algun metodo</summary>
    /// <param name="jqXHR" type="String">Objeto que contiene todos los datos de la solicitud ajax realizada.</param>
    /// <param name="textStatus" type="String">Texto que describe el tipo de error</param>
    /// <param name="errorThrown" type="String">Si existe un error HTTP, indica el texto de la cabecera HTTP de estado</param>
    var strResponse = "";

    if (jqXHR.status === 0)
        strResponse = "Not connect: Verify Network.";
    else if (jqXHR.status === 404)
        strResponse = "Requested page not found [404]";
    else if (jqXHR.status === 500)
        strResponse = "Internal Server Error [500].";
    else if (textStatus === "parsererror")
        strResponse = "Requested JSON parse failed.";
    else if (textStatus === "timeout")
        strResponse = "Time out error.";
    else if (textStatus === "abort")
        strResponse = "Ajax request aborted.";
    else
        strResponse = "Uncaught Error: " + jqXHR.responseText;

    return strResponse;
}

function getUrlParam(strParameter) {
    /// <summary>Obtiene de la url el parametros indicado</summary>
    /// <param name="strParameter" type="String">Parametro solicitado</param>

    strParameter = strParameter.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + strParameter + "=([^&#]*)"),
        results = regex.exec(location.search);

    return results === null ? null : decodeURIComponent(results[1].replace(/\+/g, " "));
}

function loadControl(strTipoControl, strControl, data, dataType) {
    /// <summary>Funcion para la cargar dinamica de controles</summary>
    /// <param name="strTipoControl" type="String">Tipo de control que se le van asignar los datos.</param>
    /// <param name="strControl" type="String">Nombre del control</param>
    /// <param name="data" type="String">Objeto a cargar</param>
    /// <param name="dataType" type="Boolean">Identifica si el control es personalizado por algun data-type</param>

    if (strTipoControl !== "" || strTipoControl !== undefined || dastrTipoControlta !== null) {
        switch (strTipoControl) {
            case "cbo":
                if (data !== "" || data !== undefined || data !== null) {
                    //$(strControl).append('<option value=' + -1 + '>' + '' + '</option>');

                    if (dataType) {
                        $.each(data, function (key, value) {
                            var arrayTipificaciones = value.split('|');
                            $(strControl).append('<option value=' + key + ' data-type=' + arrayTipificaciones[0] + '>' + arrayTipificaciones[1] + '</option>');
                        });
                    } else {
                        $.each(data, function (key, value) {
                            $(strControl).append('<option value="' + key + '">' + value + '</option>');
                        });
                    }
                }
                break;

            default:
                break;
        }
    }
}

function isValidControls(arrayControls, arrayMessages) {
    /// <summary>Funcion para validar los controles de un formulario</summary>
    /// <param name="arrayControls" type="Array">Arreglo de controles a validar de un formulario.</param>
    /// <param name="arrayMessages" type="Array">Arreglo de mensajes asignados a cada uno de los controles.</param>

    var bIsValid = true;

    $.each(arrayControls, function (index, control) {
        // Validamos que los controles requeridos sean diferentes de null o vacio.
        var strControlValue = $('' + control + '').val();

        if (strControlValue === "" || strControlValue === undefined || strControlValue === null || parseInt(strControlValue) === -1) {
            returnMessage(4, 1, arrayMessages[index]);
            bIsValid = false;
            return false;
        }
    });

    return bIsValid;
}

function isValidEmail(strEmail, strDiv) {
    /// <summary>Funcion que valida el email sea correcto</summary>
    /// <param name="strEmail" type="String">Correo electronico a validar.</param>
    /// <param name="strDiv" type="String">Control div para mostrar el error si se llega a presentar.</param>

    var strRegexp = new RegExp(/^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/);

    if (strRegexp.test(strEmail) === false) {
        $(strDiv).hide().removeClass('hide').slideDown('fast');

        return false;
    } else {
        $(strDiv).hide().addClass('hide').slideDown('slow');

        return true;
    }
}


function myfunction() {
    alert("Saludos");
    alert("Saludos");
}
function CleanAllControls(ArrayControls) {
    /// <summary>Funcion que limpia todos los controles de una pantalla</summary>
    /// <param name="ArrayControls" type="String">lista de contoles a limpiar.</param>
    var Controls = ArrayControls.split("&");
    var arrayInputs = Controls[0].split("|");
    var arrayLabel = Controls[1].split("|");

    if (arrayInputs.length > 0) {
        for (var i = 0; i < arrayInputs.length; i++) {
            $(arrayInputs[i]).val("");
        }
    }

    if (arrayLabel.length > 0) {
        for (var i = 0; i < arrayLabel.length; i++) {
            if (arrayLabel[i] != "") {
                $(arrayLabel[i]).text("");
            }
        }
    }
}

function quitarFormato(valor) {
    var resultado = valor.replace("(", "").replace(")", "").replace("-", "").replace(" ", "");

    return resultado;
}

// #endregion