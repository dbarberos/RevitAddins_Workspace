# Revit Linked Models and Cross-Document Selection

This guide details how to query, coordinate, and select elements across multiple Revit documents (host and linked models) simultaneously under a unified UI explorer context.

---

## 1. Mapped Document Context

To manage multiple document sources, create a wrapper that links the `Document` database with its corresponding `RevitLinkInstance` (if it represents a link).

```csharp
public class RevitModelRepresentation
{
    public string DisplayName { get; }
    public RevitLinkInstance LinkInstance { get; }
    public Document Document { get; }

    public RevitModelRepresentation(string displayName, RevitLinkInstance linkInstance, Document document)
    {
        DisplayName = displayName;
        LinkInstance = linkInstance;
        Document = document;
    }
}
```

*   **Host Document**: `LinkInstance` is `null`.
*   **Linked Document**: `LinkInstance` is the active link instance in the host view, and `Document` is obtained via `LinkInstance.GetLinkDocument()`.

---

## 2. Multi-Model Queries & ID Collision Resolution

Since Revit `ElementId` values are only unique within their respective documents, querying multiple models will result in duplicate IDs. To prevent collisions in hash-sets or dictionary lookups, always identify elements using a composite key:

```csharp
public struct ElementSelectionKey : IEquatable<ElementSelectionKey>
{
    public ElementId ElementId { get; }
    public ElementId LinkInstanceId { get; }

    public ElementSelectionKey(ElementId elementId, ElementId linkInstanceId)
    {
        ElementId = elementId;
        LinkInstanceId = linkInstanceId;
    }

    public bool Equals(ElementSelectionKey other)
    {
        return Equals(ElementId, other.ElementId) && Equals(LinkInstanceId, other.LinkInstanceId);
    }

    public override bool Equals(object obj)
    {
        return obj is ElementSelectionKey other && Equals(other);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return (ElementId.GetHashCode() * 397) ^ LinkInstanceId.GetHashCode();
        }
    }
}
```

*   For host elements: `LinkInstanceId` is `ElementId.InvalidElementId`.
*   For linked elements: `LinkInstanceId` is the `ElementId` of the `RevitLinkInstance` inside the host document.

---

## 3. Coordinate Transformations for View Bounding Box Intersection

When collecting elements from a linked document and filtering them based on whether they are "visible in view" or "in view", you must transform the link elements' local bounding boxes to host coordinates:

```csharp
public static bool IsElementInViewCropBox(Element element, RevitLinkInstance linkInstance, View view)
{
    BoundingBoxXYZ bbox = element.get_BoundingBox(null);
    if (bbox == null) return false;

    if (linkInstance != null)
    {
        Transform transform = linkInstance.GetTotalTransform();
        XYZ minTransformed = transform.OfPoint(bbox.Min);
        XYZ maxTransformed = transform.OfPoint(bbox.Max);
        
        // Construct transformed bounding box in host coordinate system
        XYZ transformedMin = new XYZ(
            Math.Min(minTransformed.X, maxTransformed.X),
            Math.Min(minTransformed.Y, maxTransformed.Y),
            Math.Min(minTransformed.Z, maxTransformed.Z)
        );
        XYZ transformedMax = new XYZ(
            Math.Max(minTransformed.X, maxTransformed.X),
            Math.Max(minTransformed.Y, maxTransformed.Y),
            Math.Max(minTransformed.Z, maxTransformed.Z)
        );
        
        bbox = new BoundingBoxXYZ { Min = transformedMin, Max = transformedMax };
    }

    // Perform intersection check with view crop box or outline in host coordinates
    Outline viewOutline = GetViewOutline(view);
    Outline elementOutline = new Outline(bbox.Min, bbox.Max);
    return viewOutline.Intersects(elementOutline, 0.001);
}
```

---

## 4. Simultaneous Selection Highlighting

Revit allows selecting elements from both the host and multiple link documents in a single operation using `uidoc.Selection.SetReferences()`.

To highlight linked elements, construct a host-compatible reference using `.CreateLinkReference(RevitLinkInstance)`:

```csharp
public void ApplySelection(IEnumerable<ElementSelectionKey> selectionKeys, UIDocument uiDoc)
{
    Document hostDoc = uiDoc.Document;
    List<Reference> references = new List<Reference>();

    foreach (var key in selectionKeys)
    {
        if (key.LinkInstanceId == ElementId.InvalidElementId)
        {
            // Host element
            Element hostEl = hostDoc.GetElement(key.ElementId);
            if (hostEl != null)
            {
                references.Add(new Reference(hostEl));
            }
        }
        else
        {
            // Linked element
            RevitLinkInstance linkInstance = hostDoc.GetElement(key.LinkInstanceId) as RevitLinkInstance;
            if (linkInstance != null)
            {
                Document linkedDoc = linkInstance.GetLinkDocument();
                Element linkedEl = linkedDoc?.GetElement(key.ElementId);
                if (linkedEl != null)
                {
                    Reference refInLink = new Reference(linkedEl);
                    Reference hostRef = refInLink.CreateLinkReference(linkInstance);
                    references.Add(hostRef);
                }
            }
        }
    }

    uiDoc.Selection.SetReferences(references);
}
```
