document.addEventListener('DOMContentLoaded', async () => {
    try {
        // Llamada al endpoint para obtener los datos de las muestras
        const response = await fetch('https://localhost:7005/api/Muestra/GetAll');
        if (!response.ok) throw new Error(`Error HTTP: ${response.status}`);

        const data = await response.json();

        // Obtener el año actual
        const currentYear = new Date().getFullYear();

        // Inicializamos un objeto para contar las muestras por mes (clave = mes)
        const muestrasPorMes = {};

        // Iteramos sobre los datos para agrupar por mes, pero solo del año actual
        data.forEach(item => {
            const fecha = new Date(item.fechaRecoleccion);
            const year = fecha.getFullYear();

            // Verificar que la muestra pertenece al año actual
            if (year === currentYear) {
                const mes = fecha.getMonth() + 1; // Mes de 1 a 12 (en lugar de 0-11)

                // Contabilizamos las muestras por mes
                if (!muestrasPorMes[mes]) {
                    muestrasPorMes[mes] = 0;
                }
                muestrasPorMes[mes]++;
            }
        });

        // Preparamos los datos para el gráfico de barras
        const mesesOrdenados = Object.keys(muestrasPorMes) // Obtener las claves (meses)
            .map(Number) // Convertir las claves a números
            .sort((a, b) => a - b); // Ordenar los meses de 1 a 12

        const cantidades = mesesOrdenados.map(mes => muestrasPorMes[mes]); // Obtener las cantidades de muestras para cada mes
        const nombresMeses = mesesOrdenados.map(mes => {
            const fecha = new Date(currentYear, mes - 1, 1); // Obtener el nombre del mes
            return fecha.toLocaleString('default', { month: 'long' }); // Formato: "Enero", "Febrero", etc.
        });

        // Configuración del gráfico de barras
        const barCtx = document.getElementById('barChart').getContext('2d');
        new Chart(barCtx, {
            type: 'bar',
            data: {
                labels: nombresMeses,  // Las etiquetas serán los meses (nombres de los meses)
                datasets: [{
                    label: 'Número de Muestras por Mes',
                    data: cantidades,  // Los datos son la cantidad de muestras por mes
                    backgroundColor: 'rgba(54, 162, 235, 0.6)',
                    borderColor: 'rgba(54, 162, 235, 1)',
                    borderWidth: 1
                }]
            },
            options: {
                responsive: true,
                scales: {
                    y: {
                        beginAtZero: true
                    }
                },
                plugins: {
                    tooltip: {
                        callbacks: {
                            label: function (tooltipItem) {
                                return `${tooltipItem.label}: ${tooltipItem.raw} muestras`;  // Muestra la cantidad en el tooltip
                            }
                        }
                    }
                }
            }
        });
    } catch (error) {
        console.error('Error al obtener los datos:', error);
    }
});

document.addEventListener('DOMContentLoaded', async () => {
    try {
        // Llamada al endpoint para obtener los datos
        const response = await fetch('https://localhost:7005/api/Muestra/GetAll');
        if (!response.ok) throw new Error(`Error HTTP: ${response.status}`);

        const data = await response.json();

        // Definir los estados y contadores para las muestras
        const estados = ['Pendiente', 'Cancelado', 'Informado'];  // Asumiendo que los estados son 1, 2, 3
        const counts = [0, 0, 0];  // Contadores para cada estado

        // Contar las muestras por estado
        data.forEach(item => {
            const estadoIndex = item.idTipoEstado - 1;  // El valor de idTipoEstado empieza en 1, por lo que restamos 1
            counts[estadoIndex]++;
        });

        // Configuración del gráfico de pastel
        const pieCtx = document.getElementById('pieChart').getContext('2d');
        new Chart(pieCtx, {
            type: 'pie',
            data: {
                labels: estados,  // Etiquetas de los estados
                datasets: [{
                    label: 'Distribución de Estados de Muestras',
                    data: counts,  // Los datos son los contadores de cada estado
                    backgroundColor: [
                        'rgba(255, 99, 132, 0.6)',  // Color para "Pendiente"
                        'rgba(54, 162, 235, 0.6)',  // Color para "Cancelado"
                        'rgba(75, 192, 192, 0.6)'   // Color para "Informado"
                    ],
                    borderColor: [
                        'rgba(255, 99, 132, 1)',
                        'rgba(54, 162, 235, 1)',
                        'rgba(75, 192, 192, 1)'
                    ],
                    borderWidth: 1
                }]
            },
            options: {
                responsive: true,
                plugins: {
                    legend: {
                        position: 'top',
                    },
                    tooltip: {
                        callbacks: {
                            label: function (tooltipItem) {
                                return `${tooltipItem.label}: ${tooltipItem.raw} muestras`;  // Muestra la cantidad en el tooltip
                            }
                        }
                    }
                }
            }
        });
    } catch (error) {
        console.error('Error al obtener los datos:', error);
    }
});