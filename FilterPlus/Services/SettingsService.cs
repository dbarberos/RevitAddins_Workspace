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

            var serializer = new XmlSerializer(typeof(FilterPlusSettings));
            using (var stream = new FileStream(SettingsFilePath, FileMode.Open, FileAccess.Read))
            {
                return (FilterPlusSettings)serializer.Deserialize(stream);
            }
        }
        catch
        {
            // Fallback to default if there's any parsing issue
            return new FilterPlusSettings();
        }
    }

    public static void Save(FilterPlusSettings settings)
    {
        try
        {
            if (!Directory.Exists(AppDataFolder))
                Directory.CreateDirectory(AppDataFolder);

            var serializer = new XmlSerializer(typeof(FilterPlusSettings));
            using (var stream = new FileStream(SettingsFilePath, FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(stream, settings);
            }
        }
        catch
        {
            // Ignore save errors for simplicity
        }
    }
}
