# Debugging: XmlSerializer Rejection of [Obsolete] Enum Members on Revit Startup
**Date:** 2026-09-11
**Tags:** `XmlSerializer`, `ObsoleteAttribute`, `Settings`, `Revit Startup`, `Resilience`

## 🔴 Symptom
When launching Autodesk Revit with an updated add-in installed, a blocking modal error dialog appears immediately during `IExternalApplication.OnStartup()`:
`"FilterPlus Error: An error occurred in Loading Settings: Error en el documento XML (3, 54). Check Debug Log for details."`

Revit startup halts until the user dismisses the dialog.

## 🔍 Root Cause
1. **`XmlSerializer` Enum Filtering**:
   When migrating an enum value (e.g. from `DBDevDefault` to `AddInsDefaultTab`), adding the `[Obsolete]` attribute to the legacy member:
   ```csharp
   public enum TabOption
   {
       [XmlEnum("AddInsDefaultTab")]
       AddInsDefaultTab,

       [Obsolete("Use AddInsDefaultTab instead.")]
       [XmlEnum("DBDevDefault")]
       DBDevDefault
   }
   ```
   causes .NET Framework's `XmlReflectionImporter` to completely ignore and exclude the obsolete member from the generated `XmlSerializationReader`.
   Consequently, when an existing user `settings.xml` file containing `<SelectedTabOption>DBDevDefault</SelectedTabOption>` is loaded, `XmlSerializer.Deserialize()` throws:
   `InvalidOperationException: Instance validation error: 'DBDevDefault' is not a valid value for TabOption.`

2. **Blocking Modal Dialog in Service Catch Block**:
   `SettingsService.Load()` caught the exception and called `LoggerService.LogError()`, which called `MessageBox.Show()`. In Revit add-in architecture, popping up modal message boxes during `OnStartup()` violates resilience standards and creates an intrusive user experience.

## 🛠️ Solution
1. **Remove `[Obsolete]` from the Enum**:
   Keep legacy enum members mapped with `[XmlEnum]` without `[Obsolete]` so that `XmlSerializer` successfully deserializes existing config files.
   ```csharp
   public enum TabOption
   {
       [XmlEnum("AddInsDefaultTab")]
       AddInsDefaultTab,

       [XmlEnum("DBDevDefault")]
       DBDevDefault,

       [XmlEnum("RevitDefault")]
       RevitDefault,

       [XmlEnum("Custom")]
       Custom
   }
   ```

2. **Automatic Schema Upgrade & File Unlock in `SettingsService`**:
   Close the read stream before writing, seamlessly upgrade legacy values in-memory, and immediately re-save the cleaned file:
   ```csharp
   FilterPlusSettings loaded = null;
   using (var stream = new FileStream(SettingsFilePath, FileMode.Open, FileAccess.Read))
   using (var xmlReader = System.Xml.XmlReader.Create(stream, settings))
   {
       loaded = (FilterPlusSettings)serializer.Deserialize(xmlReader);
   }

   if (loaded != null)
   {
       if (loaded.SelectedTabOption == TabOption.DBDevDefault)
       {
           loaded.SelectedTabOption = TabOption.AddInsDefaultTab;
           Save(loaded); // Automatically upgrade legacy settings XML on disk
       }
       return loaded;
   }
   ```

3. **Silent Fallback Logging During Startup**:
   Replace blocking `LogError` with `LogWarning` in `SettingsService.Load()` and `Save()`. Never pop up modal dialogs during Revit startup when configuration loading fails; instead, log the warning and return default settings.
