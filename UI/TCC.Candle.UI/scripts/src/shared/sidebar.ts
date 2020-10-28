export class Sidebar {
  constructor() {
    // Dom elements
    this.element = $("#sidebar")! as JQuery<HTMLDivElement>;
    this.menuToggler = $(".sidebarToggler");

    // properties
    this.state = false;

    // SetupEventListeners for Sidebar
    this.SetupEventHandlers();
  }

  private state: boolean;
  private element: JQuery<HTMLDivElement>;
  private menuToggler: JQuery<HTMLDivElement>;

  Toggle(): void {
    console.log("fired");
    this.AnimateToggle();
  }

  Show(): void {
    if (!this.state) {
      console.log("fires");
      this.AnimateShow();
      this.state = true;
    }
  }

  Hide(): void {
    if (this.state) {
      console.log("fireh");
      this.AnimateHide();
      this.state = false;
    }
  }

  AnimateShow(): void {
    event?.preventDefault();
    if (!this.state) this.element.show();
    this.element.removeClass("animate__slideOutLeft");
    this.element.addClass("animate__slideInLeft");
  }

  AnimateHide(): void {
    event?.preventDefault();
    this.element.removeClass("animate__slideInLeft");
    this.element.addClass("animate__slideOutLeft");
  }

  AnimateToggle(): void {
    if (this.state) {
      this.AnimateHide();
      this.state = !this.state;
    } else {
      this.AnimateShow();
      this.state = !this.state;
    }
  }

  SetupEventHandlers(): void {
    // OnWindowLoad

    //On Document Ready
    $(() => {
      this.element.hide();
      this.element.addClass("animate__animated");
    });

    //Toggler: OnClick
    this.menuToggler.on("click", this.Toggle.bind(this));

    //Document: OnClick
    $("#content").on("click", this.Hide.bind(this));
  }
}
