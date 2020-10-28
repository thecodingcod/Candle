import { animateOnHover } from "../helpers/animate";

export class Index {
  constructor() {
    // animate library item list on hover
    animateOnHover($(".lib-card"), "animate__pulse");
  }
}
