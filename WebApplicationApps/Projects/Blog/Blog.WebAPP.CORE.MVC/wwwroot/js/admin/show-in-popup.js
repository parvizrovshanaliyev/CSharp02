showInPopup = (url, title) => {
    $.ajax({
        type: "GET",
        url: url,
        success: function(response) {
            $("#form-modal .modal-body").html(response);
            $("#form-modal .modal-title").html(title);
            $("#form-modal").modal("show");
            const container = document.getElementById("form-modal");
            const forms = container.getElementsByTagName("form");
            const newForm = forms[forms.length - 1];
            $.validator.unobtrusive.parse(newForm);
        },
        error: function(error) {
            console.log(error);
        }
    });
};


function clearModal() {
    $("#form-modal .modal-body").html("");
    $("#form-modal .modal-title").html("");
    $("#form-modal").modal("hide");
}