function BuscarId() {

    let Identificacion = document.getElementById("Identificacion").value;

    if (Identificacion.trim().length >= 8) {
        fetch("https://apis.gometa.org/cedulas/" + Identificacion)
            .then(response => response.json())
            .then(data => {
                document.getElementById("Nombre").value = data.nombre;
            })
            .catch(error => console.error(error));
    }
    else {
        document.getElementById("Nombre").value = "";
    }
}