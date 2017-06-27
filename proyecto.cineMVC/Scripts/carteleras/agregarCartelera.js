$(document).ready(function () {
    var horaInicio = $("#HoraInicio");

    horaInicio.focusout(function () {
        let nuevaHora = horaInicio.val().replace(":", "");
        $("#HoraInicio").val(nuevaHora);
    });

    // Workaround para que funcionen los checkbox de materialize con el checkbox helper (Html.CheckBoxFor)
    $("input[type=hidden]").each(function () {
        let input = $(this);
        let siguiente = input.next();
        input.before(siguiente);
    })
});