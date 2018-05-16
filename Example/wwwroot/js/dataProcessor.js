/// <reference path="../lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive.js" />
jQuery(document).ready(function ($) {
    $('#add-contact').on('click', function () {
        jQuery.get('/DataProcessors/AddContact').done(function (html) {
            console.log(html);
            $('#contact-list').append(html);
        });
    });

    $(document).on('click', ".contact-remove", function () {
        $(this).parent().parent().parent().remove();
    });
});