"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ActivateVendorPlugins = void 0;
var ActivateVendorPlugins = /** @class */ (function () {
    function ActivateVendorPlugins() {
        this.JQueryPlugins();
        this.BootstrapPlugins();
        this.FontAwesomePlugins();
        this.OwlCarouselPlugin();
    }
    ActivateVendorPlugins.prototype.BootstrapPlugins = function () {
        // Enable Boostrap Tooltop
        $(function () {
            $('[data-toggle="tooltip"]').tooltip();
        });
    };
    ActivateVendorPlugins.prototype.JQueryPlugins = function () { };
    ActivateVendorPlugins.prototype.FontAwesomePlugins = function () {
        // Activate Psuedo icons
    };
    ActivateVendorPlugins.prototype.OwlCarouselPlugin = function () {
        $(document).ready(function () {
            $('.owl-carousel').owlCarousel();
        });
    };
    return ActivateVendorPlugins;
}());
exports.ActivateVendorPlugins = ActivateVendorPlugins;
