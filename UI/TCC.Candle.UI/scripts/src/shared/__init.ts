import { ActivateVendorPlugins } from "./plugins";
import { Sidebar } from "./sidebar";

export function InitShared() {
  // Activate Vendor Plugins
  new ActivateVendorPlugins();

  // Attach Sidebar
  new Sidebar();
}
