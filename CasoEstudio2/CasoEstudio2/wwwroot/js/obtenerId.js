document.addEventListener("DOMContentLoaded", function () {
    var idCasaDropdown = document.getElementById("IdCasa");
    var casaIdHidden = document.getElementById("casaIdHidden");

    idCasaDropdown.addEventListener("change", function () {
        var selectedId = idCasaDropdown.value;
        casaIdHidden.value = selectedId;
    });
});