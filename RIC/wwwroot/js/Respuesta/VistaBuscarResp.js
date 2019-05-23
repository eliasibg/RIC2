
$(document).ready(function () {

    

    loadComboMotivo();



    $("#btnBuscar").click(function () {
        LoadRespuestas();
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



function LoadRespuestas() {

    var strMotivo = $("#cmbMotivo").val();



    $.ajax({
        url: '/Respuestas/9427a5e6-8956-4c40-84c9-bbbd62db9484/'
        , method: 'GET'
        , dataType: 'JSON'
        , data: "strParameters=" + strMotivo
        , success: function (source) {
            //Se valida el estatus de la peticion JSON.
            if (source !== "" || source !== undefined || source !== null) {
                if (parseInt(source.data.iIdPeticion) === 200) {
                    if (parseInt(source.data.iIdEstatus) !== 202) {
                        returnMessage(2, 1, "Surgió un problema al obtener los datos.");
                    } else {

                        if (source.data !== null) {

                            showControls($('#dvDtResp'));
                            $('#dtResp').DataTable({
                                responsive: false,
                                lengthMenu: [5, 10, 25, 50, 100],
                                dom: 'lCfrtip',
                                order: [[0, 'desc']],
                                data: source.data.data,
                                paging: false,
                                bAutoWidth: true,
                                bDestroy: true,
                                colVis: {
                                    "buttonText": "Columnas"
                                    , "overlayFade": 0
                                    , "align": "right"
                                }
                                , language: {
                                    sZeroRecords: "No se encontraron resultados"
                                    , sEmptyTable: "Ningún dato disponible en esta tabla"
                                    , sProcessing: "Procesando..."
                                    , sLoadingRecords: "Cargando..."
                                    , sLengthMenu: 'Mostrar _MENU_ registros'
                                    , sInfo: " _START_ al _END_ / _TOTAL_ registros"
                                    , sInfoEmpty: "Mostrando registros del 0 al 0 de un total de 0 registros"
                                    , sInfoFiltered: "(filtrado de un total de _MAX_ registros)"
                                    , sSearch: '<i class="fa fa-search"></i>'
                                    , sInfoThousands: ","
                                    , sInfoPostFix: ""
                                    , oPaginate: {
                                        sFirst: "Primero"
                                        , sLast: "Último"
                                        , sNext: "Siguiente"
                                        , sPrevious: "Anterior"
                                    }
                                    , oAria: {
                                        sSortAscending: ": Activar para ordenar la columna de manera ascendente"
                                        , sSortDescending: ": Activar para ordenar la columna de manera descendente"
                                    }
                                }
                                // #region Styles, data properties
                                , columnDefs: [
                                    { className: "dt-head-center", targets: [0, 1] }
                                    , { className: "dt-body-left", targets: [0, 1] }
                                    , { title: "Respuesta", data: "strRespuesta", targets: [0], bSortable: true, width: "35%" }
                                    , {
                                        title: "Motivo", data: "strMotivo", targets: [1], bSortable: true, width: "35%", className: "tipo"
                                       

                                    }
                                    , { title: "Estatus", data: "strEstatus", targets: [2], bSortable: true, width: "35%", className: "seccion" }
                                    
                                ],

                                //Esta funcion secciona la tabla mediante una columna que se le determine.
                                "drawCallback": function (settings) {
                                   
                                    var api = this.api();
                                    var rows = api.rows({ page: 'current' }).nodes();
                                    var last = null;

                                    api.column([2], { page: 'current' }).data().each(function (group, i) {
                                        if (last !== group) {
                                            $(rows).eq(i).before(
                                                //'<tr class="group"><td colspan="5" style="background:#353EA6;color:white;"></td></tr>'
                                            );

                                            last = group;
                                        }
                                    });
                                }

                                //  #endregion
                            });
                                                      
                        }

                    }
                }
                else {
                    //returnMessage(3, 1, source.strMensaje);
                }
            }
        }
    });
}
