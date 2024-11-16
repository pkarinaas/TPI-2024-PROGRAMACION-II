document.addEventListener('DOMContentLoaded', () => {
    const API_URL_BASE = 'https://localhost:7005/api/ConsultasMuestras/GetEstadoMuestras?estado=';

    // Función para obtener las muestras filtradas por el valor de búsqueda
    async function fetchMuestras(estado) {
        try {
            const response = await fetch(`${API_URL_BASE}${encodeURIComponent(estado)}`);
            if (!response.ok) {
                throw new Error(`HTTP error! status: ${response.status}`);
            }
            const muestras = await response.json();
            cargarMuestras(muestras);
        } catch (error) {
            console.error('Error al obtener las órdenes:', error);
        }
    }

    // Añade un listener al botón de buscar para capturar el valor del input y llamar a fetchMuestras
    const searchInput = document.querySelector('.form-control');
    const searchButton = document.querySelector('.btn[type="submit"]');
    
    searchButton.addEventListener('click', (event) => {
        event.preventDefault(); // Evita que el formulario se envíe y recargue la página
        const estado = searchInput.value.trim(); // Obtiene el valor del input y elimina espacios en blanco
        if (estado) {
            fetchMuestras(estado); // Llama a fetchMuestras con el parámetro ingresado
        } else {
            console.warn('Por favor ingresa un valor para buscar.');
        }
    });

    // Función para formatear la fecha (de ISO a dd/MM/yyyy)
    function formatearFecha(fechaISO) {
        const fecha = new Date(fechaISO);
        const dia = String(fecha.getDate()).padStart(2, '0');
        const mes = String(fecha.getMonth() + 1).padStart(2, '0');
        const anio = fecha.getFullYear();
        return `${dia}/${mes}/${anio}`;
    }

    // Función para crear las filas de la tabla
    function cargarMuestras(muestras) {
        const tbody = document.querySelector('.lista-detalles');
        if (!tbody) {
            console.error('No se encontró el elemento tbody con la clase "lista-detalles"');
            return;
        }
        
        tbody.innerHTML = ''; // Limpiar la tabla antes de agregar nuevas filas

        muestras.forEach(muestra => {
            const row = document.createElement('tr');

            // Crear y agregar las celdas para cada columna
            const nroTd = document.createElement('td');
            nroTd.textContent = muestra.idMuestra;
            row.appendChild(nroTd);

            const nombreTd = document.createElement('td');
            nombreTd.textContent = muestra.nombrePaciente;
            row.appendChild(nombreTd);

            const apellidoTd = document.createElement('td');
            apellidoTd.textContent = muestra.apellidoPaciente;
            row.appendChild(apellidoTd);

            const practicaTd = document.createElement('td');
            practicaTd.textContent = muestra.práctica;
            row.appendChild(practicaTd);

            const fechaTd = document.createElement('td');
            fechaTd.textContent = formatearFecha(muestra.fechaRecolección);
            row.appendChild(fechaTd);

            const fecha2Td = document.createElement('td');
            fecha2Td.textContent = formatearFecha(muestra.fechaprometidainforme);
            row.appendChild(fecha2Td);

            const derivTd = document.createElement('td');
            derivTd.textContent = muestra.derivadaA;
            row.appendChild(derivTd);

            const estadoTd = document.createElement('td');
        
            //contenedor para el badge y el texto de estado
            const estadoContainer = document.createElement('div');
            estadoContainer.style.display = 'flex';
            estadoContainer.style.alignItems = 'center';
            
            //span con el estilo de badge
            const estadoBadge = document.createElement('span');
            estadoBadge.classList.add('badge');
    
            switch (muestra.estado) {
                case 'PENDIENTE':
                    estadoBadge.classList.add('status', 'pink');
                    estadoBadge.textContent = '.';
                    break;
                case 'CANCELADO':
                    estadoBadge.classList.add('status', 'orange');
                    estadoBadge.textContent = '.';
                    break;
                case 'INFORMADO':
                    estadoBadge.classList.add('status', 'purple');
                    estadoBadge.textContent = '.';
                    break;
                default:
                    estadoBadge.textContent = muestra.estado;
            }
    
            //nodo de texto con el contenido de muestra.estado
            const estadoTexto = document.createElement('span');
            estadoTexto.textContent = ` ${muestra.estado}`;
            estadoTexto.style.marginLeft = '8px';
    
            //Agregar el badge y el texto al contenedor
            estadoContainer.appendChild(estadoBadge);
            estadoContainer.appendChild(estadoTexto);
    
            //Agregar el contenedor a la celda de estado
            estadoTd.appendChild(estadoContainer);
    
            //Agregar la celda de estado a la fila
            row.appendChild(estadoTd);
    
            // Agregar la fila a la tabla
            tbody.appendChild(row);
        });
    }})