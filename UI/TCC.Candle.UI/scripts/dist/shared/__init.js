"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.InitShared = void 0;
var sidebar_1 = require("./sidebar");
function InitShared() {
    // Attach Sidebar
    new sidebar_1.Sidebar();
}
exports.InitShared = InitShared;
