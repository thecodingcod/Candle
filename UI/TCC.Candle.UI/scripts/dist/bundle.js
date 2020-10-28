(function(){function r(e,n,t){function o(i,f){if(!n[i]){if(!e[i]){var c="function"==typeof require&&require;if(!f&&c)return c(i,!0);if(u)return u(i,!0);var a=new Error("Cannot find module '"+i+"'");throw a.code="MODULE_NOT_FOUND",a}var p=n[i]={exports:{}};e[i][0].call(p.exports,function(r){var n=e[i][1][r];return o(n||r)},p,p.exports,r,e,n,t)}return n[i].exports}for(var u="function"==typeof require&&require,i=0;i<t.length;i++)o(t[i]);return o}return r})()({1:[function(require,module,exports){
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

},{}],2:[function(require,module,exports){
"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var __init_1 = require("./shared/__init");
var __init_2 = require("./pages/__init");
__init_1.InitShared();
__init_2.InitPages();

},{"./pages/__init":3,"./shared/__init":5}],3:[function(require,module,exports){
"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.InitPages = void 0;
var index_1 = require("./index");
function InitPages() {
    // Attach Index
    new index_1.Index();
}
exports.InitPages = InitPages;

},{"./index":4}],4:[function(require,module,exports){
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

},{"../helpers/animate":1}],5:[function(require,module,exports){
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

},{"./plugins":6,"./sidebar":7}],6:[function(require,module,exports){
"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ActivateVendorPlugins = void 0;
var ActivateVendorPlugins = /** @class */ (function () {
    function ActivateVendorPlugins() {
        this.JQueryPlugins();
        this.BootstrapPlugins();
        this.FontAwesomePlugins();
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
    return ActivateVendorPlugins;
}());
exports.ActivateVendorPlugins = ActivateVendorPlugins;

},{}],7:[function(require,module,exports){
"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Sidebar = void 0;
var Sidebar = /** @class */ (function () {
    function Sidebar() {
        // Dom elements
        this.element = $("#sidebar");
        this.menuToggler = $(".sidebarToggler");
        // properties
        this.state = false;
        // SetupEventListeners for Sidebar
        this.SetupEventHandlers();
    }
    Sidebar.prototype.Toggle = function () {
        console.log("fired");
        this.AnimateToggle();
    };
    Sidebar.prototype.Show = function () {
        if (!this.state) {
            console.log("fires");
            this.AnimateShow();
            this.state = true;
        }
    };
    Sidebar.prototype.Hide = function () {
        if (this.state) {
            console.log("fireh");
            this.AnimateHide();
            this.state = false;
        }
    };
    Sidebar.prototype.AnimateShow = function () {
        event === null || event === void 0 ? void 0 : event.preventDefault();
        if (!this.state)
            this.element.show();
        this.element.removeClass("animate__slideOutLeft");
        this.element.addClass("animate__slideInLeft");
    };
    Sidebar.prototype.AnimateHide = function () {
        event === null || event === void 0 ? void 0 : event.preventDefault();
        this.element.removeClass("animate__slideInLeft");
        this.element.addClass("animate__slideOutLeft");
    };
    Sidebar.prototype.AnimateToggle = function () {
        if (this.state) {
            this.AnimateHide();
            this.state = !this.state;
        }
        else {
            this.AnimateShow();
            this.state = !this.state;
        }
    };
    Sidebar.prototype.SetupEventHandlers = function () {
        // OnWindowLoad
        var _this = this;
        //On Document Ready
        $(function () {
            _this.element.hide();
            _this.element.addClass("animate__animated");
        });
        //Toggler: OnClick
        this.menuToggler.on("click", this.Toggle.bind(this));
        //Document: OnClick
        $("#content").on("click", this.Hide.bind(this));
    };
    return Sidebar;
}());
exports.Sidebar = Sidebar;

},{}]},{},[2]);
