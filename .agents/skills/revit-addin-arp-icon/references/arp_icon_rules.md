# Technical Rules for ARPPRODUCTICON in WiX

When packaging a Revit Add-in into an MSI installer using the WiX Toolset, you can define a custom icon that Windows will display in the **Add/Remove Programs** (Control Panel) menu.

## The WiX Implementation

To add an icon to the Control Panel, you must include two elements inside the `<Product>` node of your `.wxs` file:

```xml
<Icon Id="AppIcon.ico" SourceFile="Resources\AppIcon.ico" />
<Property Id="ARPPRODUCTICON" Value="AppIcon.ico" />
```

### Critical Limitations

1. **Format:** The `SourceFile` must absolutely point to a valid `.ico` file. Windows Installer `msiexec` cannot process `.png` files for the ARP icon. If you attempt to pass a `.png` (even if you rename the extension to `.ico`), the `light.exe` linker will throw an error or the MSI will fail to display the icon.
2. **Id Naming:** The `Id` of the `<Icon>` element must exactly match the string defined in the `Value` attribute of the `<Property Id="ARPPRODUCTICON">`. It is highly recommended that the `Id` itself ends with `.ico` (as shown in the snippet above), as WiX specifically expects this extension in the Identifier to correctly map it in the registry.
3. **Resolution:** A standard `32x32` pixel icon is highly recommended as it scales well in the native Windows UI lists.

## Conversion Strategy

If the developer only possesses the 32x32 `.png` Ribbon icon (`RibbonIcon32.png`), it must be converted to `.ico` before compiling the MSI.
- If **ImageMagick** is installed locally, the agent can run: `magick convert RibbonIcon32.png -define icon:auto-resize=64,48,32,16 AppIcon.ico`
- If no CLI conversion tool is available, the agent must halt the installer generation process and ask the developer to convert the file externally using web tools or design software, and then provide the absolute path to the resulting `.ico`.
