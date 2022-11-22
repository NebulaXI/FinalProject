jQuery.validator.addMethod("birthdate",
    function (value, element, param) {
        var now = new Date();
        var eighteen_years_ago = new Date(now.getFullYear() - 18, now.getMonth(), now.getDay());
        if (value < Date.now-Date) {
            return false;
        }
        else {
            return true;
        }
    });

jQuery.validator.unobtrusive.adapters.addBool("birthdate");