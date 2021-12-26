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
                        modalPlaceHolderDiv.html(response);
                        modalPlaceHolderDiv.find('.modal').modal('show');
                    });
            });

        //#region create : ajax. post
        modalPlaceHolderDiv.on('click',
            '#btnSave',
            function(event) {
                event.preventDefault();
                //
                const form = $('#form');
                const actionUrl = form.attr('action');
                console.log(actionUrl);
                const data = form.serialize();
                console.log(data);
                $.post(actionUrl, data)
                    .done(function(response) {
                        const viewModel = response;
                        const formBody = $('.modal-body', viewModel.partial);
                        modalPlaceHolderDiv.find('.modal-body').replaceWith(formBody);
                        const isValid = formBody.find('[name="IsValid"]').val() === 'True';
                        if (isValid) {
                            modalPlaceHolderDiv.find('.modal').modal('hide');
                            const entity = viewModel.dto.entity;
                            // template literals
                            const newTableRowString = createNewRowStringTemplate(entity);
                            const newTableRowObject = $(newTableRowString);
                            newTableRowObject.hide();
                            $('#entitiesDataTable').append(newTableRowObject);
                            newTableRowObject.fadeIn(2500);
                            toastr.success(`${viewModel.dto.message}`, 'Success');
                        } else {
                            let summaryText = '\r\n';
                            $('#validationSummary > ul > li').each(function() {
                                let text = $(this).text();
                                summaryText += `\r\n*${text}\r\n`;
                            });
                            toastr.warning(summaryText);
                        }
                    });

            });
        //#endregion create : ajax. post
    });
    //#endregion modal and create
    //#region update
    $(function () {
        const url = 'Category/Update';
        const modalPlaceHolderDiv = $('#modalPlaceHolder');
        $(document).on('click', '.btn-update', function (event) {
            event.preventDefault();
            const id = $(this).attr('data-id');
            // ajax. getting partial view
            $.get(url, { id: id })
                .done(function (response) {
                    modalPlaceHolderDiv.html(response);
                    modalPlaceHolderDiv.find('.modal').modal('show');
                })
                .fail(function () {
                    toastr.error('Error!');
                });
        });
        //#region update : ajax. post
        modalPlaceHolderDiv.on('click',
            '#btnUpdate',
            function (event) {
                event.preventDefault();
                const form = $('#form');
                const actionUrl = form.attr('action');
                const data = form.serialize();
                $.post(actionUrl, data)
                    .done(function (response) {
                        const viewModel = response;
                        const formBody = $('.modal-body', viewModel.partial);
                        modalPlaceHolderDiv.find('.modal-body').replaceWith(formBody);
                        const isValid = formBody.find('[name="IsValid"]').val() === 'True';
                        if (isValid) {
                            modalPlaceHolderDiv.find('.modal').modal('hide');
                            const entity = viewModel.dto.entity;
                            // template literals
                            const newTableRowString = createNewRowStringTemplate(entity);
                            const newTableRowObject = $(newTableRowString);
                            console.log(`newRow`);
                            console.log(newTableRowObject);
                            newTableRowObject.hide();
                            const currentRow = $(`[name="${entity.id}"]`);
                            console.log(`currentRow`);
                            console.log(currentRow);
                            currentRow.replaceWith(newTableRowObject);
                            newTableRowObject.fadeIn(3500);
                            toastr.success(`${viewModel.dto.message}`, 'Success');
                        } else {
                            let summaryText = '';
                            $('#validationSummary > ul > li').each(function () {
                                let text = $(this).text();
                                summaryText = `* ${text}\n`;
                            });
                            toastr.warning(summaryText);
                        }
                    })
                    .fail(function (response) {

                    });
            });
        //#endregion ajax. post
    });
    //#endregion update
    //#region deleted 
    $(document).on('click', '.btn-delete',
        function () {
            event.preventDefault();
            const id = $(this).attr('data-id');
            const tableRow = $(`[name=${id}]`);
            Swal.fire({
                title: 'Are you sure?',
                text: "You won't be able to revert this!",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Yes, delete it!'
            }).then((result) => {
                if (result.isConfirmed) {
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        data: { id: id },
                        url: 'Category/Delete',
                        success: function (response) {
                            if (response.resultStatus === 0) {
                                Swal.fire(
                                    'Deleted!',
                                    `${response.message}`,
                                    'success'
                                );
                                tableRow.fadeOut(3000);
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Error!',
                                    text: `${response.message}`
                                });
                            }
                        },
                        error: function (error) {
                            console.log(error);

                        }
                    });

                }
            });
        });
    //#endregion
    //#region refresh load data
    function refreshData() {
        $.ajax({
            type: 'GET',
            url: 'Category/Refresh',
            contentType: 'application/json',
            beforeSend: function () {
                $('#entitiesDataTable').hide();
                $('.spinner-border').show(1000);
            },
            success: function (response) {
                const data = response;
                console.log(data);
                if (data.resultStatus === 0) {
                    let tableBody = '';
                    $.each(data.entities,
                        function (index, entity) {
                            tableBody += createNewRowStringTemplate(entity);
                        });

                    $('#entitiesDataTable > tbody').replaceWith(tableBody);
                    $('.spinner-border').hide();
                    $('#entitiesDataTable').fadeIn(1400);
                } else {
                    toastr.error(data.message, 'Fail!');
                }
            },
            error: function (error) {
                console.log(error);
                $('.spinner-border').hide();
                $('#entitiesDataTable').fadeIn(1000);
                toastr.error(error.responseText, 'Fail!');
            }
        });
    }
    //#endregion refresh load data
    //#region helper
    function createNewRowStringTemplate(entity) {
        const newTableRowString = `<tr name="${entity.id}">
                                                            <td>
                                                                 <a class="btn text-primary btn-sm btn-update" data-id="${entity.id}"><i class='fa fa-edit'></i></a>
                                                                 <a class="btn text-danger btn-sm btn-delete" data-id="${entity.id}"><i class="fa fa-trash"></i></a>
                                                            </td>
                                                            <td>${entity.id}</td>
                                                            <td>${entity.name}</td>
                                                            <td>${entity.description}</td>
                                                            <td>${convertFirstLetterToUpperCase(entity.isDeleted.toString())}</td>
                                                            <td>${convertFirstLetterToUpperCase(entity.isActive.toString())}</td>
                                                            <td>${convertToShortDate(entity.createdDate)}</td>
                                                            <td>${entity.createdByName}</td>
                                                            <td>${convertToShortDate(entity.modifiedDate)}</td>
                                                            <td>${entity.modifiedByName}</td>
                                                        </tr>`;
        return newTableRowString;
    }
    //#endregion helper
});

