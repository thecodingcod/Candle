"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Shelf = void 0;
var animate_1 = require("../helpers/animate");
var Shelf = /** @class */ (function () {
    function Shelf() {
        this.AnimateBookCardOnHover();
    }
    Shelf.prototype.AnimateBookCardOnHover = function () {
        animate_1.animateOnHover($('.book-card'), "animate__headShake");
    };
    return Shelf;
}());
exports.Shelf = Shelf;
