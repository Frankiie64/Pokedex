// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const BtnFiltro = document.getElementById('FiltroRegion');
const Filtro = document.getElementById('Filtro');
const Icon = document.getElementById('DownArrow');

function Mostrar() {

    if (Filtro.hidden == false) {
        BtnFiltro.innerHTML = `Abrir Filtro `;
        Icon.className = "fa-solid fa-arrow-down"
        BtnFiltro.appendChild(Icon);
        Filtro.hidden = true;
    }
    else {
        BtnFiltro.innerHTML = "Cerrar Filtro "
        Icon.className = "fa-solid fa-arrow-up"
        BtnFiltro.appendChild(Icon);
        Filtro.hidden = false;
    }
}




