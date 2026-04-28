using System;
using System.IO;
using System.Xml.Serialization;
using FilterPlus.Models;

namespace FilterPlus.Services;

public static class SettingsService
{
    private static readonly string AppDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FilterPlus");
    private static readonly string SettingsFilePath = Path.Combine(AppDataFolder, "settings.xml");

    public static FilterPlusSettings Load()
    {
        try
        {
            if (!File.Exists(SettingsFilePath))
                return new FilterPlusSettings();

            // Validate path to prevent path traversal
            string fullPath = Path.GetFullPath(SettingsFilePath);
            if (!fullPath.StartsWith(AppDataFolder, StringComparison.OrdinalIgnoreCase))
            {
                throw new UnauthorizedAccessException("Attempted access outside of authorized AppData folder.");
            }

            var serializer = new XmlSerializer(typeof(FilterPlusSettings));
            
            // XXE Prevention: Use XmlReader with DtdProcessing.Prohibited
            var settings = new System.Xml.XmlReaderSettings
            {
                DtdProcessing = System.Xml.DtdProcessing.Prohibit,
                XmlResolver = null
            };

            using (var stream = new FileStream(SettingsFilePath, FileMode.Open, FileAccess.Read))
            using (var xmlReader = System.Xml.XmlReader.Create(stream, settings))
            {
                return (FilterPlusSettings)serializer.Deserialize(xmlReader);
            }
        }
        catch (Exception ex)
        {
            LoggerService.LogError("Loading Settings", ex);
            return new FilterPlusSettings();
        }
    }

    public static void Save(FilterPlusSettings settings)
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

            var serializer = new XmlSerializer(typeof(FilterPlusSettings));
            using (var stream = new FileStream(SettingsFilePath, FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(stream, settings);
            }
        }
        catch (Exception ex)
        {
            LoggerService.LogError("Saving Settings", ex);
        }
    }
}
