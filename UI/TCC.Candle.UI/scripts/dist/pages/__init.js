"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.InitPages = void 0;
var index_1 = require("./index");
var shelf_1 = require("./shelf");
function InitPages() {
    new index_1.Index();
    new shelf_1.Shelf();
}
exports.InitPages = InitPages;
