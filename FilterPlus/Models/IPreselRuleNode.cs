using System.Collections.Generic;

namespace FilterPlus.Models;

public interface IPreselRuleNode
{
    PreSelectionRuleSet Parent { get; }
    void UpdateElements(IEnumerable<ElementModel> elements);
}
