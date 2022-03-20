$(document).ready(function() {

    //#region datatable
    const dataTable = $("#entitiesDataTable").DataTable({
        destroy: true,
        dom:
            "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
                "<'row'<'col-sm-12'tr>>" +
                "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        buttons: [
            {
                text: "Create",
                attr: {
                    id: "btnCreate"
                },
                className: "btn",
                action: function(e, dt, node, config) {
                }
            },
            {
                text: "Refresh",
                className: "btn btn-warning",
                action: function(e, dt, node, config) {
                    refreshData();
                }
            }
        ]
    });
    //#endregion datatable

    //#region create modal
    $(function() {
        const url = "Category/Create";
        const modalPlaceHolderDiv = $("#modalPlaceHolder");
        $("#btnCreate").unbind().click(function() {

            // ajax. getting partial view
            $.get(url).done(function(response) {
                modalPlaceHolderDiv.html(response);
                modalPlaceHolderDiv.find(".modal").modal("show");
            });
        });
        //#region create : ajax. post
        modalPlaceHolderDiv.unbind().on("click",
            "#btnSave",
            function(event) {
                event.preventDefault();
                const form = $("#form");
                const actionUrl = form.attr("action");
                const data = form.serialize();
                $.post({
                    url: actionUrl,
                    type: "POST",
                    data: data,
                    success: function(response) {
                        const formBody = $(".modal-body", response.partial);
                        modalPlaceHolderDiv.find(".modal-body").replaceWith(formBody);
                        const isValid = formBody.find('[name="IsValid"]').val() === "True";
                        if (isValid) {
                            modalPlaceHolderDiv.find(".modal").modal("hide");
                            const entity = response.result.data;
                            insertedRowToDataTable(entity);
                            toastr.success(`${response.result.message}`, "Success");
                        } else {
                            let summaryText = "";
                            $("#validationSummary > ul > li").each(function() {
                                const text = $(this).text();
                                summaryText = `* ${text}\n`;
                            });
                            toastr.warning(summaryText);
                        }
                    },
                    error: function(error) {
                        toastr.error(error.responseText, "Fail!");
                    }
                });
            });
        //#endregion ajax. post
    });
    //#endregion create modal

    //#region deleted 
    $(document).unbind().on("click",
        ".btn-delete",
        function() {
            event.preventDefault();
            const id = $(this).attr("data-id");
            const tableRow = $(`[name=${id}]`);
            Swal.fire({
                title: "Are you sure?",
                text: "You won't be able to revert this!",
                icon: "warning",
                showCancelButton: true,
                confirmButtonColor: "#3085d6",
                cancelButtonColor: "#d33",
                confirmButtonText: "Yes, delete it!"
            }).then((result) => {
                if (result.isConfirmed) {
                    $.ajax({
                        type: "POST",
                        dataType: "json",
                        data: { id: id },
                        url: "Category/Delete",
                        success: function(response) {
                            if (response.isSuccess) {
                                Swal.fire(
                                    "Deleted!",
                                    `${response.message}`,
                                    "success"
                                );
                                dataTable.row(tableRow).remove().draw();
                            } else {
                                Swal.fire({
                                    icon: "error",
                                    title: "Error!",
                                    text: `${response.message}`
                                });
                            }
                        },
                        error: function(error) {
                            toastr.error(error.responseText, "Fail!");
                        }
                    });

                }
            });
        });
    //#endregion

    //#region refresh load data
    function refreshData() {
        $.ajax({
            type: "GET",
            url: "Category/GetAll",
            contentType: "application/json",
            beforeSend: function() {
                $("#entitiesDataTable").hide();
                $(".spinner-border").show(1000);
            },
            success: function(response) {
                if (response.isSuccess) {
                    refreshDataTable(response.data);
                    $(".spinner-border").hide();
                    $("#entitiesDataTable").fadeIn(1400);
                } else {
                    toastr.error(response.errors.join(), "Fail!");
                }
            },
            error: function(error) {
                $(".spinner-border").hide();
                $("#entitiesDataTable").fadeIn(1000);
                toastr.error(error.responseText, "Fail!");
            }
        });
    }
    //#endregion refresh load data

    //#region update
    $(function() {
        const url = "Category/Update";
        const modalPlaceHolderDiv = $("#modalPlaceHolder");
        $(document).unbind().on("click",
            ".btn-update",
            function(event) {
                event.preventDefault();
                const id = $(this).attr("data-id");
                // ajax. getting partial view
                $.get(url, { id: id })
                    .done(function(response) {
                        modalPlaceHolderDiv.html(response);
                        modalPlaceHolderDiv.find(".modal").modal("show");
                    })
                    .fail(function() {
                        toastr.error("Error!");
                    });
            });
        //#region update : ajax. post
        modalPlaceHolderDiv.unbind().on("click",
            "#btnUpdate",
            function(event) {
                event.preventDefault();
                const form = $("#form");
                const actionUrl = form.attr("action");
                const data = form.serialize();
                $.ajax({
                    url: actionUrl,
                    type: "POST",
                    data: data,
                    success: function(response) {
                        const formBody = $(".modal-body", response.partial);
                        modalPlaceHolderDiv.find(".modal-body").replaceWith(formBody);
                        const isValid = formBody.find('[name="IsValid"]').val() === "True";
                        if (isValid) {
                            modalPlaceHolderDiv.find(".modal").modal("hide");
                            const entity = response.result.data;
                            const currentRow = $(`[name="${entity.id}"]`);
                            updatedDataTableRow(entity, currentRow);
                            console.log(response);
                            toastr.success(`${response.result.message}`, "Success");
                        } else {
                            let summaryText = "";
                            $("#validationSummary > ul > li").each(function() {
                                const text = $(this).text();
                                summaryText = `* ${text}\n`;
                            });
                            toastr.warning(summaryText);
                        }
                    },
                    error: function(error) {
                        toastr.error(error.responseText, "Fail!");
                    }
                });
            });
        //#endregion ajax. post
    });
    //#endregion update

    //#region helper
    function insertedRowToDataTable(entity) {

        const row = dataTable.row.add(makeDataTableRowObj(entity)).node();
        const rowObj = $(row);
        rowObj.attr("name", `${entity.id}`);
        dataTable.row(rowObj).draw();
    }

    function updatedDataTableRow(entity, currentRow) {

        const row = dataTable.row(currentRow).data(makeDataTableRowObj(entity)).node();
        currentRow.attr("name", `${entity.id}`);
        dataTable.row(currentRow).invalidate();
    }

    function refreshDataTable(entities) {

        dataTable.clear();

        $.each(entities,
            function(index, entity) {
                const row = dataTable.row.add(makeDataTableRowObj(entity)).node();
                const rowObj = $(row);
                rowObj.attr("name", `${entity.id}`);
            });

        dataTable.draw();
    }

    function makeDataTableRowObj(entity) {
        return [
            `
             <a class='btn text-primary btn-sm btn-update' data-id="${entity.id}"><i class='fa fa-edit'></i></a>
             <a class="btn text-danger btn-sm btn-delete" data-id="${entity.id}"><i class="fa fa-trash"></i></a>
             `,
            entity.id,
            entity.name,
            entity.description,
            convertFirstLetterToUpperCase(entity.isDeleted.toString()),
            convertFirstLetterToUpperCase(entity.isActive.toString()),
            convertToShortDate(entity.createdDate),
            entity.createdByName,
            convertToShortDate(entity.modifiedDate),
            entity.modifiedByName
        ];
    }
    //#endregion helper
});
//$(document).ready(function () {
//    const modalPlaceHolderDiv = $('#modalPlaceHolder');
//    //#region datatable
//    const dataTable = $('#entitiesDataTable').DataTable({
//        destroy: true,
//        dom:
//            "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
//            "<'row'<'col-sm-12'tr>>" +
//            "<'row'<'col-sm-5'i><'col-sm-7'p>>",
//        buttons: [
//            {
//                text: 'Create',
//                attr: {
//                    id: 'btnCreate'
//                },
//                className: 'btn',
//                action: function (e, dt, node, config) {
//                    fillToModalPlaceHolder('Category/Create');
//                }
//            },
//            {
//                text: 'Refresh',
//                className: 'btn btn-warning',
//                action: function (e, dt, node, config) {
//                    refreshData();
//                }
//            }
//        ]
//    });
//    //#endregion dataTable
//});

