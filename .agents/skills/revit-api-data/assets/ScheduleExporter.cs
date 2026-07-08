// ==============================================================================
// SKILL: SKILL-RVT-DATA (Data & Information)
// PATTERN: Schedule / BOQ Harvester
// PURPOSE: Extracts data directly from the visual grid of a Revit Schedule, 
//          ensuring that formatting, formulas, and grouping configured by 
//          the BIM Manager are strictly preserved.
// DEPENDENCIES: Autodesk.Revit.DB, System.Collections.Generic
// ==============================================================================

using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;

namespace RevitAddinBase.Data
{
    /// <summary>
    /// Utility class for extracting structured Bill of Quantities (BOQ) data 
    /// from Revit ViewSchedules.
    /// </summary>
    public static class ScheduleExporter
    {
        /// <summary>
        /// Reads the body of a ViewSchedule and returns a 2D list of strings representing the grid.
        /// This method is crucial because it captures the data EXACTLY as it appears 
        /// in Revit (including rounding and combined parameters), avoiding manual recreation.
        /// </summary>
        /// <param name="schedule">The target ViewSchedule.</param>
        /// <param name="includeHeaders">If true, includes the column header row(s).</param>
        /// <returns>A list of rows, where each row is a list of cell string values.</returns>
        public static List<List<string>> ExtractScheduleGrid(ViewSchedule schedule, bool includeHeaders = true)
        {
            List<List<string>> extractedData = new List<List<string>>();
            
            if (schedule == null) return extractedData;

            // Obtain the underlying table data structure
            TableData tableData = schedule.GetTableData();
            if (tableData == null) return extractedData;

            // Extract the Header section (Titles and Column Headers)
            if (includeHeaders)
            {
                TableSectionData headerSection = tableData.GetSectionData(SectionType.Header);
                if (headerSection != null)
                {
                    ExtractSection(schedule, headerSection, SectionType.Header, extractedData);
                }
            }

            // Extract the Body section (where the actual elements/rows reside)
            TableSectionData bodySection = tableData.GetSectionData(SectionType.Body);
            if (bodySection != null)
            {
                ExtractSection(schedule, bodySection, SectionType.Body, extractedData);
            }

            return extractedData;
        }

        /// <summary>
        /// Helper method to iterate through rows and columns of a specific table section.
        /// </summary>
        private static void ExtractSection(
            ViewSchedule schedule, 
            TableSectionData sectionData, 
            SectionType sectionType, 
            List<List<string>> outputList)
        {
            int rowCount = sectionData.NumberOfRows;
            int colCount = sectionData.NumberOfColumns;

            for (int r = 0; r < rowCount; r++)
            {
                List<string> rowData = new List<string>();
                
                for (int c = 0; c < colCount; c++)
                {
                    // GetCellText is the safest method as it evaluates formulas and overrides natively
                    string cellText = schedule.GetCellText(sectionType, r, c);
                    
                    // Sanitize line breaks that users might have added inside Revit cells
                    // Critical for JSON or CSV serialization downstream
                    cellText = cellText.Replace("\r", " ").Replace("\n", " ").Trim();
                    
                    rowData.Add(cellText);
                }
                
                outputList.Add(rowData);
            }
        }
        
        /// <summary>
        /// Native high-speed export to CSV or TSV format directly to the hard drive.
        /// Bypasses memory storage, ideal for massive schedules holding thousands of rows.
        /// </summary>
        /// <param name="schedule">The target ViewSchedule.</param>
        /// <param name="folderPath">The destination directory.</param>
        /// <param name="fileName">The filename including extension (e.g., 'Doors_BOQ.csv').</param>
        /// <param name="delimiter">The character separating values (comma, tab, semicolon).</param>
        public static void ExportToTextFileFast(ViewSchedule schedule, string folderPath, string fileName, string delimiter = ";")
        {
            if (schedule == null || string.IsNullOrWhiteSpace(folderPath)) return;

            ViewScheduleExportOptions exportOptions = new ViewScheduleExportOptions
            {
                FieldDelimiter = delimiter,
                HeadersFootersBlanks = true,
                ColumnHeaders = ExportColumnHeaders.OneRow,
                Title = false // Usually omit title for clean database ingest
            };

            schedule.Export(folderPath, fileName, exportOptions);
        }
    }
}