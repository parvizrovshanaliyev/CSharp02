
//#region deleted 
jQueryAjaxDeleteAndUndoDelete = (currentRow, url) => {
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
                    url: url,// Comment/Undodelete/2
                    /*data:{id:id}, Comment/Undodelete?id=id*/
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