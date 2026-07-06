# Skill: Planning Tables, Data Extraction and BOQ (Schedule API)

## 1. Technical Data Sheet and Metadata for the Agent
* **Skill ID:** SKILL-RVT-028
* **Technical Area:** Data Extraction / BOQ / 5D BIM / Reporting
* **API dependencies:** `Autodesk.Revit.DB.ViewSchedule`, `Autodesk.Revit.DB.ScheduleDefinition`, `Autodesk.Revit.DB.TableData`
* **Key Concepts:** SchedulableField, ScheduleFilter, ScheduleSortGroupField, TableSectionData.
* **Operational Impact:** Critical. It allows you to generate automatic contract reports, audit missing parameters visually and export measurements to databases or CSV/Excel files.

---

## 2. Planning Table Ontology

In the Revit API, a Schedule Table is not a simple list of elements. It is a complex view (`ViewSchedule`) that is divided into two different engines:

1. **The Definition Engine (`ScheduleDefinition`):** Defines *what* is going to be displayed. Stores fields (Columns), logical filters, grouping rules and totals.
2. **The Data Engine (`TableData`):** Defines *how* the grid is presented. It is the rendered row and cell structure that contains the final text.



---

## 3. Parametric Creation and Configuration (ScheduleDefinition)

To create a table by code, the view is instantiated and then the fields (parameters) that you want to read are injected, configuring their order and format.

### Optimized Pattern (Audit Table Creation)
```csharp
public ViewSchedule CreateWallAuditTable(Document doc)
{
    using (Transaction t = new Transaction(doc, "Create Wall Table"))
    {
        t.Start();

        // 1. Create the base view
        ElementId categoryWallsId = new ElementId(BuiltInCategory.OST_Walls);
        ViewSchedule walltable = ViewSchedule.CreateSchedule(doc, wallcategoryId);
        walltable.Name = "AUDIT - Base Walls";

        // 2. Access the definition
        ScheduleDefinition definition = WallTable.Definition;

        // 3. Search available fields (e.g. Type and Area Mark)
        SchedulableField brandfield = definition.GetSchedulableFields()
            .FirstOrDefault(f => f.ParameterId == new ElementId(BuiltInParameter.ALL_MODEL_TYPE_MARK));
            
        SchedulableField fieldArea = definition.GetSchedulableFields()
            .FirstOrDefault(f => f.ParameterId == new ElementId(BuiltInParameter.HOST_AREA_COMPUTED));

        // 4. Add columns to the table
        if (brandField != null)
        {
            ScheduleFieldMarkColumn = definition.AddField(MarkField);
            BrandColumn.ColumnHeading = "TypeCode"; // Rename header
        }

        if (areafield != null)
        {
            ScheduleField columnArea = definition.AddField(fieldArea);
            columnArea.DisplayType = ScheduleFieldDisplayType.Totals; // Enable total calculation
            definition.IsItemized = false; // Group equal instances (Do not detail each instance)
        }
        
        t.Commit();
        return wallTable;
    }
}
4. Data Extraction (Reading the Grid)
If the goal is not to create the table, but rather to read an existing table for export to Excel or JSON, the agent should NOT iterate over the model elements. You must read the grid cells directly, as they contain the pre-calculated values, formatted and rounded by the Revit engine.
Optimized Pattern (Structured Cell Extraction)
C#
public void ExtractDataSchedule(ViewSchedule table)
{
    // Access the main section data grid (Body)
    TableData tableData = table.GetTableData();
    TableSectionData sectionBody = tableData.GetSectionData(SectionType.Body);

    int rows = bodySection.NumberOfRows;
    int columns = bodySection.NumberOfColumns;

    for (int r = 0; r < rows; r++)
    {
        List<string> dataRow = new List<string>();
        
        for (int c = 0; c < columns; c++)
        {
// Extract formatted text as the user sees it (e.g. "15.5 m²")
            string cellText = table.GetCellText(SectionType.Body, r, c);
            DataRow.Add(cellText);
        }
        
        // Here the 'datarow' would be sent to a CSV writer or a REST system (SKILL 13)
        // Console.WriteLine(string.Join(";", dataRow));
    }
}
Operational Note: There is also a native ultra-fast method for exporting entire tables to delimited text: table.Export(folder, fileName, new ViewScheduleExportOptions()).
5. Antipattern Matrix vs Resilient Code
Common Antipattern (Reinvention of the Wheel in BOQ)
C#
// FATAL: The user requests to extract the measurements from a Door Schedule.
// Developer iterates over doc.GetElements(typeof(FamilyInstance)) and sums the areas 
// manually in C#. 
// Problem: Results will not match table due to grouping, phase filters 
// or calculated fields that exist in the ScheduleDefinition and have been ignored by C#.
Optimized Pattern (Getting Elements from Table)
If you need to interact three-dimensionally with the elements that appear in a specific row, the API allows you to extract the ElementId directly from the Schedule view, ensuring that they respect the configured filters and phases.
C#
// Gets only the elements that exceed the filters configured in that Planning Table
FilteredElementCollector elementsInTable = new FilteredElementCollector(doc, table.Id);
6. Agent Injection Instructions (Prompting Prompt)
When you process code related to the generation of reports, measurements or interaction with Schedules, strictly apply these rules:
UI Level Engine Priority (GetCellText): When the goal is to export data to external formats (CSV, JSON), the agent MUST prioritize reading the GetCellText() method over manually inspecting the elements' parameters. This ensures that the unit formats, conditional formulas and roundings configured by the BIM Manager are maintained.
Grouping Context Handling (IsItemized): When reading a table, always warn in the code logic that if ScheduleDefinition.IsItemized is false, the table is grouping multiple items in a single row. In this state, attempting to extract an ElementId from a row may return empty or partial results.
Native vs LINQ Filters: When creating a table programmatically, never depend on external scripts to filter the displayed information. Injects ScheduleFilter objects directly into the ScheduleDefinition so that the view in Revit is autonomous and the user can audit the logical rules without having to review code.
Logical Hiding of Fields: When designing Schedule Tables that will act as a data bridge (e.g. a Schedule exported to PowerBI), add technical fields such as the ElementId or the GUID for traceability, but configure them with ScheduleField.IsHidden = true. This way, code and external databases can read the primary keys without dirtying the end user's view of the printed plans.

***

### 
With this module, the agent already masters data abstraction for reports and connection with PowerBI or corporate ERPs.