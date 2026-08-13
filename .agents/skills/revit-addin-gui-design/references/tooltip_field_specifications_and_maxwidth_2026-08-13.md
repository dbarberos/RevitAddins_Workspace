# Standardized WPF ToolTip Design System for Add-in Configuration Forms

## 1. Guideline & UX Constraints
When designing user-facing configuration dialogs (such as Family Source Settings), all input labels (`TextBlock`) and input controls (`TextBox`, `ComboBox`, `CheckBox`) MUST provide accessible, English-language tooltips adhering to these strict rules:

1. **Strict Width Boundary**: Enforce `MaxWidth="225"` on the `<ToolTip>` element with internal `TextWrapping="Wrap"` to prevent long horizontal single-line tooltip overflow.
2. **Three-Part Structured Content**:
   - **Concept & Purpose**: Clear explanation of what the field is and what it does.
   - **Example**: Concrete example value.
   - **Where to Find**: Location in the cloud portal or OS where the user gets the value (or explicitly state if it is an arbitrary user-invented label).
3. **Double Attaching**: Attach the `ToolTip` to BOTH the field label (`TextBlock`) and the input control (`TextBox` / `ComboBox` / `CheckBox`) so hovering over either element displays the guide.

---

## 2. Standardized XAML Implementation Pattern

```xaml
<!-- Label with ToolTip -->
<TextBlock Text="Container name" FontWeight="SemiBold" FontSize="12" Foreground="#333333" Margin="0,0,0,4">
    <TextBlock.ToolTip>
        <ToolTip MaxWidth="225">
            <TextBlock TextWrapping="Wrap" FontSize="11.5" LineHeight="15" Foreground="#333333">
                <Bold>Container Name</Bold><LineBreak/>
                Target Azure Storage container name containing Revit family (.rfa) blob files.<LineBreak/><LineBreak/>
                <Bold>Example:</Bold> revit-families-2024<LineBreak/>
                <Bold>Where to find:</Bold> Azure Portal (portal.azure.com) -> Storage accounts -> Containers tab.
            </TextBlock>
        </ToolTip>
    </TextBlock.ToolTip>
</TextBlock>

<!-- Input Control with ToolTip -->
<TextBox Text="{Binding ContainerName, UpdateSourceTrigger=PropertyChanged}" Height="28" Padding="6,4"
         BorderBrush="#CCCCCC" BorderThickness="1" Background="White" FontSize="12" Margin="0,0,0,12">
    <TextBox.ToolTip>
        <ToolTip MaxWidth="225">
            <TextBlock TextWrapping="Wrap" FontSize="11.5" LineHeight="15" Foreground="#333333">
                <Bold>Container Name</Bold><LineBreak/>
                Target Azure Storage container name containing Revit family (.rfa) blob files.<LineBreak/><LineBreak/>
                <Bold>Example:</Bold> revit-families-2024<LineBreak/>
                <Bold>Where to find:</Bold> Azure Portal (portal.azure.com) -> Storage accounts -> Containers tab.
            </TextBlock>
        </ToolTip>
    </TextBox.ToolTip>
</TextBox>
```

---

## 3. Summary of Configured Sources & Tooltips
- **Local Folder (`DirectorySourceWindow.xaml`)**: `Name`, `Directory Path`, `Active`.
- **Autodesk Docs (`AutodeskDocsSourceWindow.xaml`)**: `Autodesk OAuth Login`, `APS Client ID`, `Access Token`, `Refresh Token`, `Source Display Name`, `Active`.
- **Azure Storage (`AzureStorageSourceWindow.xaml`)**: `Name`, `Container Name`, `Root Path`, `Endpoint URL`, `Client ID`, `Tenant ID`, `Connection String`, `Active`.
- **AWS S3 (`AwsS3SourceWindow.xaml`)**: `Name`, `Bucket Name`, `AWS Region`, `Root Path (Prefix)`, `Endpoint URL`, `Access Key (ID)`, `Secret Key`, `Active`.
