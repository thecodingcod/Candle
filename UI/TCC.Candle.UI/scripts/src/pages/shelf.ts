import { animateOnHover } from "../helpers/animate";

export class Shelf {
  constructor() {
      this.AnimateBookCardOnHover();
  }

  AnimateBookCardOnHover(): void {
      animateOnHover($('.book-card'),"animate__headShake");
  }
}
