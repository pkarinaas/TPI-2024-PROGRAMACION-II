document.addEventListener('DOMContentLoaded', function () {
    const inputFecha = document.getElementById('input-fecha');

    // Configuración de la fecha actual en el campo de fecha
    const hoy = new Date();
    const dia = String(hoy.getDate()).padStart(2, '0');
    const mes = String(hoy.getMonth() + 1).padStart(2, '0');
    const anio = hoy.getFullYear();
    const fechaActual = `${anio}-${mes}-${dia}`;
    inputFecha.value = fechaActual;

    const addDetailBtn = document.getElementById('addDetailBtn');
    const detailsTable = document.getElementById('detailsTable').getElementsByTagName('tbody')[0];

    addDetailBtn.addEventListener('click', function () {
        const practica = document.getElementById('practica').value;
        const estado = document.getElementById('estado').value;

        // Validación de campos
        if (practica && estado) {
            const newRow = detailsTable.insertRow();

            const cellId = newRow.insertCell(0);
            const cellPractica = newRow.insertCell(1);
            const cellEstado = newRow.insertCell(2);

            cellId.textContent = detailsTable.rows.length;
            cellPractica.textContent = practica;
            cellEstado.textContent = estado;

            document.getElementById('practica').selectedIndex = 0;
            document.getElementById('estado').selectedIndex = 0;
        } else {
            alert('Por favor selecciona una práctica y un estado.');
        }
    });

    // Mapas de prácticas y estados
    const practicasMap = {
        "ACTH": 6,
        "ALDOLASA": 18,
        "ALDOSTERONA": 19,
        "AFP": 20,
        "ANA": 56,
        "ALFA 1 ANTITRIPSINA": 57,
        "ACRA": 2025,
        "ADENOVIRUS MF": 2444,
        "ANDROSTENEDIONA": 2675,
        "ANCA C": 3734,
    };
    
    const estadosMap = {
        "PENDIENTE": 1,
        "INFORMADO": 2,
        "DEMORADO": 3,
        "RECLAMADO": 4,
        "CANCELADO": 5,
    };

    // Función guardarMuestra 
    async function guardarMuestra(event) {
        event.preventDefault(); // Previene el comportamiento predeterminado del botón
    
        const numPaciente = document.getElementById('input-numPac').value;
    
        if (!numPaciente) {
            alert('Por favor ingrese un número de paciente.');
            return;
        }
    
        const detallesTable = document.getElementById('detailsTable').getElementsByTagName('tbody')[0];
    
        for (let i = 0; i < detallesTable.rows.length; i++) {
            const row = detallesTable.rows[i];
            const practicaNombre = row.cells[1].textContent;
            const estadoNombre = row.cells[2].textContent;
    
            const codNbu = practicasMap[practicaNombre];
            const idTipoEstado = estadosMap[estadoNombre];
    
            if (codNbu === undefined || idTipoEstado === undefined) {
                alert(`Error: No se encontró el valor numérico para la práctica ${practicaNombre} o el estado ${estadoNombre}`);
                return;
            }
    
            const detalle = {
                idDetallesMuestras: 0,
                idMuestra: parseInt(numPaciente),
                codNbu: codNbu,
                idTipoEstado: idTipoEstado
            };
    
            try {
                const response = await fetch('https://localhost:7005/api/DetallesMuestras/detalles', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(detalle)
                });
    
                if (!response.ok) {
                    alert(`Error al guardar el detalle de la fila ${i + 1}`);
                    return; // Salir si hay un error
                }
            } catch (error) {
                console.error('Error en la solicitud:', error);
                alert(`Ocurrió un error al guardar el detalle de la fila ${i + 1}.`);
                return; // Salir si ocurre un error
            }
        }
    
        // Si todo se guarda correctamente, limpiar el formulario
        document.getElementById('input-numPac').value = ''; // Limpia el número de paciente
        detallesTable.innerHTML = ''; // Limpia la tabla de detalles
        alert('Todos los detalles se enviaron exitosamente.');
    }
    

    // Agregar el evento de guardar muestra
    document.getElementById('guardarBtn').addEventListener('click', guardarMuestra);
});
