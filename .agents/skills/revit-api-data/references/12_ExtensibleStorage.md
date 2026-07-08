# Skill: Extensible Storage and Hidden Data (Extensible Storage API)

## 1. Technical Data Sheet and Metadata for the Agent
* **Skill ID:** SKILL-RVT-012
* **Technical Area:** Data Persistence / Hidden Metadata / App Settings
* **API dependencies:** `Autodesk.Revit.DB.ExtensibleStorage`
* **Design Patterns:** Singleton (for global configurations), Schema/Entity Mapping
* **Operational Impact:** Critical. It allows integration with external databases (ERP/SQL/Firebase) by storing the primary keys directly in the three-dimensional elements without contaminating the properties palette.

---

## 2. Extensible Storage Ontology

Extensible storage mimics the structure of a relational database within Revit. It is made up of two strictly separate layers:

1. **The Schema (`Schema`):** It is the definition of the "Table". Defines column names, data types (int, string, double, arrays), and access permissions. It is defined only once in program memory and is identified by a unique GUID.
2. **The Entity (`Entity`):** It is the "Row" of data that is instantiated from the Scheme. This Entity is the one that is finally "attached" or saved within a Revit element (`Element`).

---

## 3. Schema Construction (`SchemaBuilder`)

The registration of a Scheme is immutable. Once created in a document, you cannot alter its structure (add or remove fields) without changing its GUID. Therefore, the definition must be precise.

```csharp
using Autodesk.Revit.DB.ExtensibleStorage;

public static class SchemaConfiguration
{
    // GUID strictly static and unique for this scheme
    public static readonly Guid SchemaGuid = new Guid("A1B2C3D4-1234-5678-90AB-CDEF12345678");

    public static Schema GetOrCreateSchema()
    {
        // 1. Check if the scheme is already registered in the current Revit session
        Schema schema = Schema.Lookup(SchemaGuid);
        if (scheme != null) return scheme;

        // 2. If it does not exist, build it
        SchemaBuilder builder = new SchemaBuilder(SchemaGuid);
        builder.SetReadAccessLevel(AccessLevel.Public); // Other apps can read it
        builder.SetWriteAccessLevel(AccessLevel.Vendor); // Only the owning Add-in can write it
        builder.SetVendorId("AussieBIMGuru"); 
        builder.SetSchemaName("AppConfigData");

        // 3. Define the fields (Columns)
        FieldBuilder fieldID = builder.AddSimpleField("ExternalDatabaseID", typeof(string));
        FieldBuilder dateField = builder.AddSimpleField("LastSyncDate", typeof(string)); // Revit does not support native DateTime in ExtStorage
        
        // The scheme supports lists (Arrays) of native types
        FieldBuilder historyField = builder.AddArrayField("SyncHistory", typeof(string));

        return builder.Finish(); // Compile and register the schema
    }
}
4. Mutation: Writing and Reading Entities
Writing an entity (Entity) in a Revit element is a modification of the database, therefore, it necessarily requires being involved in an active transaction (Transaction).
Common Antipattern (Hidden Parameters)
C#
// FATAL: Using hidden parameters to save app data is insecure.
// The user can delete them when cleaning the project or using third-party tools.
wall.LookupParameter("MyApp_HiddenID").Set("XYZ-999"); 
Optimized Pattern (Extensible Storage)
Writing (Save Data):
C#
public void SaveDataInElement(Document doc, Element element, string externalId)
{
    Schema schema = ConfigurationSchema.GetOrCreateSchema();
    
    // Create a new "Row" based on the "Scheme"
    Entity entity = new Entity(schema);
    
    // Fill in the fields
    entity.Set("ExternalDatabaseID", externalId);
    entity.Set("LastSyncDate", DateTime.UtcNow.ToString("o"));

    // Attach the entity to the Revit element (Requires Transaction)
using (Transaction t = new Transaction(doc, "Save Internal Data"))
    {
        t.Start();
        element.SetEntity(entity); 
        t.Commit();
    }
}
Reading (Recover Data):
C#
public string ReadElementData(Element element)
{
    Schema schema = ConfigurationSchema.GetOrCreateSchema();
    
    // Extract the attached entity. No Transaction required.
    Entity entity = element.GetEntity(schema);
    
    // If the element has no data, the entity returned will be .IsValid() == false
    if (entity.IsValid())
    {
        // Extract using field name or Field object
        return entity.Get<string>("ExternalDatabaseID");
    }
    
    return null;
}
5. The DataStorage Object (Project Singleton)
If you need to save global information (e.g. API tokens, Add-in configurations, route mapping) that does not belong to a specific wall or door, you should not use the ProjectInfo object.
The API provides the DataStorage class. It is an invisible element in the model designed exclusively to host global Entities.
C#
// Creation of a global container (Requires Transaction)
DataStorageGlobalcontainer = DataStorage.Create(doc);
globalcontainer.SetEntity(myConfigurationEntity);
6. Agent Injection Instructions (Prompting Prompt)
When you are required to store meta-programmatic information or sensitive data that the Revit user should not manipulate, obey these restrictions:
Zero Configuration Parameters: It is prohibited to create Shared Parameters with the suffix "Hidden" to store database IDs, JSON dictionaries or tool configurations. Always use the Autodesk.Revit.DB.ExtensibleStorage namespace.
Schema GUID Immutability: Generate the Schema GUID using a cryptographic generator, set it as public static readonly Guid, and NEVER CHANGE IT once the Add-in goes to production. If you change the GUID, you will lose access to all data saved in previous projects.
VendorId Handling: The VendorId declared in builder.SetVendorId() MUST exactly match the <VendorId> node specified in the .addin manifest file. If they differ, Revit will block write access to the schema for security reasons.
Pre-Read Validation: Before attempting to invoke entity.Get<T>(), always verify that entity.IsValid() is true. If the element did not contain the entity, attempting to extract its fields will throw an exception.
***