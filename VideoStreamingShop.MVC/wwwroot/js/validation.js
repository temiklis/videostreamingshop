var settings = {
    validClass: "is-valid",
    errorClass: "is-invalid"

};
$.validator.setDefault(settings);
$.validator.unobtrusive.options = settings;