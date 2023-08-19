document.addEventListener("DOMContentLoaded", function () {
    var idCasaDropdown = document.getElementById("IdCasa");
    var casaIdHidden = document.getElementById("casaIdHidden");
    var precioCasaInput = document.getElementById("PrecioCasa");

    idCasaDropdown.addEventListener("change", function () {
        var selectedOption = idCasaDropdown.options[idCasaDropdown.selectedIndex];
        var selectedId = selectedOption.value;
        var selectedPrecio = selectedOption.getAttribute("data-precio");

        casaIdHidden.value = selectedId;
        precioCasaInput.value = selectedPrecio; // Actualiza el valor del campo PrecioCasa
    });
});