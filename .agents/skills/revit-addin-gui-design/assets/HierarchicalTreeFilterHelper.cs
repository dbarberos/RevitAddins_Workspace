using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RevitAddin.Common.UI.Helpers;

/// <summary>
/// Reusable helper for evaluating positive and negative search queries in WPF hierarchical TreeViews
/// with tri-state parent-child propagation.
/// Solves the cascading contradiction where negative lookaheads evaluate container nodes to true,
/// causing 100% of tree elements to be selected.
/// </summary>
public static class HierarchicalTreeFilterHelper
{
    /// <summary>
    /// Checks whether a search expression contains negative lookaround patterns (lookahead/lookbehind).
    /// </summary>
    public static bool IsNegativePattern(string pattern)
    {
        if (string.IsNullOrWhiteSpace(pattern)) return false;
        return pattern.Contains("(?!") || pattern.Contains("(?<!");
    }

    /// <summary>
    /// Recursively gathers all nodes in the hierarchy.
    /// </summary>
    public static IEnumerable<TNode> GetAllNodes<TNode>(IEnumerable<TNode> roots, Func<TNode, IEnumerable<TNode>?> getChildren)
    {
        foreach (var node in roots)
        {
            yield return node;
            var children = getChildren(node);
            if (children != null && children.Any())
            {
                foreach (var child in GetAllNodes(children, getChildren))
                {
                    yield return child;
                }
            }
        }
    }

    /// <summary>
    /// Executes a leaf-only bottom-up filter pass.
    /// Evaluates only true leaf elements, bypassing container downward cascading,
    /// and triggers bottom-up state recalculation on root nodes.
    /// </summary>
    public static void FilterNegativeBottomUp<TNode>(
        IEnumerable<TNode> roots,
        Func<TNode, IEnumerable<TNode>?> getChildren,
        Func<TNode, bool> isSelectableLeaf,
        Func<TNode, bool> matchesPredicate,
        Action<TNode, bool> setCheckedAction,
        Action<TNode> expandParentsAction,
        Action<TNode> refreshStateAction,
        bool useOrAccumulation)
    {
        var allLeaves = GetAllNodes(roots, getChildren)
            .Where(isSelectableLeaf)
            .ToList();

        foreach (var leaf in allLeaves)
        {
            bool match = matchesPredicate(leaf);
            if (match)
            {
                setCheckedAction(leaf, true);
                expandParentsAction(leaf);
            }
            else if (!useOrAccumulation)
            {
                setCheckedAction(leaf, false);
            }
        }

        foreach (var root in roots)
        {
            refreshStateAction(root);
        }
    }
}
