$(document).ready(function () {
    var idPelicula = $("#idPelicula").val();
    var version = $("#version");
    var sede = $("#sede");

    version.on('change', function () {
        $.get("/api/listaDeSedesQueTienenUnaPeliculaYUnaVersion", { idPelicula: idPelicula, idVersion: version.val() })
            .done(function (data) {
                agregarSedes(data);
            })
    })

    sede.on('change', function () {
        $.get("/api/diasYHorarios", { idSede: sede.val(), idPelicula: idPelicula, idVersion: version.val() })
            .done(function (data) {
                agregarDiasYHorarios(data);
            })
    })

    $("#enviar").on("click", function (e) {
        e.preventDefault;
        validate_form();
    })
})

function agregarSedes(data) {
    resetDiaYHora();
    let selectSedes = ("#sede");
    let new_html = '<option value="" selected disabled>Seleccione una sede</option>';
    data.forEach(function (obj) {
        new_html += '<option value="' + obj.IdSede + '">' + obj.Nombre + '</option>';
    })
    $(selectSedes).html(new_html);
    $(selectSedes).removeAttr("disabled");
}

function resetDiaYHora() {
    let dia = $("#dia");
    let hora = $("#hora");

    $(dia).html('<option value="" selected disabled>Seleccione una dia</option>')
    $(hora).html('<option value="" selected disabled>Seleccione una hora</option>')
    $(dia).attr("disabled");
    $(dia).attr("disabled");
}

function agregarDiasYHorarios(data) {
    let selectDia = ("#dia");
    let selectHora = ("#hora");
    
    let horaInicio = data.Hora.toString();
    let auxHora = parseInt(horaInicio.slice(0, 2));
    let auxMin = parseInt(horaInicio.slice(2, 4));

    let horaEnMinutos = (auxHora * 60) + auxMin;

    let hasta = data.Hasta.slice(data.Hasta.indexOf("(") + 1, data.Hasta.indexOf(")"));

    cargarDias(hasta, data.Dias);
    cargarHorarios(horaEnMinutos);

    $(selectDia).removeAttr("disabled");
    $(selectHora).removeAttr("disabled");
}

function cargarDias(fecha_fin, dias_disponibles) {
    let fechaInicio = new Date();
    let fechaFin = new Date(parseInt(fecha_fin));
    let fechasHastaFinDeCartelera = getDates(fechaInicio, fechaFin);
    let listaDeFechas = [];
    fechasHastaFinDeCartelera.forEach(function (fecha) {
        if (dias_disponibles.includes(fecha.getDay())) {
            listaDeFechas.push(fecha);
        }
    })

    generarOptionDeFechas(listaDeFechas);
}

function generarOptionDeFechas(listaDeFechas) {
    let selectDia = $("#dia");
    let new_html = '<option value="" selected disabled>Seleccione un dia</option>';

    var dias = new Array(7);
    var meses = new Array(12);

    dias[0] = "Domingo";
    dias[1] = "Lunes";
    dias[2] = "Martes";
    dias[3] = "Miercoles";
    dias[4] = "Jueves";
    dias[5] = "Viernes";
    dias[6] = "Sabado";

    meses[0] = "Enero";
    meses[1] = "Febrero";
    meses[2] = "Marzo";
    meses[3] = "Abril";
    meses[4] = "Mayo";
    meses[5] = "Junio";
    meses[6] = "Julio";
    meses[7] = "Agosto";
    meses[8] = "Septiembre";
    meses[9] = "Octubre";
    meses[10] = "Noviembre";
    meses[11] = "Diciembre"

    listaDeFechas.forEach(function (fecha_actual) {
        new_html += `<option value="${fecha_actual.getTime()}">${dias[fecha_actual.getDay()]} ${fecha_actual.getDate()} de ${meses[fecha_actual.getMonth()]}</option>`;
    })
    selectDia.html(new_html);
}

function cargarHorarios(horaInicio) {
    let selectHora = ("#hora");
    let duracionPelicula = parseInt($("#duracionPelicula").val());
    horaInicio -= duracionPelicula;
    let new_html = '<option value="" selected disabled>Seleccione un horario</option>';
    for (let i = 1; i <= 7; i++) {
        let hora = horaInicio + (duracionPelicula * i) + 30;
        new_html += generarOptionDesdeHorario(hora); 
    }
    $(selectHora).html(new_html);
    
}

function generarOptionDesdeHorario(hora) {
    let auxHora = Math.floor(parseInt(hora) / 60);
    let auxMinutos = parseInt(hora) % 60;
    auxHora = auxHora < 24 ? auxHora : '0' + (auxHora - 24);
    let nueva_hora = auxHora + ":" + auxMinutos;
    return '<option value="' + nueva_hora + '">' + nueva_hora + '</option>'
}

Date.prototype.addDays = function (days) {
    var dat = new Date(this.valueOf())
    dat.setDate(dat.getDate() + days);
    return dat;
}

function getDates(startDate, stopDate) {
    var dateArray = new Array();
    var currentDate = startDate;
    while (currentDate <= stopDate) {
        dateArray.push(new Date(currentDate))
        currentDate = currentDate.addDays(1);
    }
    return dateArray;
}

function validate_form() {
    let version = $("#version");
    let sede = $("#sede");
    let dia = $("#dia");
    let hora = $("#hora");

    let errores = [];

    if (version.val() == null) errores.push("Debes seleccionar una version");
    if (sede.val() == null) errores.push("Debes seleccionar una sede");
    if (dia.val() == null) errores.push("Debes seleccionar una fecha");
    if (hora.val() == null) errores.push("Debes seleccionar una hora");

    if (errores.length == 0) {
        let fecha_final = new Date(parseInt(dia.val()));
        let hora_final = parseInt(hora.val().slice(0, 2));
        let minutos_final = parseInt(hora.val().slice(3, 5));

        fecha_final.setHours(hora_final);
        fecha_final.setMinutes(minutos_final);

        $("#horaYFecha").val(fecha_final.getTime());
        $("#formulario_reserva").submit();
    } else {
        let new_html = "<div class='row'>";
        errores.forEach(function (error) {
            new_html += "<b>" + error + "</b><br>";
        })
        new_html += "</div>";
        $("#errores").html(new_html);
        $("#errores_container").removeAttr("hidden");
    }
}