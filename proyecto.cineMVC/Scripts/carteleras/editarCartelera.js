$(document).ready(function () {
    var fechaInicio = $("#FechaInicio");
    var fechaFin = $("#FechaFin");
    var fechaInicioOriginal = $("#fechaInicioOriginal").val();
    var fechaFinOriginal = $("#fechaFinOriginal").val();

    fechaInicio.val(fechaInicioOriginal);
    fechaFin.val(fechaFinOriginal);
});