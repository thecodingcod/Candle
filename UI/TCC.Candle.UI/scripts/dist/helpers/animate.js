"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.animateOnHover = void 0;
// Animate Element On Hover
function animateOnHover(element, animateCssCls) {
    element.hover(
    // Handler In
    function () {
        this.classList.add("animate__animated");
        this.classList.add(animateCssCls);
    }, 
    // Handler Out
    function () {
        this.classList.remove("animate__animated");
        this.classList.remove(animateCssCls);
    });
}
exports.animateOnHover = animateOnHover;
