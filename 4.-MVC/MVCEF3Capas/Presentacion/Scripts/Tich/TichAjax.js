function cargarAportacionesIMSS(id) {
    $.ajax({
        url: '/Alumnos/_AportacionesIMSS/' + id,
        type: 'GET',
        success: function (data) {
            $('#modalTitle').text("Calculo de IMSS");
            $('#cuerpoModal').html(data);
            $('#modalData').modal('show');
        },
        error: errorGenerico
    });
}

function eliminarEstatus(id) {
    $.ajax({
        url: '/EstatusAlumnos/Delete/' + id,
        type: 'GET',
        success: function (data) {
            $('#modalTitle').text("Eliminar Estatus");
            $('#cuerpoModal').html(data);
            $('#modalData').modal('show');
        },
        error: errorGenerico
    });
}

function confirmarEliminacionEstatus(id) {
    $.ajax({
        url: 'http://localhost:5218/api/EstatusAlumnos/' + id,
        type: 'DELETE',
        success: function () {
            $('#modalData').modal('hide');
            location.href = "http://localhost:53991/EstatusAlumnos/Index";
        },
        error: errorGenerico
    });
}

function cargarTablaISR(id) {
    $.ajax({
        url: '/Alumnos/_TablaISR/' + id,
        type: 'GET',
        success: function (data) {
            $('#modalTitle').text("Calculo de ISR");
            $('#cuerpoModal').html(data);
            $('#modalData').modal('show');

        },
        error: errorGenerico
        
    });
}



function errorGenerico(jqXHR, estatus, error) {
    var msg = '';
    if (jqXHR.status === 0) {
        msg = 'No está conectado, favor de verificar su conexión.';
    }
    else if (jqXHR.status === 404) {
        msg = 'Página no encontrada [404]';
    }
    else if (jqXHR.status === 500) {
        msg = 'Error no hay conexión al servidor [500]';
    }
    else if (jqXHR.status === 'parseerror') {
        msg = 'El parseo del JSON es erróneo.';
    }
    else if (jqXHR.status === 'timeout') {
        $('body').addClass('loaded');
    }
    else if (jqXHR.status === 'abort') {
        msg = 'La petición Ajax fue abortada.';
    }
    else {
        msg = 'Error no conocido. ';
        console.log(exception);
    }
    alert(msg);
}
