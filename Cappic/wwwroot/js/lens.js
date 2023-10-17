
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/lens/getall' },
        "columns": [
            { data: 'name', "width": "20%" },
            { data: 'type', "width": "15%" },
            { data: 'description', "width": "20%" },
            { data: 'serialNumber', "width": "15%" },
            { data: 'price', "width": "15%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                                <a href="/admin/lens/edit?id=${data}" class="btn btn-dark mx-2">
                                    <i class="bi bi-pencil-square"></i> Edit
                                </a>
                                <a href="/admin/lens/delete?id=${data}" class="btn btn-danger mx-2">
                                    <i class="bi bi-trash-fill"></i> Delete
                                </a>
                            </div>`
                },
                "width": "15%"
            }
        ]
    });
}