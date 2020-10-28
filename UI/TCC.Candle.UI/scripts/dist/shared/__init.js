"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.InitShared = void 0;
var plugins_1 = require("./plugins");
var sidebar_1 = require("./sidebar");
function InitShared() {
    // Activate Vendor Plugins
    new plugins_1.ActivateVendorPlugins();
    // Attach Sidebar
    new sidebar_1.Sidebar();
}
exports.InitShared = InitShared;
