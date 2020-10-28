import { Index } from "./index";
import { Library } from "./library";
import { Shelf } from "./shelf";

export function InitPages() {
  new Index();
  new Library();
  new Shelf();
}
