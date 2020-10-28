// Media Query Helper
enum BreakPoints {
  xsmall,
  small,
  medium,
  large,
  xlarge,
}

class MediaQueryHelper {
  static getBreakPoint() {
    return window
      .getComputedStyle(document.body, ":before")
      .content.replace(/\"/g, "");
  }
}

abstract class MediaQueryHandler {
  constructor() {
    this.SetupEventListeners();
    this.breakPoint = MediaQueryHelper.getBreakPoint();
  }

  // Fields
  private breakPoint: string;

  // properities
  public set BreakPoint(value: string) {
    this.breakPoint = value;
  }

  // Methods
  SetupEventListeners() {
    window.addEventListener("resize", this.OnWindowResize.bind(this));
    document.onreadystatechange = () => {
      if (document.readyState === "complete") {
        this.OnWindowResize();
      }
    };
  }

  OnWindowResize(): void {
    this.breakPoint = MediaQueryHelper.getBreakPoint();
    this.OnBreakPointChange(this.breakPoint);
  }

  OnBreakPointChange(breakpoint: string) {
    if (breakpoint === BreakPoints[BreakPoints.xsmall]) {
      this.OnXSmallScreens();
    } else if (breakpoint === BreakPoints[BreakPoints.small]) {
      this.OnSmallScreens();
    } else if (breakpoint === BreakPoints[BreakPoints.medium]) {
      this.OnMediumScreens();
    } else if (breakpoint === BreakPoints[BreakPoints.large]) {
      this.OnLargeScreens();
    } else if (breakpoint === BreakPoints[BreakPoints.xlarge]) {
      this.OnLargeScreens();
    }
  }

  abstract OnXSmallScreens(): void;
  abstract OnSmallScreens(): void;
  abstract OnMediumScreens(): void;
  abstract OnLargeScreens(): void;
  abstract OnXLargeScreens(): void;
}

// Book Page
class Book extends MediaQueryHandler {
  constructor() {
    super();
    this.cover = document.querySelector("#book__cover")! as HTMLImageElement;
    this.height = this.cover.height;
    this.width = this.cover.width;
  }

  // fields
  private cover: HTMLImageElement;
  private width: number;
  private height: number;

  OnXSmallScreens(): void {
    throw new Error("Method not implemented.");
  }
  OnSmallScreens(): void {
    throw new Error("Method not implemented.");
  }
  OnMediumScreens(): void {
    throw new Error("Method not implemented.");
  }
  OnLargeScreens(): void {
    throw new Error("Method not implemented.");
  }
  OnXLargeScreens(): void {
    throw new Error("Method not implemented.");
  }
}
