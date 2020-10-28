"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Index = void 0;
var animate_1 = require("../helpers/animate");
var Index = /** @class */ (function () {
    function Index() {
        // animate library item list on hover
        animate_1.animateOnHover($(".lib-card"), "animate__pulse");
    }
    return Index;
}());
exports.Index = Index;
