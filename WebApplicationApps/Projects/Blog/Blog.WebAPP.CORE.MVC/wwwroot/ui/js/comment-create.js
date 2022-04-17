jQueryAjaxPost = form => {
    try {

        //// check created by val  same char invalid char
        //const createdBy = $('#createdBy').val();
        //const commentContent = $('#Content').val();

        //if (createdBy.length > 0 && createdBy.match(/[^a-zA-Z]/g)) {
        //    toastr.error('Created By is invalid');
        //    return false;
        //}

        const $form = $(form);
        $.validator.unobtrusive.parse($form);
        if ($form.valid()) {
            $.ajax({
                type: 'POST',
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (response) {
                    const newCardBody = $('.create-comment-card-body', response.partial);
                    $('.create-comment-card-body').replaceWith(newCardBody);
                    const isValid = newCardBody.find('[name="IsValid"]').val() === 'True';
                    if (isValid) {
                        const entity = response.result.data;
                        const newComment = `
                                            <div class="media mb-4">
                                                <img class="d-flex mr-3 rounded-circle" src="https://randomuser.me/api/portraits/men/34.jpg" alt="">
                                                <div class="media-body">
                                                    <h5 class="mt-0">${entity.createdByName}</h5>
                                                    ${entity.content}
                                                </div>
                                            </div>`;
                        const newCommentObj = $(newComment);
                        newCommentObj.hide();
                        $('.comments-list').prepend(newCommentObj);
                        newCommentObj.fadeIn(1000);

                        // form element reset
                        $('#CreatedBy').val('');
                        $('#Content').val('');


                        // disable add comment button
                        $('#add-btn').prop('disabled', true);
                        setTimeout(() => {
                                $('#add-btn').prop('disabled', false);
                            },
                            15000);
                        
                        toastr.success(`Your comment has been added successfully`, 'Success');

                    } else {
                        validationSummary();
                    }
                },
                error: function (err) {
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

//#region helper
function validationSummary() {
    let summaryText = '';
    $('#validationSummary > ul > li').each(function () {
        let text = $(this).text();
        summaryText += `*${text}   \n`;
    });
    toastr.warning(summaryText);
}

//#endregion helper