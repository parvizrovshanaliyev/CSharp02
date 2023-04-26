let dataTable;
$(document).ready(function() {
    dataTable = $("#dataTable").DataTable();
});

function insertedRowToDataTable(entity, rowItem) {
    const row = dataTable.row.add(rowItem).node();
    const rowObj = $(row);
    rowObj.attr("name", `${entity.Id}`);
    dataTable.row(rowObj).draw();
}

function updateDataTableRow(entity, currentRow, rowItem) {
    dataTable.row(currentRow).data(rowItem).node();
    currentRow.attr("name", `${entity.id}`);
    dataTable.row(currentRow).invalidate();
}