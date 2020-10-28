"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Shelf = void 0;
var Shelf = /** @class */ (function () {
    function Shelf() {
        this.OwlCarouselPlugin();
    }
    // Configuring Shelf Carousel
    Shelf.prototype.OwlCarouselPlugin = function () {
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
    return Shelf;
}());
exports.Shelf = Shelf;
