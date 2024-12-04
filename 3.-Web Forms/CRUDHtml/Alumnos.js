document.addEventListener('DOMContentLoaded', () => {
    const alumnos = [
        { id: 1, nombre: 'Juan Pérez', edad: 21, estado: 'CDMX' },
        { id: 2, nombre: 'María López', edad: 22, estado: 'Jalisco' },
        { id: 3, nombre: 'Carlos García', edad: 23, estado: 'Nuevo León' }
    ];

    const estados = [
        { id: 'CDMX', nombre: 'Ciudad de México' },
        { id: 'Jalisco', nombre: 'Jalisco' },
        { id: 'Nuevo León', nombre: 'Nuevo León' }
    ];

    const idInput = document.getElementById('id');
    const nombreInput = document.getElementById('nombre');
    const edadInput = document.getElementById('edad');
    const estadoSelect = document.getElementById('selectEstado');
    const estatusCheckbox = document.getElementById('chkEstatus');
    const consultarButton = document.getElementById('consultar');

    cargarEstados();

    consultarButton.addEventListener('click', manejarConsulta);

    function cargarEstados() {
        estados.forEach(estado => {
            const option = document.createElement('option');
            option.value = estado.id;
            option.textContent = estado.nombre;
            estadoSelect.appendChild(option);
        });
    }

    function manejarConsulta() {
        if (consultarButton.textContent == 'Consultar') {
            consultarAlumno();
        } else if (consultarButton.textContent == 'Guardar') {
            guardarAlumno();
        }
    }

    function consultarAlumno() {
        const id = idInput.value.trim();
        if (id == '') {
            alert('Por favor, ingrese un ID.');
            return;
        }

        const alumno = alumnos.find(alumno => alumno.id == id);
        if (!alumno) {
            alert('Alumno no encontrado.');
            return;
        }

        llenarDatosAlumno(alumno);
        habilitarCampos();
        consultarButton.textContent = 'Guardar';
    }

    function llenarDatosAlumno(alumno) {
        nombreInput.value = alumno.nombre;
        edadInput.value = alumno.edad;
        estadoSelect.value = alumno.estado;
        estatusCheckbox.checked = true;
    }

    function habilitarCampos() {
        nombreInput.disabled = false;
        edadInput.disabled = false;
        estadoSelect.disabled = false;
        estatusCheckbox.disabled = false;
        idInput.disabled = true;
    }

    function guardarAlumno() {
        alert('Actualización exitosa');
        limpiarCampos();
        deshabilitarCampos();
        consultarButton.textContent = 'Consultar';
    }

    function limpiarCampos() {
        idInput.value = '';
        nombreInput.value = '';
        edadInput.value = '';
        estadoSelect.value = 'default';
        estatusCheckbox.checked = false;
    }

    function deshabilitarCampos() {
        nombreInput.disabled = true;
        edadInput.disabled = true;
        estadoSelect.disabled = true;
        estatusCheckbox.disabled = true;
        idInput.disabled = false;
    }
});
