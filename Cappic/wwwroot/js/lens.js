
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/product/getall' },
        "columns": [
            { data: 'name', "width": "25%" },
            { data: 'type', "width": "15%" },
            { data: 'description', "width": "10%" },
            { data: 'serialNumber', "width": "20%" },
            { data: 'price', "width": "15%" }
        ]
    });
}