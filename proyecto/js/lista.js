document.addEventListener('DOMContentLoaded', function () {
    cargarMuestras();
});

// Función para obtener el estado en formato de texto según el idTipoEstado
function obtenerEstado(idTipoEstado) {
    switch (idTipoEstado) {
        case 1:
            return "Pendiente";
        case 2:
            return "Informado";
        case 3:
            return "Demorado";
        case 4:
            return "Reclamado";
        case 5:
            return "Cancelado";
    }
}

// Función para cargar las muestras desde la API
async function cargarMuestras() {
    try {
        // Realiza la solicitud a la API
        const response = await fetch('https://localhost:7005/api/Muestra/GetAll');

        // Verifica si la respuesta es exitosa
        if (!response.ok) {
            throw new Error('Error en la solicitud de datos');
        }

        // Convierte la respuesta en formato JSON
        const muestras = await response.json();

        // Obtén el elemento tbody de la tabla donde se mostrarán los datos
        const tbody = document.getElementById("muestra-lista");

        // Limpiar cualquier contenido previo
        tbody.innerHTML = '';

        // Recorrer cada muestra y agregarla a la tabla
        muestras.forEach(muestra => {
            const row = document.createElement("tr");

            // Crear celdas de la tabla
            const tdMuestra = document.createElement("td");
            tdMuestra.textContent = muestra.idMuestra;

            const tdPaciente = document.createElement("td");
            tdPaciente.textContent = muestra.codPaciente;

            const tdFecha = document.createElement("td");
            tdFecha.textContent = new Date(muestra.fechaRecoleccion).toLocaleDateString();

            const tdEstado = document.createElement("td");
            tdEstado.textContent = obtenerEstado(muestra.idTipoEstado);

            // Agregar celdas a la fila
            row.appendChild(tdMuestra);
            row.appendChild(tdPaciente);  // Añadimos la celda de codPaciente
            row.appendChild(tdFecha);
            row.appendChild(tdEstado);

            // Agregar la fila al tbody
            tbody.appendChild(row);
        });
    } catch (error) {
        console.error("Error al cargar las muestras:", error);
        alert("Hubo un problema al cargar los datos.");
    }
}