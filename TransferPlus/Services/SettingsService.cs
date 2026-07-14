using System;
using System.IO;
using System.Xml.Serialization;
using TransferPlus.Models;

namespace TransferPlus.Services;

public static class SettingsService
{
    private static readonly string AppDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TransferPlus");
    private static readonly string SettingsFilePath = Path.Combine(AppDataFolder, "settings.xml");

    public static TransferPlusSettings Load()
    {
        try
        {
            if (!File.Exists(SettingsFilePath))
                return new TransferPlusSettings();

            // Validate path to prevent path traversal
            string fullPath = Path.GetFullPath(SettingsFilePath);
            if (!fullPath.StartsWith(AppDataFolder, StringComparison.OrdinalIgnoreCase))
            {
                throw new UnauthorizedAccessException("Attempted access outside of authorized AppData folder.");
            }

            var serializer = new XmlSerializer(typeof(TransferPlusSettings));
            
            // XXE Prevention: Use XmlReader with DtdProcessing.Prohibited
            var settings = new System.Xml.XmlReaderSettings
            {
                DtdProcessing = System.Xml.DtdProcessing.Prohibit,
                XmlResolver = null
            };

            using (var stream = new FileStream(SettingsFilePath, FileMode.Open, FileAccess.Read))
            using (var xmlReader = System.Xml.XmlReader.Create(stream, settings))
            {
                return (TransferPlusSettings)serializer.Deserialize(xmlReader);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Error loading settings: " + ex.Message);
            return new TransferPlusSettings();
        }
    }

    public static void Save(TransferPlusSettings settings)
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

            var serializer = new XmlSerializer(typeof(TransferPlusSettings));
            using (var stream = new FileStream(SettingsFilePath, FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(stream, settings);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Error saving settings: " + ex.Message);
        }
    }
}
