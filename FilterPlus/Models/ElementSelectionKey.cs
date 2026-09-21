using System;
using Autodesk.Revit.DB;

namespace FilterPlus.Models;

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
#if REVIT2024_OR_GREATER
        long thisId = ElementId != null ? ElementId.Value : -1;
        long otherId = other.ElementId != null ? other.ElementId.Value : -1;
        
        long thisLinkId = LinkInstanceId != null ? LinkInstanceId.Value : -1;
        long otherLinkId = other.LinkInstanceId != null ? other.LinkInstanceId.Value : -1;
#else
        long thisId = ElementId != null ? ElementId.IntegerValue : -1;
        long otherId = other.ElementId != null ? other.ElementId.IntegerValue : -1;
        
        long thisLinkId = LinkInstanceId != null ? LinkInstanceId.IntegerValue : -1;
        long otherLinkId = other.LinkInstanceId != null ? other.LinkInstanceId.IntegerValue : -1;
#endif

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
#if REVIT2024_OR_GREATER
            long thisId = ElementId != null ? ElementId.Value : -1;
            long thisLinkId = LinkInstanceId != null ? LinkInstanceId.Value : -1;
#else
            long thisId = ElementId != null ? ElementId.IntegerValue : -1;
            long thisLinkId = LinkInstanceId != null ? LinkInstanceId.IntegerValue : -1;
#endif
            return (thisId.GetHashCode() * 397) ^ thisLinkId.GetHashCode();
        }
    }
}
