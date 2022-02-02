let dataTable;
$(document).ready(function () {
    dataTable = $('#dataTable').DataTable();
});

function insertedRowToDataTable(entity, rowItem) {
    console.log(rowItem);
    const row = dataTable.row.add(rowItem).node();
    const rowObj = $(row);
    rowObj.attr('name', `${entity.id}`);
    dataTable.row(rowObj).draw();
}

function updatedDataTableRow(entity, currentRow, rowItem) {

    // TODO: burada deyisklik olacaq

    const row = dataTable.row(currentRow).data(rowItem).node();
    currentRow.attr("name", `${entity.id}`);
    dataTable.row(currentRow).invalidate();
}
