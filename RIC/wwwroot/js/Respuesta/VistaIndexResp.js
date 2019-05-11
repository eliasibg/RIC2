
$(document).ready(function () {

    $("#test").click(function () {

        Testing();

    });


});


function Testing() {


    $.ajax({
        url: '/Respuestas/73092df3-02a7-4878-b1ac-7b26cfa27d88/'
        , method: 'GET'
        , dataType: 'JSON'
        //, data: "parameters=" + strOrdenCompleta + "|" + blIsOrden
        , success: function (source) {
            //Se valida el estatus de la peticion JSON.
            if (source !== "" || source !== undefined || source !== null) {
                if (parseInt(source.iIdPeticion) === 200) {
                    if (parseInt(source.iIdEstatus) !== 202) {
                        returnMessage(2, 1, "Surgió un problema al obtener los datos.");
                    } else {

                        alert("Exito");

                    }
                }
                else {
                    returnMessage(3, 1, source.strMensaje);
                }
            }
        }
    });
}



