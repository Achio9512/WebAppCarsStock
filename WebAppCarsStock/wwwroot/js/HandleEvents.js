var sendButton = document.querySelector(".contact100-form-btn");

if (sendButton) {
    sendButton.addEventListener("click", function (event) {
        var formContainer = document.querySelector("[data-form-container]");
        var dataInputs = "";
        if (formContainer) {
            dataInputs = jQuery(formContainer).find("#firstName,#lastName,#phone,#carName,#carPrice,#comments,#carName").serialize();
        }
        
        jQuery.ajax({
            url: "/GetCarsDetails",
            type: "get",
            cache: true,
            data: dataInputs,
            success: function (data) {
                window.alert(data);
            }
        });
    });
}