
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
                const deletedRow = $(`[name=${id}]`);
                $.ajax({
                    type: 'POST',
                    dataType: 'json',
                    url: `Comment/Delete/${id}`,
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
    entity.content = entity.content.length > 75 ? entity.content.substring(0, 75) + '...' : entity.content; 
    return [
        `
             <a class='btn text-primary btn-sm btn-update' onclick="showInPopup('Comment/Update/${entity.id}','Update')" data-id="${entity.id}"><i class='fa fa-edit'></i></a>
             <a class='btn text-danger btn-sm btn-delete' onclick="jQueryAjaxDelete(this)" data-id="${entity.id}"><i class="fa fa-trash"></i></a>
             <a class='btn text-primary btn-sm btn-detail' onclick="showInPopup('Comment/Detail/${entity.id}', 'Detail')" data-id="${entity.id}"><i class="fa fa-eye"></i></a>
        `,  
        entity.postTitle,
        entity.content,
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

//#endregion helper