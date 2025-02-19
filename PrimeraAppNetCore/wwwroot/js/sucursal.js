window.onload = function () {
    mostrar();
}

let obj = {
    url: '',
    cabeceras: ['Id', 'Nombre', 'Dirección'],
    propiedades: ['idSucursal', 'nombre', 'direccion']
}

async function mostrar() {
    obj.url = 'Sucursal/ListarSucursales';
    mostrarTabla(obj);
}

function filtrar() {
    /*let nombreSucursal = getValue('nombreSucursalInput');
    objSucursal.url = 'Sucursal/FiltrarSucursales?nombreFiltrar=' + nombreSucursal;
    mostrarTabla(objSucursal);*/

    let formData = new FormData(document.getElementById('formBuscar'));
    fetchPost('Sucursal/FiltrarSucursales', 'json', formData, (res) => {
        let tabla = document.createElement('table');
        document.getElementById('divtabla').innerHTML = '';
        document.getElementById('divtabla').appendChild(tabla);
        tabla.classList.add('table', 'table-striped', 'table-bordered');
        tabla.innerHTML = generarTabla(obj, res);
    });
}

function limpiar() {
    document.getElementById('formBuscar').reset();
    mostrar();
}