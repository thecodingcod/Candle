"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Library = void 0;
var Library = /** @class */ (function () {
    function Library() {
        this.OwlCarouselPlugin();
    }
    // Configuring Shelf Carousel
    Library.prototype.OwlCarouselPlugin = function () {
        $(".owl-carousel").owlCarousel({
            loop: false,
            margin: 10,
            responsiveClass: true,
            responsive: {
                0: {
                    items: 1,
                    nav: true,
                },
                600: {
                    items: 3,
                    nav: false,
                },
                1000: {
                    items: 5,
                    nav: true,
                    loop: false,
                },
            },
        });
    };
    return Library;
}());
exports.Library = Library;
