// Avoid JqueryTypingMistakes: Not the best practice though!
declare var $:any;


export class Library {
  constructor() {
    this.OwlCarouselPlugin();
  }


  // Configuring Shelf Carousel
  OwlCarouselPlugin(): void {
    $(".owl-carousel").owlCarousel({
      loop: false,
      margin: 10,
      responsiveClass: true,
      responsive: {
        0: {
          items: 1,
          nav: true,
        },
        600: {
          items: 3,
          nav: false,
        },
        1000: {
          items: 5,
          nav: true,
          loop: false,
        },
      },
    });
  }
}
