// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $('#myTable').DataTable({
        "scrollCollapse": true,
        "scrollX": "450px",
        "paging": true
    });
    $('#flightsTable').DataTable({
        "scrollCollapse": true,
        "scrollX": "450px",
        "paging": true
    });
    $('#reservationsTable').DataTable({
        "paging": true,
        "scrollCollapse": true,
        "scrollX": "450px",
    });
});


//"scrollY": "450px",
//    "scrollCollapse": true,