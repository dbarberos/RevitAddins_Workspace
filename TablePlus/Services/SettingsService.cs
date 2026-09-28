using System;
using System.IO;
using System.Xml.Serialization;
using TablePlus.Models;

namespace TablePlus.Services;

public static class SettingsService
{
    private static readonly string AppDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TablePlus");
    private static readonly string SettingsFilePath = Path.Combine(AppDataFolder, "settings.xml");

    public static TablePlusSettings Load()
    {
        try
        {
            if (!File.Exists(SettingsFilePath))
                return new TablePlusSettings();

            // Validate path to prevent path traversal
            string fullPath = Path.GetFullPath(SettingsFilePath);
            if (!fullPath.StartsWith(AppDataFolder, StringComparison.OrdinalIgnoreCase))
            {
                throw new UnauthorizedAccessException("Attempted access outside of authorized AppData folder.");
            }

            var serializer = new XmlSerializer(typeof(TablePlusSettings));

            // XXE Prevention: Use XmlReader with DtdProcessing.Prohibit
            var settings = new System.Xml.XmlReaderSettings
            {
                DtdProcessing = System.Xml.DtdProcessing.Prohibit,
                XmlResolver = null
            };

            TablePlusSettings? loaded = null;
            using (var stream = new FileStream(SettingsFilePath, FileMode.Open, FileAccess.Read))
            using (var xmlReader = System.Xml.XmlReader.Create(stream, settings))
            {
                loaded = (TablePlusSettings?)serializer.Deserialize(xmlReader);
            }

            if (loaded != null)
            {
                if (loaded.SelectedTabOption == TabOption.DBDevDefault)
                {
                    loaded.SelectedTabOption = TabOption.AddInsDefaultTab;
                    Save(loaded);
                }
                return loaded;
            }

            return new TablePlusSettings();
        }
        catch (Exception ex)
        {
            LoggerService.LogWarning($"Failed to load settings from '{SettingsFilePath}': {ex.Message}. Falling back to default settings.");
            var fallback = new TablePlusSettings();
            try
            {
                Save(fallback);
            }
            catch { }
            return fallback;
        }
    }

    public static void Save(TablePlusSettings settings)
    {
        try
        {
            if (!Directory.Exists(AppDataFolder))
                Directory.CreateDirectory(AppDataFolder);

            // Validate path
            string fullPath = Path.GetFullPath(SettingsFilePath);
            if (!fullPath.StartsWith(AppDataFolder, StringComparison.OrdinalIgnoreCase))
            {
                throw new UnauthorizedAccessException("Attempted write outside of authorized AppData folder.");
            }

            var serializer = new XmlSerializer(typeof(TablePlusSettings));
            using (var stream = new FileStream(SettingsFilePath, FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(stream, settings);
            }
        }
        catch (Exception ex)
        {
            LoggerService.LogWarning($"Failed to save settings to '{SettingsFilePath}': {ex.Message}");
        }
    }
}
