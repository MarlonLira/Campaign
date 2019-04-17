function formataData(campo, evt) {

    //dd/MM/yyyy

    evt = getEvent(evt);

    var tecla = getKeyCode(evt);

    if (!teclaValida(tecla))

        return;

    vr = campo.value = filtraNumeros(filtraCampo(campo));

    tam = vr.length;

    if (tam >= 2 && tam < 4)

        campo.value = vr.substr(0, 2) + '/' + vr.substr(2);

    if (tam == 4)

        campo.value = vr.substr(0, 2) + '/' + vr.substr(2, 2) + '/';

    if (tam > 4)

        campo.value = vr.substr(0, 2) + '/' + vr.substr(2, 2) + '/' + vr.substr(4);


}