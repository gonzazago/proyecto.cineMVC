$(document).ready(function () {
    $('a.borrar').click(function () {
        return confirm('Estas seguro que queres borrar la cartelera?');
    });
})