jQuery(document).ready(function() {
    jQuery('#mobile-burger').click(function () {
        if(jQuery(window).width() < 768) {
            jQuery('#mobile-menu').toggle();
        }
    })
    jQuery('#nav-profile').click(function () {
        if (jQuery(window).width() < 768) {
            jQuery('#user-actions').toggle();
        }
    })
});