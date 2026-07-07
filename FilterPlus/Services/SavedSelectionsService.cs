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
                string json = ExtensibleStorageManager.ReadGlobalData(doc, SchemaGuid);
                if (string.IsNullOrWhiteSpace(json))
                {
                    return new List<SavedSelection>();
                }
                return JsonSerializer.Deserialize<List<SavedSelection>>(json) ?? new List<SavedSelection>();
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
                string json = JsonSerializer.Serialize(selections);
                using (Transaction t = new Transaction(doc, "Save FilterPlus Selections"))
                {
                    t.Start();
                    ExtensibleStorageManager.WriteGlobalData(doc, SchemaGuid, SchemaName, json);
                    t.Commit();
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
