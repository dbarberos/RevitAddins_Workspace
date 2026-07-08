// ==============================================================================
// SKILL: SKILL-RVT-DATA (Data & Information)
// PATTERN: Extensible Storage / Hidden Database Injection
// PURPOSE: Provides CRUD operations to inject and retrieve invisible data 
//          (JSON payloads) directly into Revit elements or the Project Information.
//          Bypasses the strict typing of standard Schemas by using serialized JSON.
// DEPENDENCIES: Autodesk.Revit.DB, Autodesk.Revit.DB.ExtensibleStorage
// ==============================================================================

using System;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.ExtensibleStorage;

namespace FilterPlus.Services
{
    /// <summary>
    /// Manages the creation and manipulation of Extensible Storage schemas.
    /// Optimized for injecting serialized JSON data to avoid Schema versioning conflicts.
    /// </summary>
    public static class ExtensibleStorageManager
    {
        // Internal field name mapping. Do not change once in production.
        private const string DataFieldName = "JsonPayload";
        
        // This must match the VendorId registered in your Add-in Manifest (.addin file)
        private const string DefaultVendorId = "DBDev_dbarberos"; 

        /// <summary>
        /// Gets an existing schema by GUID or creates a new one securely if it doesn't exist.
        /// </summary>
        /// <param name="schemaId">A unique, static Guid for your application's data.</param>
        /// <param name="schemaName">Internal name for the schema.</param>
        /// <param name="vendorId">The VendorId of your organization.</param>
        /// <returns>The active Schema definition.</returns>
        public static Schema GetOrCreateSchema(Guid schemaId, string schemaName, string vendorId = DefaultVendorId)
        {
            Schema schema = Schema.Lookup(schemaId);
            
            if (schema == null)
            {
                SchemaBuilder builder = new SchemaBuilder(schemaId);
                builder.SetSchemaName(schemaName);
                
                // Public read access allows other scripts to read the data, 
                // Vendor write access protects it from being modified by other Add-ins.
                builder.SetReadAccessLevel(AccessLevel.Public); 
                builder.SetWriteAccessLevel(AccessLevel.Vendor);
                builder.SetVendorId(vendorId);

                // Add a single string field capable of holding a massive JSON string
                builder.AddSimpleField(DataFieldName, typeof(string));

                schema = builder.Finish();
            }

            return schema;
        }

        /// <summary>
        /// Injects a JSON string payload globally into the Project Information element.
        /// This ensures the data is not lost if a specific wall or element is deleted.
        /// MUST be called within an active Transaction.
        /// </summary>
        /// <param name="doc">The active Document.</param>
        /// <param name="schemaId">The unique Guid of your Schema.</param>
        /// <param name="schemaName">The name of your Schema.</param>
        /// <param name="jsonPayload">The serialized JSON string to store.</param>
        public static void WriteGlobalData(Document doc, Guid schemaId, string schemaName, string jsonPayload)
        {
            if (doc == null || string.IsNullOrWhiteSpace(jsonPayload)) return;

            Schema schema = GetOrCreateSchema(schemaId, schemaName);
            Entity entity = new Entity(schema);
            
            entity.Set(DataFieldName, jsonPayload);

            // Bind the invisible entity to the ProjectInformation (Global scope)
            ProjectInfo projInfo = doc.ProjectInformation;
            if (projInfo != null)
            {
                projInfo.SetEntity(entity);
            }
        }

        /// <summary>
        /// Retrieves the JSON string payload from the Project Information element.
        /// Can be called in a Read-Only context (no Transaction required).
        /// </summary>
        /// <param name="doc">The active Document.</param>
        /// <param name="schemaId">The unique Guid of your Schema.</param>
        /// <returns>The stored JSON string, or an empty string if nothing is found.</returns>
        public static string ReadGlobalData(Document doc, Guid schemaId)
        {
            if (doc == null) return string.Empty;

            Schema schema = Schema.Lookup(schemaId);
            if (schema == null) return string.Empty; // Schema hasn't been instantiated yet

            ProjectInfo projInfo = doc.ProjectInformation;
            if (projInfo == null) return string.Empty;

            Entity entity = projInfo.GetEntity(schema);
            if (entity.IsValid())
            {
                return entity.Get<string>(DataFieldName);
            }

            return string.Empty;
        }
        
        /// <summary>
        /// Completely erases the schema data from the Project Information.
        /// MUST be called within an active Transaction.
        /// </summary>
        /// <param name="doc">The active Document.</param>
        /// <param name="schemaId">The unique Guid of your Schema.</param>
        public static void EraseGlobalData(Document doc, Guid schemaId)
        {
             if (doc == null) return;
             
             Schema schema = Schema.Lookup(schemaId);
             if (schema == null) return;
             
             ProjectInfo projInfo = doc.ProjectInformation;
             if (projInfo != null)
             {
                 projInfo.DeleteEntity(schema);
             }
        }
    }
}