////#region create

//    //#region create : ajax. post
//    // To make sure a click only actions once use this: unbind()
//    $(document).on('click',
//        '#btnSave',
//        function (event) {
//            event.preventDefault();
//            console.log("created");
//            const form = $('#form');
//            const actionUrl = form.attr('action');
//            const data = form.serialize();
//            $.ajax({
//                url: actionUrl,
//                type: 'POST',
//                data: data,
//                success: function (response) {
//                    const formBody = $('.modal-body', response.partial);
//                    modalPlaceHolderDiv.find('.modal-body').replaceWith(formBody);
//                    const isValid = formBody.find('[name="IsValid"]').val() === 'True';
//                    if (isValid) {
//                        modalPlaceHolderDiv.find('.modal').modal('hide');
//                        const entity = response.result.data;
//                        insertedRowToDataTable(entity);
//                        toastr.success(`${response.result.message}`, 'Success');
//                    } else {
//                        let summaryText = '\r\n';
//                        $('#validationSummary > ul > li').each(function () {
//                            let text = $(this).text();
//                            summaryText += `\r\n*${text}\r\n`;
//                        });
//                        toastr.warning(summaryText);
//                    }
//                },
//                error: function (error) {
//                    toastr.error(error.responseText, 'Fail!');
//                }
//            });
//        });
//    //#endregion create : ajax. post
//    //#endregion modal and create

