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
