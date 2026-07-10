# Debugging Report: ElementId Class Instance Equality and Hash Set Matching Failure

## Symptom
When displaying elements in a hierarchical tree view (such as the Element Explorer in FilterPlus) and changing views or element scopes (e.g. from `Current Selection` to `Elements Visible` or `Elements belonging to View`), the checkboxes representing selected elements lose their checkmarks, even though the backend tracking set (`_persistentCheckedIds`) remains populated with the correct number of selected items.

---

## Root Cause
The custom wrapper key `ElementSelectionKey` used to store checked selections in `HashSet<ElementSelectionKey>` compared two `ElementId` objects directly using default equality (`Object.Equals(ElementId, other.ElementId)`).

This leads to comparison failures because of how the Revit API manages `ElementId` object instances across different API context queries:
1. **Selection Query (`GetElementIds()` / `GetReferences()`):**
   Retrieved element references reuse the exact same wrapper objects. Comparing them physically or by reference matches.
2. **Collector Query (`FilteredElementCollector(doc, viewId)`):**
   When the scope changes, the tree elements are built from a newly executed database collector. Revit instantiates **brand-new wrapper objects** for `ElementId` representing the elements, even if they point to the exact same database records.
3. **Reference vs. Value Inequality:**
   Because `Object.Equals` checks physical object reference equality before calling the virtual `Equals` method, and since `ElementId` hashes (`GetHashCode`) in some versions of the Revit API can differ for separate C# instances wrapping the same ID number, `HashSet.Contains` fails to match the new collector-generated keys against the selection-generated keys. Thus, the checkboxes are painted as unchecked.

---

## Resolution
To avoid instance-specific comparison mismatches, keys wrapping `ElementId` must compare the **raw numerical values** rather than the wrapping `ElementId` objects.

* **Revit 2024+**: Use the `.Value` property (which returns a `long`/`Int64`).
* **Revit 2023 and older**: Use the `.IntegerValue` property (which returns an `int`/`Int32`).

### Robust Implementation of `ElementSelectionKey` (Revit 2024+):
```csharp
public struct ElementSelectionKey : IEquatable<ElementSelectionKey>
{
    public ElementId ElementId { get; }
    public ElementId LinkInstanceId { get; }

    public ElementSelectionKey(ElementId elementId, ElementId linkInstanceId)
    {
        ElementId = elementId;
        LinkInstanceId = linkInstanceId ?? ElementId.InvalidElementId;
    }

    public bool Equals(ElementSelectionKey other)
    {
        long thisId = ElementId != null ? ElementId.Value : -1;
        long otherId = other.ElementId != null ? other.ElementId.Value : -1;
        
        long thisLinkId = LinkInstanceId != null ? LinkInstanceId.Value : -1;
        long otherLinkId = other.LinkInstanceId != null ? other.LinkInstanceId.Value : -1;

        return thisId == otherId && thisLinkId == otherLinkId;
    }

    public override bool Equals(object obj)
    {
        return obj is ElementSelectionKey other && Equals(other);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            long thisId = ElementId != null ? ElementId.Value : -1;
            long thisLinkId = LinkInstanceId != null ? LinkInstanceId.Value : -1;
            return (thisId.GetHashCode() * 397) ^ thisLinkId.GetHashCode();
        }
    }
}
```

By switching from object-level comparison to raw integer value comparison, selection matching remains fully consistent across selections, view transitions, and asynchronous collector updates.
