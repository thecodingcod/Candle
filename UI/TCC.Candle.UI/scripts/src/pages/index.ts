import { animateOnHover } from "../helpers/animate";

export class Index {
  constructor() {
    this.AnimateLibraryItemOnHover();
  }

  AnimateLibraryItemOnHover(): void {
    // animate library item list on hover
    animateOnHover($(".lib-card"), "animate__pulse");
  }
}
