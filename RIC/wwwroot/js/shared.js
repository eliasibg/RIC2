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