//    //#region update
//    $(document).unbind().on('click', '.btn-update', function (event) {
//        event.preventDefault();
//        const id = $(this).attr('data-id');
//        const url = `Category/Update?id=${id}`;
//        // ajax. getting partial view
//        fillToModalPlaceHolder(url);
//    });

//    //#region update : ajax. post
//    $(document).on('click',
//        '#btnUpdate',
//        function (event) {
//            event.preventDefault();
//            console.log("update");
//            const form = $('#form');
//            const actionUrl = form.attr('action');
//            const data = form.serialize();
//            $.ajax({
//                url: actionUrl,
//                type: 'POST',
//                data: data,
//                success: function (response) {
//                    const formBody = $('.modal-body', response.partial);
//                    modalPlaceHolderDiv.find('.modal-body').replaceWith(formBody);
//                    const isValid = formBody.find('[name="IsValid"]').val() === 'True';
//                    if (isValid) {
//                        modalPlaceHolderDiv.find('.modal').modal('hide');
//                        const entity = response.result.data;
//                        const currentRow = $(`[name="${entity.id}"]`);
//                        updatedDataTableRow(entity, currentRow);
//                        toastr.success(`${response.result.message}`, 'Success');
//                    } else {
//                        let summaryText = '';
//                        $('#validationSummary > ul > li').each(function () {
//                            let text = $(this).text();
//                            summaryText = `* ${text}\n`;
//                        });
//                        toastr.warning(summaryText);
//                    }
//                },
//                error: function (error) {
//                    toastr.error(error.responseText, 'Fail!');
//                }
//            });
//        });
//    //#endregion ajax. post

//    //#endregion update
//    //#region deleted 
//    $(document).on('click', '.btn-delete',
//        function () {
//            event.preventDefault();
//            const id = $(this).attr('data-id');
//            const tableRow = $(`[name=${id}]`);
//            Swal.fire({
//                title: 'Are you sure?',
//                text: "You won't be able to revert this!",
//                icon: 'warning',
//                showCancelButton: true,
//                confirmButtonColor: '#3085d6',
//                cancelButtonColor: '#d33',
//                confirmButtonText: 'Yes, delete it!'
//            }).then((result) => {
//                if (result.isConfirmed) {
//                    $.ajax({
//                        type: 'POST',
//                        dataType: 'json',
//                        data: { id: id },
//                        url: 'Category/Delete',
//                        success: function (response) {
//                            if (response.resultStatus === 0) {
//                                Swal.fire(
//                                    'Deleted!',
//                                    `${response.message}`,
//                                    'success'
//                                );
//                                tableRow.fadeOut(3000);
//                            } else {
//                                Swal.fire({
//                                    icon: 'error',
//                                    title: 'Error!',
//                                    text: `${response.message}`
//                                });
//                            }
//                        },
//                        error: function (error) {
//                            console.log(error);

