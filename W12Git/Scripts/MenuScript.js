
$(window).on('load', function (event) {


    var $items = $(".listaMenu ul li");

    $items.on('click', function () {
        $("#menu li").removeClass("ativado");
        if (!$(this).hasClass("ativado")) {
            $(this).addClass("ativado");
        }
    });
});



function acaoMenu() {

    if ($("#menuLateral").hasClass("Aberto")) {
        $("#menuLateral").removeClass("Aberto");
    } else {
        $("#menuLateral").addClass("Aberto");
    }

}




