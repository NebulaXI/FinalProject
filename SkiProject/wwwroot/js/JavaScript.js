jQuery.validator.addMethod("unique",
    function (value, element, param) {
        var now =
            element
        if (value < Date.now - Date) {
            return false;
        }
        else {
            return true;
        }
    });

jQuery.validator.unobtrusive.adapters.addBool("unique");