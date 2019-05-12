
$(document).ready(function () {

  


});


function Testing() {


    $.ajax({
        url: '/Respuestas/Testing/'
        , method: 'GET'
        , dataType: 'JSON'
        //, data: "parameters=" + strOrdenCompleta + "|" + blIsOrden
        , success: function (source) {
            //Se valida el estatus de la peticion JSON.
            if (source !== "" || source !== undefined || source !== null) {
                if (parseInt(source.data.iIdPeticion) === 200) {
                    if (parseInt(source.data.iIdEstatus) !== 202) {
                        returnMessage(2, 1, "Surgió un problema al obtener los datos.");
                    } else {

                        alert("Exito");

                    }
                }
                else {
                    //returnMessage(3, 1, source.strMensaje);
                }
            }
        }
    });
}



