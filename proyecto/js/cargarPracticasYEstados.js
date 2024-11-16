async function cargarPracticas() {
    try {
        const response = await fetch('https://localhost:7005/api/Practicas');
        const practicas = await response.json();

        console.log('Prácticas:', practicas); // Verifica que datos se están recibiendo

        const selectPractica = document.getElementById('practica');
        selectPractica.innerHTML = ''; 

        practicas.forEach(practica => {
            const option = document.createElement('option');
            option.value = practica; // Usamos el nombre como valor
            option.textContent = practica; // Usamos el nombre como texto visible
            selectPractica.appendChild(option);
        });
    } catch (error) {
        console.error('Error cargando prácticas:', error);
    }
}

async function cargarEstados() {
    try {
        const response = await fetch('https://localhost:7005/api/Estados');
        const estados = await response.json();

        console.log('Estados:', estados); // Verifica que datos se están recibiendo

        const selectEstado = document.getElementById('estado');
        selectEstado.innerHTML = '';

        estados.forEach(estado => {
            const option = document.createElement('option');
            option.value = estado; // Usamos el estado directamente
            option.textContent = estado; // Usamos el estado como texto visible
            selectEstado.appendChild(option);
        });
    } catch (error) {
        console.error('Error cargando estados:', error);
    }
}
document.addEventListener('DOMContentLoaded', () => {
    cargarPracticas();
    cargarEstados();
});