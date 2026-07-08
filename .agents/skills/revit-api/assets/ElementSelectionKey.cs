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
            return ((ElementId != null ? ElementId.GetHashCode() : 0) * 397) ^ (LinkInstanceId != null ? LinkInstanceId.GetHashCode() : 0);
        }
    }
}
