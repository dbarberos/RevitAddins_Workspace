# Debugging Log: Revit Link Overrides and Hidden Visibility Preservation Across Views & Templates

## Environment
- **Revit API Version:** Revit 2024 / .NET 8 / .NET Framework 4.8
- **Module:** TransferPlus (View & Revit Link Overrides)
- **Date:** 2026-07-28

---

## Symptom
When transferring views between Revit documents:
1. Revit Links (`RevitLinkInstance`) that were hidden or had graphics overrides in the source view remained visible in the target view.
2. In the logs, warnings appeared indicating:
   `LinkOverrides: The following linked models were NOT found in the target document. Skipping overrides for: [...]`

---

## Root Causes
1. **Instance Name Mismatch (`RevitLinkInstance.Name`)**:
   Revit assigns instance numbers and shared coordinate location suffixes to `RevitLinkInstance.Name` (e.g. `ARQ.rvt : 1 : Location <Not Shared>`). If the target document contained the link as `ARQ.rvt : 2 : Location`, direct equality check (`targetLink.Name.Equals(srcLink.Name)`) evaluated to `false` and returned `null`.
2. **Top-Level Category (`OST_RvtLinks`) Not Explicitly Synchronized**:
   The "Revit Links" category (`BuiltInCategory.OST_RvtLinks`) was not being explicitly queried and set to hidden when `srcView.GetCategoryHidden(...)` was `true`.
3. **Template Application Reset**:
   When `vistadestino.ViewTemplateId = targetTemplateId` was assigned at the end of view setup, Revit API reset view-level element hiding (`HideElements`).

---

## Solution
1. **Robust Clean Name Matching Helper (`GetLinkCleanName`)**:
   Strip out instance suffixes (`: N : Location...`) and `.rvt` extensions from document titles or link types to match linked models reliably regardless of instance index or load status:

```csharp
public static string GetLinkCleanName(RevitLinkInstance link, Document doc)
{
    if (link == null) return string.Empty;

    try
    {
        Document linkDoc = link.GetLinkDocument();
        if (linkDoc != null && !string.IsNullOrWhiteSpace(linkDoc.Title))
            return linkDoc.Title.Replace(".rvt", "").Trim();
    }
    catch { }

    try
    {
        RevitLinkType linkType = doc.GetElement(link.GetTypeId()) as RevitLinkType;
        if (linkType != null && !string.IsNullOrWhiteSpace(linkType.Name))
            return linkType.Name.Replace(".rvt", "").Trim();
    }
    catch { }

    if (!string.IsNullOrWhiteSpace(link.Name))
    {
        string rawName = link.Name.Split(':')[0].Trim();
        return rawName.Replace(".rvt", "").Trim();
    }

    return string.Empty;
}
```

2. **Synchronize Top-Level `OST_RvtLinks` Category**:
```csharp
Category rvtLinksCatSrc = Category.GetCategory(sourceDoc, BuiltInCategory.OST_RvtLinks);
Category rvtLinksCatTgt = Category.GetCategory(targetDoc, BuiltInCategory.OST_RvtLinks);
if (rvtLinksCatSrc != null && rvtLinksCatTgt != null)
{
    bool isRvtLinksHidden = srcView.GetCategoryHidden(rvtLinksCatSrc.Id);
    targetGraphicsView.SetCategoryHidden(rvtLinksCatTgt.Id, isRvtLinksHidden);
}
```

3. **Apply Hiding & Overrides to BOTH Template and View, and Re-enforce Post-Template**:
   Call `HideElements` and `SetLinkOverrides` on both `targetGraphicsView` (template) and `targetView` (view itself), and re-invoke `CopyViewGraphicsAndOverrides` after `vistadestino.ViewTemplateId` assignment in `matchPlantilla`.

---

## Lessons Learned
- Never match `RevitLinkInstance` objects solely by `link.Name` or `link.Id`, because instance numbers (`: 1`, `: 2`) and ElementIds differ across models. Always parse base clean names (`GetLinkCleanName`).
- Always explicitly synchronize `BuiltInCategory.OST_RvtLinks` alongside model categories.
- Always re-enforce view-level element hiding after setting `ViewTemplateId`.
