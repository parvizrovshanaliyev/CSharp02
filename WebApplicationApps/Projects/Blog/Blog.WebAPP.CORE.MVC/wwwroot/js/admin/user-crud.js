jQueryAjaxPost = form => {
    try {
        const $form = $(form);
        if ($form.valid()) {
            $.ajax({
                type: "POST",
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function(response) {
                    $("#form-modal .modal-body").html(response.partial);
                    const isValid = $("#form-modal .modal-body").find('[name="IsValid"]').val() === "True";
                    if (isValid) {
                        clearModal();
                        const entity = response.result.data;

                        if (response.action) // create
                        {
                            insertedRowToDataTable(entity, makeDataTableRowObj(entity));
                        } else if(response.action===false) // update
                        {
                            const currentRow = $(`[name="${entity.id}"]`);
                            updateDataTableRow(entity, currentRow, makeDataTableRowObj(entity));
                        }
                        response.result.message ??= 'Success';
                        toastr.success(`${response.result.message}`, 'Success');
                    } else {
                        validationSummary();
                    }
                },
                error: function(error) {
                    toastr.error(error.responseText, "Fail!");
                }
            });
        }
        // to prevent default form submit event
        return false;
    } catch (e) {
        console.log(e);
    }
    // to prevent default form submit event
    return false;
};


jQueryAjaxDelete = currentRow => {
    event.preventDefault();
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
            try {
                const id = $(currentRow).attr("data-id");
                const deletedRow = $(`[name=${id}]`);
                $.ajax({
                    type: "POST",
                    dataType: "json",
                    data: { id: id },
                    url: "User/Delete",
                    success: function(response) {
                        if (response.isSuccess) {
                            Swal.fire(
                                "Deleted!",
                                `${response.message}`,
                                "success"
                            );
                            deletedRow.fadeOut(3000);
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
            } catch (e) {

            }
        }
    });
};


//#region heplers
function makeDataTableRowObj(entity) {
    return [
        `
             <a class='btn text-primary btn-sm btn-update'  onclick="showInPopup('User/Update?id=${entity.id}','Update')" data-id="${entity.id}"><i class='fa fa-edit'></i></a>
             <a class="btn text-danger btn-sm btn-delete"  onclick="jQueryAjaxDelete(this)" data-id="${entity.id}"><i class="fa fa-trash"></i></a>
             <a class='btn text-primary btn-sm btn-detail' onclick="showInPopup('User/Detail/${entity.id}', 'Detail')" data-id="${entity.id}"><i class="fa fa-eye"></i></a>
             <a class='btn text-primary btn-sm btn-assign' onclick="showInPopup('Role/Assign/${entity.id}', 'Assigning a role to user')" data-id="${entity.id}"><i class="fa fa-user-shield"></i></a>
`,
        entity.id,
        entity.userName,
        entity.email,
        entity.phoneNumber,
        `<img alt="${entity.userName}" class="datatable-image" src="/img/${entity.avatar}"/>`
    ];
}

function validationSummary() {
    let summaryText = "";
    $("#validationSummary > ul > li").each(function() {
        const text = $(this).text();
        summaryText += `*${text} \n`;
    });
    toastr.warning(summaryText);
}
//#endregion