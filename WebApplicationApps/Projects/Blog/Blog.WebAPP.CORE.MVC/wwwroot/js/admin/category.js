$(document).ready(function () {

    //#region dataTable
    $('#entitiesDataTable').DataTable({
        dom:
            "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
                "<'row'<'col-sm-12'tr>>" +
                "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        buttons: [
            {
                text: 'Create',
                attr: {
                    id: "btnCreate"
                },
                className: 'btn',
                action: function (e, dt, node, config) {
                    /*alert('Button create');*/
                }
            },
            {
                text: 'Refresh',
                className: 'btn btn-warning',
                action: function (e, dt, node, config) {
                    alert('Button refresh');
                }
            }
        ]
    });
    //#endregion dataTable

    //#region modal and create
    $(function () {

        // var , let , const 
        const url = 'Category/Create';
        const modalPlaceHolderDiv = $('#modalPlaceHolder');
        $('#btnCreate').click(  
            function () {
                // ajax. getting partial view
                $.get(url)
                    .done(function (response) {
                        console.log(response);
                        modalPlaceHolderDiv.html(response);
                        modalPlaceHolderDiv.find('.modal').modal('show');
                    });
            });
    });
    //#endregion modal and create

});