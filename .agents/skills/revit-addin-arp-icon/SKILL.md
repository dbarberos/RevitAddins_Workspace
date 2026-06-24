---
name: revit-addin-arp-icon
description: Manages the integration of the Add/Remove Programs (Control Panel) Icon for Revit Add-in MSI installers. Use this to ensure the Windows Control Panel displays the app's custom icon when installed.
---

# Revit Add-in Control Panel Icon (ARPPRODUCTICON)

This skill automates the configuration of the `ARPPRODUCTICON` property in WiX-based `.msi` installers. By enforcing this standard, any generated Revit add-in will display its own custom icon in the Windows "Programs and Features" list, providing a professional native application experience.

## 🚨 Mandatory Critical Rules
1. **Icon Format Restriction:** WiX `ARPPRODUCTICON` strictly requires a valid `.ico` file (Standard Windows Icon format). It cannot use `.png`, `.jpg`, or any other image format directly.
2. **Path and Naming Convention:** The agent must ensure an icon named `AppIcon.ico` is placed inside the installer's `Resources/` directory (e.g., `InstallManagerFolder/Resources/AppIcon.ico`).
3. **Proactive Prompting:** When preparing an MSI installer, the agent must check if an `AppIcon.ico` file exists. If it does not exist, the agent must ask the user to provide the absolute path to an existing `.ico` or a `.png` file.
   - If the user provides a `.png`, the agent must suggest a strategy to convert it to `.ico` (e.g., using ImageMagick if available on the system) or instruct the user to convert it manually.
4. **Integration with WiX:** The agent must ensure the `ProductTemplate.wxs` (or the specific project `.wxs` file) includes both the `<Icon>` element and the `ARPPRODUCTICON` property referencing the local `.ico` file.

## 📚 Technical References
For detailed information on WiX requirements for icons, consult the references folder:
*   `references/arp_icon_rules.md`: Explanation of the `ARPPRODUCTICON` limitations and WiX compilation rules.

## 📦 Assets
*There are no static assets for this skill, as the icon depends on each specific application. Ensure the icon is provided dynamically per project.*
