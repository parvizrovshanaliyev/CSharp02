showInPopup = (url, title) => {
    $.ajax({
        type: 'GET',
        url: url,
        success: function (response) {
            $('#form-modal .modal-body').html(response);
            $('#form-modal .modal-title').html(title);
            $('#form-modal').modal('show');
            var container = document.getElementById("form-modal");
            var forms = container.getElementsByTagName("form");
            var newForm = forms[forms.length - 1];
            $.validator.unobtrusive.parse(newForm);
            // to make popup draggable
            //$('.modal-dialog').draggable({
            //    handle: ".modal-header"
            //});
        },
        error: function (error) {

        }
    });
}

jQueryAjaxPost = form => {
    try {
        const $form = $(form);
        if ($form.valid()) {
            $.ajax({
                type: 'POST',
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function(response) {
                    $('#form-modal .modal-body').html(response.partial);
                    const isValid = $('#form-modal .modal-body').find('[name="IsValid"]').val() === 'True';
                    if (isValid) {
                        clearModal();
                        const entity = response.result.data;
                        alert(response.action);
                        if (response.action) {
                            insertedRowToDataTable(entity, makeDataTableRowObj(entity));
                        } else {
                            const currentRow = $(`[name="${entity.id}"]`);
                            updatedDataTableRow(entity, currentRow, makeDataTableRowObj(entity));
                        }
                        toastr.success(`${response.result.message}`, 'Success');
                    } else {
                        validationSummary();
                    }
                },
                error: function(err) {
                    toastr.error(error.responseText, 'Fail!');
                }
            });
        }
        //to prevent default form submit event
        return false;
    } catch (ex) {
        console.log(ex);
    }
    return false;
}
//#region deleted 
jQueryAjaxDelete = currentRow => {
    event.preventDefault();
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
            try {
                const id = $(currentRow).attr('data-id');
                console.log(id);
                const deletedRow = $(`[name=${id}]`);
                $.ajax({
                    type: 'POST',
                    dataType: 'json',
                    data: { id: id },
                    url: 'Category/Delete',
                    success: function (response) {
                        if (response.isSuccess) {
                            Swal.fire(
                                'Deleted!',
                                `${response.message}`,
                                'success'
                            );
                            deletedRow.fadeOut(3000);
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

            } catch (ex) {
                console.log(ex);
            }
        }
    });

}
//#endregion

//#region helper
function makeDataTableRowObj(entity) {
    return [
        `
             <a class='btn text-primary btn-sm btn-update' onclick="showInPopup('Category/Update?id=${entity.id}','Update')" data-id="${entity.id}"><i class='fa fa-edit'></i></a>
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

function validationSummary() {
    let summaryText = '';
    $('#validationSummary > ul > li').each(function () {
        let text = $(this).text();
        summaryText += `*${text}   \n`;
    });
    toastr.warning(summaryText);
}

function clearModal() {
    $('#form-modal .modal-body').html('');
    $('#form-modal .modal-title').html('');
    $('#form-modal').modal('hide');
}
//#endregion helper