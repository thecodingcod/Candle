// Animate Element On Hover
export function animateOnHover(
  element: JQuery<HTMLElement>,
  animateCssCls: string
) {
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
    }
  );
}
