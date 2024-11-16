// Archivo: metodos.js

// URLs de la API para los datos según el estado
const urlFueraCobertura = 'https://localhost:7005/api/ConsultasFueraCobertura/fuera-cobertura';
const urlDentroCobertura = 'https://api.example.com/datos/dentroCobertura';

// Función para mostrar datos en la tabla según la selección del combobox
async function mostrarDatosPorEstado() {
    try {
        const comboBox = document.getElementById('practica');
        const estado = comboBox.value;

        // Determinar la URL según la opción seleccionada
        let url;
        if (estado === 'Fuera de cobertura') {
            url = urlFueraCobertura;
        } else if (estado === 'Dentro de cobertura') {
            url = urlDentroCobertura;
        }

        // Realizar la solicitud a la API
        const response = await fetch(url);
        const data = await response.json();

        // Referencia a la tabla para mostrar los datos
        const tablaCuerpo = document.querySelector('.lista-detalles');
        tablaCuerpo.innerHTML = ''; // Limpiar la tabla antes de insertar nuevos datos

        // Insertar cada objeto de datos en la tabla
        data.forEach(item => {
            const fila = document.createElement('tr');
            fila.innerHTML = `
                <td>${item.nombrePaciente}</td>
                <td>${item.nombrePractica}</td>
                <td>${item.obraSocial}</td>
                <td>${item.montoCobertura}</td>
                <td>${item.precioDerivacion}</td>
                <td>${item.estadoCobertura}</td>
            `;
            tablaCuerpo.appendChild(fila);
        });
    } catch (error) {
        console.error('Error al cargar datos en la tabla:', error);
    }
}

// Asignar evento de cambio al combobox
document.addEventListener('DOMContentLoaded', () => {
    const comboBox = document.getElementById('practica');
    comboBox.addEventListener('change', mostrarDatosPorEstado);
});