jQuery(document).ready(function() {
    jQuery('#mobile-burger').click(function () {
        if(jQuery(window).width() < 768) {
            jQuery('#mobile-menu').toggle();
        }
    })
   
    jQuery(".to-top").click(function () {
        jQuery('html, body').animate({
            scrollTop: jQuery("#root-container").offset().top
        }, 700);
    });
});