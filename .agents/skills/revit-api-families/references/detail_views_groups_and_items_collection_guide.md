# Revit API: Detail Views, Detail Groups & Detail Items Collection Guide

## 1. Context & Purpose
When building transfer and detail management add-ins, separating 2D documentation elements into dedicated collectors prevents data cross-contamination and ensures precise UI filtering.

## 2. Extraction Queries by Category

### A. Detail Views & Callouts
```csharp
var detailViews = new FilteredElementCollector(doc)
    .OfClass(typeof(View))
    .Cast<View>()
    .Where(v => !v.IsTemplate && (v.ViewType == ViewType.Detail || v.IsCallout))
    .OrderBy(v => v.Name)
    .ToList();
```

### B. 2D Detail Groups
```csharp
// 1. Placed Group Instances
var placedGroups = new FilteredElementCollector(doc)
    .OfClass(typeof(Group))
    .WhereElementIsNotElementType()
    .Cast<Group>()
    .Where(g => (g.GroupType?.Category?.Id?.Value == (int)BuiltInCategory.OST_IOSDetailGroups) ||
                (g.Category?.Id?.Value == (int)BuiltInCategory.OST_IOSDetailGroups))
    .ToList();

// 2. Unplaced Group Types
var groupTypes = new FilteredElementCollector(doc)
    .OfClass(typeof(GroupType))
    .Cast<GroupType>()
    .Where(gt => gt.Category?.Id?.Value == (int)BuiltInCategory.OST_IOSDetailGroups)
    .ToList();
```

### C. 2D Detail Components (Detail Items)
```csharp
var detailItems = new FilteredElementCollector(doc)
    .OfCategory(BuiltInCategory.OST_DetailComponents)
    .WhereElementIsNotElementType()
    .Cast<FamilyInstance>()
    .ToList();
```
