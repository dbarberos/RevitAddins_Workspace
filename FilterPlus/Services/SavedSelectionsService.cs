using Autodesk.Revit.DB;
using FilterPlus.Models;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace FilterPlus.Services
{
    public static class SavedSelectionsService
    {
        private static readonly Guid SchemaGuid = new Guid("B6A34F90-0975-4ED0-8B33-317A16892576");
        private const string SchemaName = "FilterPlusSavedSelections";

        /// <summary>
        /// Loads the saved selections from the Revit document's Extensible Storage.
        /// </summary>
        public static List<SavedSelection> LoadSavedSelections(Document doc)
        {
            try
            {
                LoggerService.LogInfo($"LoadSavedSelections: Requesting read from document '{doc?.Title}'...");
                string json = ExtensibleStorageManager.ReadGlobalData(doc, SchemaGuid);
                if (string.IsNullOrWhiteSpace(json))
                {
                    LoggerService.LogInfo("LoadSavedSelections: No saved selections JSON payload found (empty storage).");
                    return new List<SavedSelection>();
                }
                LoggerService.LogInfo($"LoadSavedSelections: JSON payload retrieved successfully ({json.Length} characters). Deserializing...");
                var list = JsonSerializer.Deserialize<List<SavedSelection>>(json) ?? new List<SavedSelection>();
                LoggerService.LogInfo($"LoadSavedSelections: Successfully deserialized {list.Count} selections.");
                return list;
            }
            catch (Exception ex)
            {
                LoggerService.LogError("LoadSavedSelections Error", ex);
                return new List<SavedSelection>();
            }
        }

        /// <summary>
        /// Saves the list of selections to the Revit document's Extensible Storage under a synchronous transaction.
        /// </summary>
        public static bool SaveSavedSelections(Document doc, List<SavedSelection> selections)
        {
            try
            {
                LoggerService.LogInfo($"SaveSavedSelections: Requesting write for {selections?.Count ?? 0} selections to document '{doc?.Title}'...");
                string json = JsonSerializer.Serialize(selections);
                LoggerService.LogInfo($"SaveSavedSelections: Serialized payload is {json.Length} characters. Starting transaction...");
                using (Transaction t = new Transaction(doc, "Save FilterPlus Selections"))
                {
                    t.Start();
                    LoggerService.LogInfo("SaveSavedSelections: Transaction started. Writing payload to Extensible Storage...");
                    ExtensibleStorageManager.WriteGlobalData(doc, SchemaGuid, SchemaName, json);
                    t.Commit();
                    LoggerService.LogInfo("SaveSavedSelections: Transaction committed successfully.");
                }
                return true;
            }
            catch (Exception ex)
            {
                LoggerService.LogError("SaveSavedSelections Error", ex);
                return false;
            }
        }
    }
}
