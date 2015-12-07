(function (window, $) {
    var tabMe = function (elem, options) {
        this.elem = elem;
        this.$elem = $(elem);
        this.options = options;
    };

    tabMe.prototype = {
        defaults: {
            container: 'tabMe',
            tabContainer: 'tabContainer',
            menuContainer: 'tabMeMenu',
            tab_class: 'tab'
        },
        init: function () {
            this.config = $.extend({}, this.defaults, this.options);
            this.createTabs(this);
            return this;
        },
        createTabs: function (main_cont) {
            var tab_class = this.config.tab_class;
            var container = document.createElement("div");
            $(container).attr('id', this.config.container);
            var tabContainer = document.createElement("div");
            $(tabContainer).attr('class', this.config.tabContainer);
            var clearDiv = document.createElement("div");
            $(clearDiv).attr('class', 'clear');

            var menuContainer = document.createElement("ul");
            $(menuContainer).attr('class', this.config.menuContainer);
            $(this.elem).find('.' + this.config.tab_class).each(function (index, element) {
                var menu_item = document.createElement('li');
                var menu_anchor = document.createElement('a');
                $(menu_anchor).attr('href', '#tab'+(index+1));
                $(menu_anchor).html(element.dataset.name);
                $(menu_anchor).on('click', function () {
                    event.preventDefault();
                    $(this).parent().addClass("current");
                    $(this).parent().siblings().removeClass("current");
                    var tab = $(this).attr("href");
                    $(".tab").not(tab).css("display", "none");
                    $(tab).fadeIn();;
                });
                menu_item.appendChild(menu_anchor);
                menuContainer.appendChild(menu_item);


                var tab = document.createElement('div');
                $(tab).attr('id', 'tab'+(index + 1));
                $(tab).attr('class', tab_class);
                $(tab).html($(element).html());
                $(tabContainer).append(tab);

            })

            $(container).append(menuContainer);
            $(container).append(tabContainer);
            $(container).append(clearDiv);

            $(main_cont.elem).html(container);
            $(".tab").not(':first-of-type').css("display", "none");
            $('.'+this.config.menuContainer+'>li:first-of-type').addClass("current");

        }
    };

    tabMe.defaults = tabMe.prototype.defaults;

    $.fn.tabMe = function (options) {
        return this.each(function () {
            new tabMe(this, options).init();
        });
    };

    window.tabMe = tabMe;
})(window, jQuery)