//                        }
//                    });

//                }
//            });
//        });
//    //#endregion
//    //#region refresh load data
//    function refreshData() {
//        $.ajax({
//            type: 'GET',
//            url: 'Category/Refresh',
//            contentType: 'application/json',
//            beforeSend: function () {
//                $('#entitiesDataTable').hide();
//                $('.spinner-border').show(1000);
//            },
//            success: function (response) {
//                const data = response;
//                console.log(data);
//                if (data.resultStatus === 0) {
//                    let tableBody = '';
//                    $.each(data.entities,
//                        function (index, entity) {
//                            tableBody += createNewRowStringTemplate(entity);
//                        });

//                    $('#entitiesDataTable > tbody').replaceWith(tableBody);
//                    $('.spinner-border').hide();
//                    $('#entitiesDataTable').fadeIn(1400);
//                } else {
//                    toastr.error(data.message, 'Fail!');
//                }
//            },
//            error: function (error) {
//                console.log(error);
//                $('.spinner-border').hide();
//                $('#entitiesDataTable').fadeIn(1000);
//                toastr.error(error.responseText, 'Fail!');
//            }
//        });
//    }
//    //#endregion refresh load data
//    //#region helper
//    //#region fillToModalPlaceHolder
//    function fillToModalPlaceHolder(url) {
//        // ajax. getting partial view
//        $.get(url)
//            .done(function (response) {
//                modalPlaceHolderDiv.html('');
//                modalPlaceHolderDiv.html(response);
//                modalPlaceHolderDiv.find('.modal').modal('show');
//            }).fail(function () {
//                toastr.error('Error!');
//            });
//    }
//    //#endregion fillToModalPlaceHolder
//    function updatedDataTableRow(entity, currentRow) {
//        const row = dataTable.row(currentRow).data(makeDataTableRowObj(entity)).node();
//        currentRow.attr('name', `${entity.id}`);
//        dataTable.row(currentRow).invalidate();
//    }
//    function insertedRowToDataTable(entity) {
//        const row = dataTable.row.add(makeDataTableRowObj(entity)).node();
//        const rowObj = $(row);
//        rowObj.attr('name', `${entity.id}`);
//        dataTable.row(rowObj).draw();
//    }

//    function makeDataTableRowObj(entity) {
//        return [
//            `
//             <a class='btn text-primary btn-sm btn-update' data-id="${entity.id}"><i class='fa fa-edit'></i></a>
//             <a class="btn text-danger btn-sm btn-delete" data-id="${entity.id}"><i class="fa fa-trash"></i></a>
//             `,
//            entity.id,
//            entity.name,
//            entity.description,
//            convertFirstLetterToUpperCase(entity.isDeleted.toString()),
//            convertFirstLetterToUpperCase(entity.isActive.toString()),
//            convertToShortDate(entity.createdDate),
//            entity.createdByName,
//            convertToShortDate(entity.modifiedDate),
//            entity.modifiedByName
//        ];
//    }
//    function createNewRowStringTemplate(entity) {
//        const newTableRowString = `<tr name="${entity.id}">
//                                                            <td>
//                                                                 <a class="btn text-primary btn-sm btn-update" data-id="${entity.id}"><i class='fa fa-edit'></i></a>
//                                                                 <a class="btn text-danger btn-sm btn-delete" data-id="${entity.id}"><i class="fa fa-trash"></i></a>
//                                                            </td>
//                                                            <td>${entity.id}</td>
//                                                            <td>${entity.name}</td>
//                                                            <td>${entity.description}</td>
//                                                            <td>${convertFirstLetterToUpperCase(entity.isDeleted.toString())}</td>
//                                                            <td>${convertFirstLetterToUpperCase(entity.isActive.toString())}</td>
//                                                            <td>${convertToShortDate(entity.createdDate)}</td>
//                                                            <td>${entity.createdByName}</td>
//                                                            <td>${convertToShortDate(entity.modifiedDate)}</td>
//                                                            <td>${entity.modifiedByName}</td>
//                                                        </tr>`;
//        return newTableRowString;
//    }
//    //#endregion helper