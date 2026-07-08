# Guide: Extensible Storage & JSON Persistence in Revit
**Date:** 2026-07-07
**Tags:** `ExtensibleStorage`, `ProjectInformation`, `JSON`, `Persistence`

## 📖 Overview
When building Revit Add-ins that require data persistence across sessions (e.g., saving user configurations, selected elements, or custom UI states), standard files like `.json` or `.xml` on disk can easily get desynced if the model is shared via Revit Server or Autodesk Construction Cloud (BIM 360). 

The optimal approach is to store the data **inside the Revit model itself** using the `Autodesk.Revit.DB.ExtensibleStorage` API.

## 🎯 The `ProjectInformation` Strategy
Extensible Storage requires an `Element` to attach the `Entity` (the data container) to. For model-agnostic, global data (data that belongs to the whole project, not a specific wall or pipe), the best host is the `ProjectInformation` element.
1. It is a singleton (only one per document).
2. It is guaranteed to exist.
3. It survives copy/pasting elements.

```csharp
public static Element GetProjectInformationElement(Document doc)
{
    return new FilteredElementCollector(doc)
        .OfCategory(BuiltInCategory.OST_ProjectInformation)
        .FirstOrDefault();
}
```

## 🔄 JSON Serialization to String Field
Instead of creating complex `Schema` objects with multiple typed fields (which are hard to version and update), the most robust pattern is to define a single `Schema` with exactly **one `String` field**, and serialize your complex C# objects (lists, dictionaries, custom objects) to JSON using `System.Text.Json` or `Newtonsoft.Json`.

### 1. Schema Creation
Define a unique `Guid` for your Schema and build it safely.

```csharp
private static Schema GetOrCreateSchema()
{
    var schemaGuid = new Guid("YOUR-UNIQUE-GUID-HERE");
    var schema = Schema.Lookup(schemaGuid);
    
    if (schema == null)
    {
        SchemaBuilder builder = new SchemaBuilder(schemaGuid);
        builder.SetReadAccessLevel(AccessLevel.Public);
        builder.SetWriteAccessLevel(AccessLevel.Public);
        builder.SetSchemaName("MyAddinDataSchema");
        builder.SetVendorId("com.mycompany");
        
        // Define the single string field for JSON payload
        builder.AddSimpleField("DataPayload", typeof(string));
        
        schema = builder.Finish();
    }
    return schema;
}
```

### 2. Saving Data
Serialize your data model to JSON and store it in the `ProjectInformation` element. **This requires an active Revit `Transaction`.**

```csharp
public static void SaveData<T>(Document doc, T data)
{
    Element host = GetProjectInformationElement(doc);
    Schema schema = GetOrCreateSchema();
    Entity entity = new Entity(schema);
    
    // Serialize to JSON string
    string jsonPayload = JsonSerializer.Serialize(data);
    entity.Set("DataPayload", jsonPayload);
    
    // Write to element
    host.SetEntity(entity);
}
```

### 3. Reading Data
Retrieve the entity from `ProjectInformation` and deserialize the JSON. **This does NOT require a transaction.**

```csharp
public static T LoadData<T>(Document doc)
{
    Element host = GetProjectInformationElement(doc);
    Schema schema = GetOrCreateSchema();
    
    Entity entity = host.GetEntity(schema);
    if (!entity.IsValid()) return default;
    
    string jsonPayload = entity.Get<string>("DataPayload");
    if (string.IsNullOrEmpty(jsonPayload)) return default;
    
    // Deserialize back to object
    return JsonSerializer.Deserialize<T>(jsonPayload);
}
```

## ⚠️ Key Caveats
- **String Length Limits:** Revit `ExtensibleStorage` strings are theoretically unlimited in modern Revit versions, but extremely massive JSON blobs (e.g., millions of characters) might impact project save times.
- **Transactions:** Saving data modifies the document database. Ensure your UI dispatch mechanisms (like `ActionEventHandler`) wrap the `SaveData()` call inside a `using (Transaction t = new Transaction(doc, "Save Data"))`.
- **Serialization Security:** Avoid `TypeNameHandling.All` in `Newtonsoft.Json` due to RCE vulnerabilities. Stick to strongly typed deserialization or use `System.Text.Json`.
