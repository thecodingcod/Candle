// Avoid JqueryTypingMistakes: Not the best practice though!
declare var $: any;

export class ActivateVendorPlugins {
  constructor() {
    this.JQueryPlugins();
    this.BootstrapPlugins();
    this.FontAwesomePlugins();
  }

  BootstrapPlugins(): void {
    // Enable Boostrap Tooltop
    $(function () {
      $('[data-toggle="tooltip"]').tooltip();
    });
  }

  JQueryPlugins(): void {}

  FontAwesomePlugins(): void {
    // Activate Psuedo icons
  }
}
